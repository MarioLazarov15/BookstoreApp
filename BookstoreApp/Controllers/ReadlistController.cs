using BookstoreApp.Core.Contracts;
using BookstoreApp.Core.Models.Bookstore;
using BookstoreApp.Core.Models.ReadList;
using BookstoreApp.Core.Services;
using BookstoreApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApp.Controllers
{
    public class ReadlistController : BaseController
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IReadListServices readListServices;

        public ReadlistController(IReadListServices readListServices, UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            this.readListServices = readListServices;
        }

        public async Task<IActionResult> GetReadList()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return BadRequest();
            }

            var books = await readListServices.GetReadListAsync(user.Id);

            if (books == null)
            {
                return BadRequest();
            }
            var viewModel = new ReadListViewModel
            {
                IdentityUser = user,
                Books = books
            };

            if (viewModel==null)
            {
                return BadRequest();
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBookToReadList(int bookId)
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                return BadRequest();
            }
            await readListServices.AddBookToReadListAsync(bookId, user.Id);

            return RedirectToAction("GetReadList", "Readlist");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromReadList(int bookId)
        {
            var user = await userManager.GetUserAsync(User);

            await readListServices.RemoveBookFromReadListAsync(bookId, user.Id);

            return RedirectToAction("GetReadList", "Readlist");
        }
    }
}
