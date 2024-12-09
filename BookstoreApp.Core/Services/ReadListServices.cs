using BookstoreApp.Core.Contracts;
using BookstoreApp.Core.Models.ReadList;
using BookstoreApp.Infrastructure.Data.Models;
using BookstoreApp.Core.Models.Shoppingcart;
using BookstoreApp.Infrastructure.Data;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookstoreApp.Infrastructure.Constants.DataConstants;

namespace BookstoreApp.Core.Services
{
    public class ReadListServices : IReadListServices
    {
        private readonly ApplicationDbContext context;

        public ReadListServices(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<BooksReadListViewModel>> GetReadListAsync(string userId)
        {
            List<BooksReadListViewModel> books = await context.BooksReadLists
                .Where(scp => scp.ReadList.Id == userId)
                .Select(sc => new BooksReadListViewModel
                {
                    Id = sc.Book.Id,
                    ImageUrl = sc.Book.ImageUrl,
                    Title = sc.Book.Title,
                    Price = sc.Book.Price,
                    Category = sc.Book.Category.Name
                })
                .ToListAsync();

            return books;
        }

        public async Task AddBookToReadListAsync(int bookId, string userId)
        {
            var book = await context.Books.FindAsync(bookId);

            Infrastructure.Data.Models.Category category = await context.Categories.FirstOrDefaultAsync(c => c.Id == book.CategoryId);
            book.Category = category;

            ReadList? readlist = await context.ReadLists.FindAsync(userId);
            ReadList readList;
            if (readlist==null)
            {
                readList = new ReadList
                {
                    Id = userId
                };
            }
            else
            {
                readList = readlist;
            }

            var readListBook = new BooksReadList
            {
                Book = book,
                BookId = bookId,
                ReadList = readList,
                ReadListId = userId
            };

            if (await context.BooksReadLists
                .FirstOrDefaultAsync(wp => wp.Book.Id == bookId && wp.ReadList.Id == userId) == null)
            {
                context.BooksReadLists.Add(readListBook);
                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveBookFromReadListAsync(int bookId, string userId)
        {

            var readListsBooks = await context.BooksReadLists
                .FirstOrDefaultAsync(scp => scp.BookId == bookId && scp.ReadListId == userId);

            context.BooksReadLists.Remove(readListsBooks);
            await context.SaveChangesAsync();
        }
    }
}
