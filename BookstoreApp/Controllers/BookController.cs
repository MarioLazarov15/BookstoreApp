using BookstoreApp.Core.Contracts;
using BookstoreApp.Core.Models.Book;
using BookstoreApp.Core.Services;
using BookstoreApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApp.Controllers
{
	public class BookController : Controller
	{
		private readonly IBookServices bookServices;
		public BookController(
			IBookServices bookServices)
		{
			this.bookServices = bookServices;
		}
		public async Task<IActionResult> Details(int id)
		{
			var book = await bookServices.GetBookDetailsAsync(id);

			if (book == null)
			{
				return BadRequest();
			}

			return View(book);
		}
		public async Task<IActionResult> Remove(int id)
		{
			await bookServices.RemoveBookAsync(id);

            return RedirectToAction("GetAllBooks", "Bookstore");
        }
	}
}
