using Microsoft.AspNetCore.Mvc;

namespace RecipeForm.Controllers
{
    public class RecipeController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
