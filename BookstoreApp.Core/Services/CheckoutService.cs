using BookstoreApp.Core.Contracts;
using BookstoreApp.Core.Models.Shoppingcart;
using BookstoreApp.Infrastructure.Data.Models;
using BookstoreApp.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreApp.Core.Models.Checkout;
using BookstoreApp.Core.Models.Category;
using BookstoreApp.Core.Models.Country;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApp.Core.Services
{
	public class CheckoutService : ICheckoutService
	{
		private readonly ApplicationDbContext context;
		private readonly UserManager<IdentityUser> userManager;

		public CheckoutService(ApplicationDbContext context, UserManager<IdentityUser> userManager)
		{
			this.context = context;
			this.userManager = userManager;
		}

		public async Task<ShoppingcartViewModel> Index(string shoppingcartId)
		{
			var total = context.ShoppingcartsBooks
				.Where(sp => sp.ShoppingcartId == shoppingcartId)
				.Sum(sp => sp.Book.Price * sp.ProductAmount);

			var viewModel = new ShoppingcartViewModel
			{
				Total = total,
				ShoppingcartId = shoppingcartId
			};

			return viewModel;
		}

		public async Task ProcessCheckout(string shoppingcartId, CheckoutFormModel checkoutFormModel)
		{
			var user = await userManager.FindByIdAsync(shoppingcartId);
			var orderId = Guid.NewGuid();
			var order = new Order()
			{
				Id = orderId.ToString(),
				FirstName = checkoutFormModel.FirstName,
				LastName = checkoutFormModel.LastName,
				Email = checkoutFormModel.Email,
				PhoneNumber = checkoutFormModel.Phone.ToString(),
				City = checkoutFormModel.City,
				ZipCode = checkoutFormModel.Postcode.ToString(),
				AdditionalInfo = checkoutFormModel.AdditionalInfo,
				CountryId = checkoutFormModel.CountryId

			};

			var shoppingcartProducts = context.ShoppingcartsBooks.Where(scp => scp.ShoppingcartId == shoppingcartId);

			foreach (var scp in shoppingcartProducts)
			{
				var productOrder = new OrderBook()
				{
					Amount = scp.ProductAmount,
					Order = order,
					BookId = scp.BookId,
				};
				await context.OrdersBooks.AddAsync(productOrder);
			}

			await context.Orders.AddAsync(order);

			var userOrder = new UserOrder()
			{
				OrderId = order.Id,
				UserId = user.Id,
			};


			await context.UsersOrders.AddAsync(userOrder);
			await context.SaveChangesAsync();
		}

		public void OrderDone(string shoppingcartId)
		{
			var shoppingCartItems = context.ShoppingcartsBooks
				.Where(sp => sp.ShoppingcartId == shoppingcartId);

			context.ShoppingcartsBooks.RemoveRange(shoppingCartItems);
			context.SaveChangesAsync();
		}
        public async Task<IEnumerable<CountryViewModel>> GetAllCountries()
        {
			return await context.Countries
				.Select(sc => new CountryViewModel
				{
					Id = sc.Id,
					Name = sc.Name
				}).ToListAsync();
        }
    }
}
