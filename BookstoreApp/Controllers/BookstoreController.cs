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
		private readonly IBookstoreServices bookstoreServices;
		public BookstoreController(
			IBookstoreServices bookstoreServices)
		{
			this.bookstoreServices = bookstoreServices;
		}

        [HttpGet]
        public async Task<IActionResult> GetAllBooks(
			[FromQuery] string searchTerm = "",
			[FromQuery] BookSorting sorting = BookSorting.AscendingByName)
        {
			var books = await bookstoreServices.GetAllBooksAsync(searchTerm, sorting);

			var viewModel = new BooksViewModel(books)
			{
				SearchTerm = searchTerm,
				Sorting = sorting,
			};
			return View(viewModel);
        }
    }
}
