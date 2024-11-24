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
        private readonly ApplicationDbContext context;

        public BookstoreController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks(
			[FromQuery] string searchTerm = "",
			[FromQuery] BookSorting sorting = BookSorting.AscendingByName)
        {
			var productsQuery = context.Books.AsQueryable();

			if (!string.IsNullOrWhiteSpace(searchTerm))
			{
				productsQuery = productsQuery
					.Where(product => product.Title.ToLower().Contains(searchTerm.ToLower()));
			}

			switch (sorting)
			{
				case BookSorting.AscendingByPrice:
					productsQuery = productsQuery.OrderBy(p => p.Price);
					break;
				case BookSorting.DescendingByPrice:
					productsQuery = productsQuery.OrderByDescending(p => p.Price);
					break;
				case BookSorting.AscendingByName:
					productsQuery = productsQuery.OrderBy(p => p.Title);
					break;
				case BookSorting.DescendingByName:
					productsQuery = productsQuery.OrderByDescending(p => p.Title);
					break;
			}
			var books = await productsQuery
				.Select(product => new BookDetailsViewModel
				{
					Id = product.Id,
					Title = product.Title,
					Price = product.Price,
					Description = product.Description,
					ImageUrl = product.ImageUrl,
					Category = product.Category.Name
				})
				.ToListAsync();
			var viewModel = new BooksViewModel(books)
			{
				SearchTerm = searchTerm,
				Sorting = sorting,
			};
			return View(viewModel);

			
        }
    }
}
