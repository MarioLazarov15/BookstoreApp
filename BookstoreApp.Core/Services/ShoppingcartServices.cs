using BookstoreApp.Core.Contracts;
using BookstoreApp.Core.Models.Shoppingcart;
using BookstoreApp.Infrastructure.Data;
using BookstoreApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookstoreApp.Infrastructure.Constants.DataConstants;

namespace BookstoreApp.Core.Services
{
	public class ShoppingcartServices : IShoppingcartServices
	{
		private readonly ApplicationDbContext context;

		public ShoppingcartServices(ApplicationDbContext context)
		{
			this.context = context;
		}

		public async Task AddBookToCartAsync(int bookId, string userId)
		{
			var product = await context.Books.FindAsync(bookId);
			ShoppingCart? shoppingcart = await context.Shoppingcarts.FirstOrDefaultAsync(sc => sc.Id == userId);
			var shoppingCart = shoppingcart;
			if (shoppingcart == null)
			{
				shoppingCart = new ShoppingCart
				{
					Id = userId
				};
			}

			var alreadyInShoppingcart = await context.ShoppingcartsBooks
				.FirstOrDefaultAsync(scp => scp.Book.Id == bookId && scp.Shoppingcart.Id == userId);

			if (alreadyInShoppingcart == null)
			{
				var shoppingcartProduct = new ShoppingcartBook
				{
					Book = product,
					BookId = bookId,
					ShoppingcartId = userId,
					Shoppingcart = shoppingCart,
					ProductAmount = 1
				};

				context.ShoppingcartsBooks.Add(shoppingcartProduct);
				await context.SaveChangesAsync();
			}
			else
			{
				alreadyInShoppingcart.ProductAmount += 1;

				await context.SaveChangesAsync();
			}
		}

		public async Task<ShoppingcartViewModel?> GetAllBooksFromCartAsync(string userId)
		{

			List<BookExtendedViewModel> products = await context.ShoppingcartsBooks
				.Where(scp => scp.Shoppingcart.Id.ToString() == userId)
				.Select(sc => new BookExtendedViewModel
				{
					Id = sc.Book.Id,
					ImageUrl = sc.Book.ImageUrl,
					Title = sc.Book.Title,
					Price = sc.Book.Price,
					Amount = sc.ProductAmount,
				})
				.ToListAsync();

			decimal total = products.Sum(p => p.Price * p.Amount);

			var viewModel = new ShoppingcartViewModel
			{
				ShoppingcartId = userId,
				Products = products,
				Total = total
			};
			viewModel.IdentityUser.Id = userId;
			return viewModel;
		}

		public async Task RemoveBookFromCartAsync(int bookId, string userId)
		{

			var shoppingcartProduct = await context.ShoppingcartsBooks
				.FirstOrDefaultAsync(scp => scp.BookId == bookId && scp.ShoppingcartId == userId);
			context.ShoppingcartsBooks.Remove(shoppingcartProduct);
			await context.SaveChangesAsync();
		}
	}
}
