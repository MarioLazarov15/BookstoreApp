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
    public class AdminServicesTests
    {
        private DbContextOptions<ApplicationDbContext> _dbContextOptions;
        private ApplicationDbContext _context;
        private AdminServices _adminServices;

        [OneTimeSetUp]
        public void SetUp()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AdminServiceTestDb")
                .Options;
            _context = new ApplicationDbContext(_dbContextOptions);
            _adminServices = new AdminServices(_context);

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            var category1 = new Category { Id = 1, Name = "Fiction" };
            var category2 = new Category { Id = 2, Name = "Non-fiction" };
            _context.Categories.AddRange(category1, category2);

            var book1 = new Book { Id = 1, Title = "Book One", Price = 10.99m, ImageUrl = "image1.jpg", Description = "Description 1", CategoryId = 1 };
            var book2 = new Book { Id = 2, Title = "Book Two", Price = 12.99m, ImageUrl = "image2.jpg", Description = "Description 2", CategoryId = 2 };
            _context.Books.AddRange(book1, book2);
            _context.SaveChanges();
        }

        [Test]
        public async Task AddNewBook()
        {
            var title = "New Book";
            var price = 15.99m;
            var imageUrl = "newbook.jpg";
            var description = "New book description";
            var categoryId = 1;
            var book = await _adminServices.AddNewBook(title, price, imageUrl, description, categoryId);

            Assert.IsNotNull(book);
            Assert.AreEqual(title, book.Title);
            Assert.AreEqual(price, book.Price);
            Assert.AreEqual(imageUrl, book.ImageUrl);
            Assert.AreEqual(description, book.Description);
            Assert.AreEqual(categoryId, book.CategoryId);
        }

        [Test]
        public async Task AddNewBook_ReturnNullCategoryNotExist()
        {
            var title = "New Book";
            var price = 15.99m;
            var imageUrl = "newbook.jpg";
            var description = "New book description";
            var categoryId = 999; 
            var book = await _adminServices.AddNewBook(title, price, imageUrl, description, categoryId);

            Assert.IsNull(book);
        }

        [Test]
        public async Task GetBookById()
        {
            var bookId = 1;
            var book = await _adminServices.GetBookById(bookId);

            Assert.IsNotNull(book);
            Assert.AreEqual(bookId, book.Id);
            Assert.AreEqual("Book One", book.Title);
        }

        [Test]
        public async Task GetBookById_ReturnNullBookNotExist()
        {
            var bookId = 999;
            var book = await _adminServices.GetBookById(bookId);

            Assert.IsNull(book);
        }

        [Test]
        public async Task ModifyBook()
        {
            var bookId = 1;
            var title = "Updated Book Title";
            var price = 20.99m;
            var imageUrl = "updatedimage.jpg";
            var description = "Updated description";
            var categoryId = 2;
            await _adminServices.ModifyBook(bookId, title, price, imageUrl, description, categoryId);

            var updatedBook = await _adminServices.GetBookById(bookId);
            Assert.IsNotNull(updatedBook);
            Assert.AreEqual(title, updatedBook.Title);
            Assert.AreEqual(price, updatedBook.Price);
            Assert.AreEqual(imageUrl, updatedBook.ImageUrl);
            Assert.AreEqual(description, updatedBook.Description);
            Assert.AreEqual(categoryId, updatedBook.CategoryId);
        }

        [Test]
        public async Task ModifyBook_NotUpdateBookNotExist()
        {
            var bookId = 999; 
            var title = "Updated Book Title";
            var price = 20.99m;
            var imageUrl = "updatedimage.jpg";
            var description = "Updated description";
            var categoryId = 2;
            await _adminServices.ModifyBook(bookId, title, price, imageUrl, description, categoryId);
            var book = await _adminServices.GetBookById(bookId);

            Assert.IsNull(book);
        }

        [Test]
        public async Task GetAllCategories()
        {
            var categories = await _adminServices.GetAllCategories();
            
            Assert.AreEqual(2, categories.Count());
            Assert.AreEqual("Fiction", categories.First().Name);
            Assert.AreEqual("Non-fiction", categories.Last().Name);
        }
    }
}
