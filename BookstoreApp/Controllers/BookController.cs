using BookstoreApp.Core.Models.Book;
using BookstoreApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApp.Controllers
{
	public class BookController : Controller
	{
		private readonly ApplicationDbContext context;

		public BookController(ApplicationDbContext context)
		{
			this.context = context;
		}
		public IActionResult Index()
		{
			return View();
		}
		public async Task<IActionResult> Details(int id)
		{
			BookDetailsViewModel? game = await context.Books
				.Where(g => g.Id == id)
				.Select(g => new BookDetailsViewModel
				{
					Id = g.Id,
					Title = g.Title,
					Description = g.Description,
					ImageUrl = g.ImageUrl,
					Price = g.Price,
					Category = g.Category.Name
				}).FirstOrDefaultAsync();

			if (game == null)
			{
				return BadRequest();
			}

			return View(game);
		}
	}
}
