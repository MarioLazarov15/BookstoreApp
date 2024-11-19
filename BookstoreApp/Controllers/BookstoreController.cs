using BookstoreApp.Core.Models.Bookshop;
using BookstoreApp.Core.Services;
using BookstoreApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApp.Controllers
{
    public class BookstoreController : BaseController
    {
        private readonly ApplicationDbContext context;

        public BookstoreController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            IEnumerable<BooksViewModel> books = await context.Books.Select(book => new BooksViewModel
            {
                Id = book.Id,
                Title = book.Title,
                ImageUrl = book.ImageUrl,
                Price = book.Price,
                Category = book.Category.Name
            }).ToListAsync();
            return View(books);
        }
    }
}
