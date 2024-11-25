using BookstoreApp.Core.Contracts;
using BookstoreApp.Core.Models.Book;
using BookstoreApp.Core.Models.Shoppingcart;
using BookstoreApp.Infrastructure.Data;
using BookstoreApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApp.Controllers
{
    public class ShoppingcartController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
		private readonly IShoppingcartServices shoppingcartServices;
        
		public ShoppingcartController(IShoppingcartServices shoppingcartServices, UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            this.shoppingcartServices = shoppingcartServices;
        }

        public async Task<IActionResult> GetAllFromShoppingcart()
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                return BadRequest();
            }

            var viewModel =await shoppingcartServices.GetAllBooksFromCartAsync(user.Id);

            if (viewModel.Products == null)
            {
                return BadRequest();
            }

            return View(viewModel);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToShoppingcart(int bookId)
        {
            var user = await userManager.GetUserAsync(User);
			if (user == null)
			{
				return BadRequest();
			}
			await shoppingcartServices.AddBookToCartAsync(bookId,user.Id);

            return RedirectToAction("GetAllFromShoppingcart", "Shoppingcart");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromShoppingcart(int productId)
        {
            var user = await userManager.GetUserAsync(User);

            await shoppingcartServices.RemoveBookFromCartAsync(productId, user.Id);

			return RedirectToAction("GetAllFromShoppingcart", "Shoppingcart");
        }
    }
}
