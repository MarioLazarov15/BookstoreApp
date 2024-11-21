using BookstoreApp.Core.Contracts;
using BookstoreApp.Core.Models.Bookstore;
using BookstoreApp.Infrastructure.Data;
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

        public async Task<IEnumerable<BooksViewModel>> GetAllBooksAsync()
        {
            IEnumerable<BooksViewModel> books = await context.Books.Select(book => new BooksViewModel
            {
                Id= book.Id,
                Title = book.Title,
                ImageUrl = book.ImageUrl,
                Price = book.Price,
                Category = book.Category.Name
            }).ToListAsync();
            return books;
        }

    }
}
