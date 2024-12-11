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
    public class ShoppingcartServicesTests
    {
        private DbContextOptions<ApplicationDbContext> _dbContextOptions;
        private ApplicationDbContext _context;
        private ShoppingcartServices _shoppingcartServices;

        [OneTimeSetUp]
        public void SetUp()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "ShoppingCartTestDb")
                .Options;

            _context = new ApplicationDbContext(_dbContextOptions);

            _shoppingcartServices = new ShoppingcartServices(_context);

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
                Price = 10.20m,
                ImageUrl = "image1.jpg",
                Category = category1
            };
            var book2 = new Book
            {
                Id = 2,
                Title = "Book Two",
                Description = "Description of Book Two",
                Price = 12.30m,
                ImageUrl = "image2.jpg",
                Category = category1
            };
            _context.Books.AddRange(book1, book2);

            var shoppingCart = new ShoppingCart { Id = "user123" };
            _context.Shoppingcarts.Add(shoppingCart);

            _context.SaveChanges();
        }

        [Test]
        public async Task AddBookToCartAsync_IncreaseQuantityOfBook()
        {
            var bookId = 1;
            var userId = "user123";
            await _shoppingcartServices.AddBookToCartAsync(bookId, userId);

            await _shoppingcartServices.AddBookToCartAsync(bookId, userId);

            var cartBook = await _context.ShoppingcartsBooks
                .FirstOrDefaultAsync(scp => scp.BookId == bookId && scp.ShoppingcartId == userId);

            Assert.IsNotNull(cartBook);
            Assert.AreEqual(2, cartBook.ProductAmount);
        }

        [Test]
        public async Task AddBookToCartAsync()
        {
            var bookId = 1;
            var userId = "user1234";

            await _shoppingcartServices.AddBookToCartAsync(bookId, userId);

            var cartBook = await _context.ShoppingcartsBooks
                .FirstOrDefaultAsync(scp => scp.BookId == bookId && scp.ShoppingcartId == userId);

            Assert.IsNotNull(cartBook);
            Assert.AreEqual(1, cartBook.ProductAmount);
        }

        [Test]
        public async Task GetAllBooksFromCartAsync()
        {
            var userId = "user1235";
            var bookId1 = 1;
            var bookId2 = 2;
            await _shoppingcartServices.AddBookToCartAsync(bookId1, userId);
            await _shoppingcartServices.AddBookToCartAsync(bookId2, userId);

            var result = await _shoppingcartServices.GetAllBooksFromCartAsync(userId);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Products.Count);
            Assert.AreEqual("Book One", result.Products[0].Title);
            Assert.AreEqual("Book Two", result.Products[1].Title);
            Assert.AreEqual(22.50m, result.Total);
        }

        [Test]
        public async Task RemoveBookFromCartAsync()
        {
            var userId = "user1236";
            var bookId = 1;
            await _shoppingcartServices.AddBookToCartAsync(bookId, userId);

            await _shoppingcartServices.RemoveBookFromCartAsync(bookId, userId);

            var cartBook = await _context.ShoppingcartsBooks
                .FirstOrDefaultAsync(scp => scp.BookId == bookId && scp.ShoppingcartId == userId);

            Assert.IsNull(cartBook);
        }
    }
}
