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
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;

        public ShoppingcartController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<IActionResult> GetAllFromShoppingcart()
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                return BadRequest();
            }

            List<BookExtendedViewModel> products = await context.ShoppingcartsBooks
                .Where(scp => scp.Shoppingcart.Id.ToString() == user.Id)
                .Select(sc => new BookExtendedViewModel
                {
                    Id = sc.Book.Id,
                    ImageUrl = sc.Book.ImageUrl,
                    Title = sc.Book.Title,
                    Price = sc.Book.Price,
                    Amount = sc.ProductAmount,
                }).ToListAsync();

            decimal total = products.Sum(p => p.Price * p.Amount);

            var viewModel = new ShoppingcartViewModel
            {
                ShoppingcartId = user.Id,
                Products = products,
                Total = total
            };
            viewModel.IdentityUser = user;

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
            var product = await context.Books.FindAsync(bookId);
            ShoppingCart? shoppingcart = await context.Shoppingcarts.FirstOrDefaultAsync(sc=>sc.Id == user.Id);
            var shoppingCart = shoppingcart;
            if (shoppingcart == null)
            {
                shoppingCart = new ShoppingCart
                {
                    Id=user.Id
                };
            }

            var alreadyInShoppingcart = await context.ShoppingcartsBooks
                .FirstOrDefaultAsync(scp => scp.Book.Id == bookId && scp.Shoppingcart.Id == user.Id);

            if (alreadyInShoppingcart == null)
            {
                var shoppingcartProduct = new ShoppingcartBook
                {
                    Book = product,
                    BookId = bookId,
                    ShoppingcartId = user.Id,
                    Shoppingcart = shoppingCart,
                    ProductAmount=1
                };

                context.ShoppingcartsBooks.Add(shoppingcartProduct);
                await context.SaveChangesAsync();
            }
            else
            {
                alreadyInShoppingcart.ProductAmount += 1;

                await context.SaveChangesAsync();
            }

            return RedirectToAction("GetAllFromShoppingcart", "Shoppingcart");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromShoppingcart(int productId)
        {
            var user = await userManager.GetUserAsync(User);
            var shoppingcartProduct = await context.ShoppingcartsBooks
                .FirstOrDefaultAsync(scp => scp.BookId == productId && scp.ShoppingcartId == user.Id);

            context.ShoppingcartsBooks.Remove(shoppingcartProduct);
            await context.SaveChangesAsync();

            return RedirectToAction("GetAllFromShoppingcart", "Shoppingcart");
        }
    }
}
