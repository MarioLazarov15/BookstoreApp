using BookstoreApp.Core.Contracts;
using BookstoreApp.Core.Models.Admin;
using BookstoreApp.Core.Models.Book;
using BookstoreApp.Core.Models.Shoppingcart;
using BookstoreApp.Extensions;
using BookstoreApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApp.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IAdminServices adminService;

        public AdminController(
            IAdminServices adminService)
        {
            this.adminService = adminService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModifyBook(int id, AdminViewModel bookExtendedViewModel)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }


            if (!ModelState.IsValid)
            {

                return View(bookExtendedViewModel);
            }

            await adminService.ModifyBook(id, bookExtendedViewModel.Title, bookExtendedViewModel.Price,
                bookExtendedViewModel.ImageUrl, bookExtendedViewModel.Description, bookExtendedViewModel.CategoryId);

            return RedirectToAction("Details", "Book", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> ModifyBook(int id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            var book = await adminService.GetBookById(id);
			var categories = await adminService.GetAllCategories();
			if (book == null)
            {
                return BadRequest();
            }

            var viewModel = new AdminViewModel
            {
                Title = book.Title,
                Price = book.Price,
                ImageUrl = book.ImageUrl,
                Description = book.Description,
                CategoryId = book.Category.Id,
                Categories = categories
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewBook(AdminViewModel adminViewModel)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {

                return View(adminViewModel);
            }

            var newBook = await adminService.AddNewBook(adminViewModel.Title, 
                adminViewModel.Price, adminViewModel.ImageUrl,
                adminViewModel.Description, adminViewModel.CategoryId);

            return RedirectToAction("Details", "Book", new { newBook.Id });
        }

        [HttpGet]
        public async Task<IActionResult> AddNewBook()
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }
            var categories = await adminService.GetAllCategories();
            var viewModel = new AdminViewModel()
            {
                Categories = categories
            };

            return View(viewModel);
        }
    }
}
