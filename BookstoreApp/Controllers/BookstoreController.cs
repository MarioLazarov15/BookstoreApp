using BookstoreApp.Core.Contracts;
using BookstoreApp.Core.Models.Book;
using BookstoreApp.Core.Models.Bookstore;
using BookstoreApp.Core.Services;
using BookstoreApp.Infrastructure.Data;
using BookstoreApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApp.Controllers
{
    public class BookstoreController : BaseController
    {
        private const int productsPerPage = 8;
        private readonly IBookstoreServices bookstoreServices;
		public BookstoreController(
			IBookstoreServices bookstoreServices)
		{
			this.bookstoreServices = bookstoreServices;
		}

        [HttpGet]
        public async Task<IActionResult> GetAllBooks(
			[FromQuery] string searchTerm = "",
            [FromQuery] int currentPage = 1,
            [FromQuery] BookSorting sorting = BookSorting.AscendingByName)
        {
			var books = await bookstoreServices.GetAllBooksAsync(searchTerm, sorting, currentPage, productsPerPage);
            var totalBooksCount = await bookstoreServices.GetBooksCountAsync();
			var viewModel = new BooksViewModel(books, totalBooksCount)
			{
				SearchTerm = searchTerm,
				Sorting = sorting,
                CurrentPage = currentPage
            };
			return View(viewModel);
        }
    }
}
