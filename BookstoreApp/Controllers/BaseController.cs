using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApp.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
