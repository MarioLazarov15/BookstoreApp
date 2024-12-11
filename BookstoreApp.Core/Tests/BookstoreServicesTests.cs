using BookstoreApp.Core.Contracts;
using BookstoreApp.Core.Services;
using BookstoreApp.Infrastructure.Data;
using BookstoreApp.Infrastructure.Data.Models;
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
    public class BookstoreServicesTests
    {
        private DbContextOptions<ApplicationDbContext> _dbContextOptions;
        private ApplicationDbContext _context;
        private BookstoreServices _bookstoreServices;

        [OneTimeSetUp]
        public void SetUp()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "BookstoreTestDb")
                .Options;

            _context = new ApplicationDbContext(_dbContextOptions);
            _bookstoreServices = new BookstoreServices(_context);

            SeedDatabase();
        }


        private void SeedDatabase()
        {
            var category1 = new Category { Name = "Fiction" };
            var category2 = new Category { Name = "Science" };
            _context.Categories.AddRange(category1, category2);

            var book1 = new Book
            {
                Id = 1,
                Title = "Book One",
                Description = "Description of Book One",
                Price = 10.99m,
                ImageUrl = "image1.jpg",
                Category = category1
            };

            var book2 = new Book
            {
                Id = 2,
                Title = "Book Two",
                Description = "Description of Book Two",
                Price = 15.99m,
                ImageUrl = "image2.jpg",
                Category = category1
            };

            var book3 = new Book
            {
                Id = 3,
                Title = "Book Three",
                Description = "Description of Book Three",
                Price = 12.99m,
                ImageUrl = "image3.jpg",
                Category = category2
            };

            _context.Books.AddRange(book1, book2, book3);
            _context.SaveChanges();
        }

        [Test]
        public async Task GetAllBooksAsync_BooksMatchingSearchTerm()
        {
            var result = await _bookstoreServices.GetAllBooksAsync("Book One", BookSorting.AscendingByName, 1, 10);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Book One", result[0].Title);
        }
        
        [Test]
        public async Task GetAllBooksAsync_BooksMatchingUpperCaseSearchTerm()
        {
            var result = await _bookstoreServices.GetAllBooksAsync("BOOK ONE", BookSorting.AscendingByName, 1, 10);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Book One", result[0].Title);
        }
        [Test]
        public async Task GetAllBooksAsync_BooksMatchingLowerCaseSearchTerm()
        {
            var result = await _bookstoreServices.GetAllBooksAsync("book one", BookSorting.AscendingByName, 1, 10);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Book One", result[0].Title);
        }

        [Test]
        public async Task GetAllBooksAsync_BooksSortedByPriceAscending()
        {
            var result = await _bookstoreServices.GetAllBooksAsync(string.Empty, BookSorting.AscendingByPrice, 1, 10);

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("Book One", result[0].Title);
            Assert.AreEqual("Book Three", result[1].Title);
            Assert.AreEqual("Book Two", result[2].Title);
        }

        [Test]
        public async Task GetAllBooksAsync_BooksSortedByPriceDescending()
        {
            var result = await _bookstoreServices.GetAllBooksAsync(string.Empty, BookSorting.DescendingByPrice, 1, 10);

            Assert.AreEqual(3, result.Count);

            Assert.AreEqual("Book Two", result[0].Title);
            Assert.AreEqual("Book Three", result[1].Title);
            Assert.AreEqual("Book One", result[2].Title);
        }

        [Test]
        public async Task GetAllBooksAsync_BooksSortedByTitleAscending()
        {
            var result = await _bookstoreServices.GetAllBooksAsync(string.Empty, BookSorting.AscendingByName, 1, 10);

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("Book One", result[0].Title);
            Assert.AreEqual("Book Three", result[1].Title);
            Assert.AreEqual("Book Two", result[2].Title);
        }

        [Test]
        public async Task GetAllBooksAsync_BooksSortedByTitleDescending()
        {
            var result = await _bookstoreServices.GetAllBooksAsync(string.Empty, BookSorting.DescendingByName, 1, 10);

            Assert.AreEqual(3, result.Count);

            Assert.AreEqual("Book Two", result[0].Title);
            Assert.AreEqual("Book Three", result[1].Title);
            Assert.AreEqual("Book One", result[2].Title);
        }

        [Test]
        public async Task GetBooksCountAsync_ShouldReturnCorrectBookCount()
        {
            var result = await _bookstoreServices.GetBooksCountAsync();

            Assert.AreEqual(3, result);
        }
    }
}
