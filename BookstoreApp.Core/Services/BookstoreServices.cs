﻿using BookstoreApp.Core.Contracts;
using BookstoreApp.Core.Models.Book;
using BookstoreApp.Core.Models.Bookstore;
using BookstoreApp.Infrastructure.Data;
using BookstoreApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Core.Services
{
    public  class BookstoreServices : IBookstoreServices
    {
        private readonly ApplicationDbContext context;

        public BookstoreServices(ApplicationDbContext context)
        {
            this.context = context;
        }


		public async Task<List<BookDetailsViewModel>> GetAllBooksAsync(string searchTerm, BookSorting sorting, int currentPage,int productsPerPage)
		{
			var productsQuery = context.Books.AsQueryable();

			if (!string.IsNullOrWhiteSpace(searchTerm))
			{
				productsQuery = productsQuery
					.Where(product => product.Title.ToLower().Contains(searchTerm.ToLower()));
			}

			switch (sorting)
			{
				case BookSorting.AscendingByPrice:
					productsQuery = productsQuery.OrderBy(p => p.Price);
					break;
				case BookSorting.DescendingByPrice:
					productsQuery = productsQuery.OrderByDescending(p => p.Price);
					break;
				case BookSorting.AscendingByName:
					productsQuery = productsQuery.OrderBy(p => p.Title);
					break;
				case BookSorting.DescendingByName:
					productsQuery = productsQuery.OrderByDescending(p => p.Title);
					break;
			}
			var books = await productsQuery
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .Select(book => new BookDetailsViewModel
				{
					Id = book.Id,
					Title = book.Title,
					Price = book.Price,
					Description = book.Description,
					ImageUrl = book.ImageUrl,
					Category = book.Category.Name
				})
				.ToListAsync();
			return books;
		}
        public async Task<int> GetBooksCountAsync()
		{ 
            var productsQuery = context.Books.AsQueryable();
            var totalBooksCount = await productsQuery.CountAsync();
			return totalBooksCount;
        }

    }
}
