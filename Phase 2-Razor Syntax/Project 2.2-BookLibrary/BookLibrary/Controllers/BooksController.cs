using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
