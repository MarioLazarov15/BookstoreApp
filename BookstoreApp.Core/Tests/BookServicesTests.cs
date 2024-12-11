using Moq;
using NUnit.Framework;
using BookstoreApp.Core.Services;
using BookstoreApp.Core.Contracts;
using BookstoreApp.Core.Models.Book;
using BookstoreApp.Infrastructure.Data;
using BookstoreApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreApp.Core.Tests
{
    [TestFixture]
    public class BookServicesTests
    {
        private DbContextOptions<ApplicationDbContext> _dbContextOptions;
        private ApplicationDbContext _context;
        private BookServices _bookServices;

        [OneTimeSetUp]
        public void SetUp()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "BookstoreTestDb")
                .Options;

            _context = new ApplicationDbContext(_dbContextOptions);
            _bookServices = new BookServices(_context);

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            var category = new Category { Name = "Fiction" };
            var book = new Book
            {
                Id = 15,
                Title = "Test Book",
                Description = "Test Description",
                ImageUrl = "http://example.com/image.jpg",
                Price = 20.99m,
                Category = category
            };

            _context.Books.Add(book);
            _context.SaveChanges();
        }

        [Test]
        public async Task GetBookDetailsAsync()
        {
            var result = await _bookServices.GetBookDetailsAsync(15);

            Assert.IsNotNull(result);
            Assert.AreEqual(15, result.Id);
            Assert.AreEqual("Test Book", result.Title);
            Assert.AreEqual("Test Description", result.Description);
            Assert.AreEqual("http://example.com/image.jpg", result.ImageUrl);
            Assert.AreEqual(20.99m, result.Price);
            Assert.AreEqual("Fiction", result.Category);
        }

        [Test]
        public async Task GetBookDetailsAsync_ReturnNull()
        {
            var result = await _bookServices.GetBookDetailsAsync(9999);

            Assert.IsNull(result);
        }

        [Test]
        public async Task RemoveBookAsync()
        {
            await _bookServices.RemoveBookAsync(15);
            var removedBook = _context.Books.Find(15);

            Assert.IsNull(removedBook);
        }

    }
}
