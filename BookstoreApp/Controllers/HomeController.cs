using BookstoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookstoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

		public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error(int statusCode)
        {
            if (statusCode == 500)
            {
                return View("Error");
            }

            if (statusCode == 404)
            {
                return View("Error404");
            }

            return View();
        }
    }
}
