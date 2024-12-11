using BookstoreApp.Core.Services;
using BookstoreApp.Infrastructure.Data.Models;
using BookstoreApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Core.Tests
{
    [TestFixture]
    public class ReadListServicesTests
    {
        private DbContextOptions<ApplicationDbContext> _dbContextOptions;
        private ApplicationDbContext _context;
        private ReadListServices _readListServices;

        [OneTimeSetUp]
        public void SetUp()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "ReadListServiceTestDb")
                .Options;

            _context = new ApplicationDbContext(_dbContextOptions);

            _readListServices = new ReadListServices(_context);

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            var category1 = new Category { Id = 1, Name = "Fiction" };
            var category2 = new Category { Id = 2, Name = "Non-fiction" };
            _context.Categories.AddRange(category1, category2);

            var book1 = new Book { Id = 1, Title = "Book One", Price = 10.99m, ImageUrl = "image1.jpg", CategoryId = 1 };
            var book2 = new Book { Id = 2, Title = "Book Two", Price = 12.99m, ImageUrl = "image2.jpg", CategoryId = 2 };
            _context.Books.AddRange(book1, book2);

            var readList1 = new ReadList { Id = "user123" };
            var readList2 = new ReadList { Id = "user456" };
            _context.ReadLists.AddRange(readList1, readList2);

            _context.SaveChanges();
        }

        [Test]
        public async Task GetReadListAsync()
        {
            var userId = "user123";

            await _readListServices.AddBookToReadListAsync(1, userId);
            var result = await _readListServices.GetReadListAsync(userId);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Book One", result[0].Title);
            Assert.AreEqual(10.99m, result[0].Price);
            Assert.AreEqual("Fiction", result[0].Category);
        }

        [Test]
        public async Task AddBookToReadListAsync()
        {
            var userId = "user123";
            var bookId = 1;

            await _readListServices.AddBookToReadListAsync(bookId, userId);
            var readListBooks = await _context.BooksReadLists
                .Where(brl => brl.ReadListId == userId)
                .ToListAsync();

            Assert.AreEqual(1, readListBooks.Count);
            Assert.AreEqual(bookId, readListBooks[0].BookId);
        }

        [Test]
        public async Task AddBookToReadListAsync_NotAddDuplicatedBook()
        {
            var userId = "user123";
            var bookId = 1;

            await _readListServices.AddBookToReadListAsync(bookId, userId);
            await _readListServices.AddBookToReadListAsync(bookId, userId);

            var readListBooks = await _context.BooksReadLists
                .Where(brl => brl.ReadListId == userId)
                .ToListAsync();

            Assert.AreEqual(1, readListBooks.Count);
        }

        [Test]
        public async Task RemoveBookFromReadListAsync()
        {
            var userId = "user123";
            var bookId = 1;

            await _readListServices.AddBookToReadListAsync(bookId, userId);
            await _readListServices.RemoveBookFromReadListAsync(bookId, userId);

            var readListBooks = await _context.BooksReadLists
                .Where(brl => brl.ReadListId == userId)
                .ToListAsync();

            Assert.AreEqual(0, readListBooks.Count);
        }
    }
}
