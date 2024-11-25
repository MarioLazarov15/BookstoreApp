using BookstoreApp.Core.Contracts;
using BookstoreApp.Core.Models.Book;
using BookstoreApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Core.Services
{
	public class BookServices : IBookServices
	{
		private readonly ApplicationDbContext context;

		public BookServices(ApplicationDbContext context)
		{
			this.context = context;
		}
		public async Task<BookDetailsViewModel?> GetBookDetailsAsync(int id)
		{
			BookDetailsViewModel? book = await context.Books
				.Where(g => g.Id == id)
				.Select(g => new BookDetailsViewModel
				{
					Id = g.Id,
					Title = g.Title,
					Description = g.Description,
					ImageUrl = g.ImageUrl,
					Price = g.Price,
					Category = g.Category.Name
				})
				.FirstOrDefaultAsync();

			return book;
		}
	}
}
