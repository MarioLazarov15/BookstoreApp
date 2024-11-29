using BookstoreApp.Core.Contracts;
using BookstoreApp.Core.Models.Category;
using BookstoreApp.Infrastructure.Data;
using BookstoreApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BookstoreApp.Core.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly ApplicationDbContext context;

        public AdminServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Book> AddNewBook(string title, decimal price, string imageUrl, string description, int categoryId)
        {
            Category category = await context.Categories.FirstOrDefaultAsync(c=>c.Id == categoryId);
            if (category == null)
            {
                return null;
            }
            var book = new Book
            {
                Title = title,
                Price = price,
                ImageUrl = imageUrl,
                Description = description,
                Category = category
            };

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();

            return book;
        }

        public async Task<Book> GetBookById(int id)
        {
            var book = await context.Books.FirstOrDefaultAsync(p => p.Id == id);

            if (book == null)
            {
                return null;
            }

            return book;
        }

        public async Task ModifyBook(int id, string title, decimal price, string imageUrl, string description, int categoryId)
        {
            var book = await GetBookById(id);

            if (book == null)
            {
                return;
            }
            Category category = await context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
            if (category == null)
            {
                return;
            }
            book.Title = title;
            book.Price = price;
            book.ImageUrl = imageUrl;
            book.Description = description;
            book.Category = category;

            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<CategoriesViewModel>> GetAllCategories()
        {
            return await context.Categories 
                .Select(sc => new CategoriesViewModel
                {
                    Id = sc.Id,
                    Name = sc.Name
                }).ToListAsync();
        }
    }
}
