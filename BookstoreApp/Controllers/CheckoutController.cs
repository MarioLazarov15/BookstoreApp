using BookstoreApp.Core.Contracts;
using BookstoreApp.Core.Models.Checkout;
using BookstoreApp.Core.Models.Country;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApp.Controllers
{
	public class CheckoutController : BaseController
	{
		private readonly ICheckoutService checkoutService;
		private UserManager<IdentityUser> userManager;
		public CheckoutController(ICheckoutService checkoutService, UserManager<IdentityUser> userManager)
		{
			this.userManager = userManager;
			this.checkoutService = checkoutService;
		}
		public async Task<IActionResult> Index()
		{
			var user = await userManager.GetUserAsync(User);

			var shoppingCartViewModel = await checkoutService.Index(user.Id);
			var countries = await checkoutService.GetAllCountries();

            var checkoutFormModel = new CheckoutFormModel()
			{
				Countries = countries
			};

			return View(checkoutFormModel);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ProcessCheckout(CheckoutFormModel checkoutFormModel)
		{
			var user = await userManager.GetUserAsync(User);
			var shoppingCartViewModel = await checkoutService.Index(user.Id);

            var countries = await checkoutService.GetAllCountries();

            checkoutFormModel = new CheckoutFormModel()
            {
                Countries = countries
            };

            if (!ModelState.IsValid)
			{
				return View("Index", checkoutFormModel);
			}

			await checkoutService.ProcessCheckout(user.Id, checkoutFormModel);

			return RedirectToAction("OrderDone");
		}

		public async Task<IActionResult> OrderDone()
		{
			var user = await userManager.GetUserAsync(User);

			checkoutService.OrderDone(user.Id);
			return View();
		}
	}
}
