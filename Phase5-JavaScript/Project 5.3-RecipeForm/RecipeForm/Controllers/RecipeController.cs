using Microsoft.AspNetCore.Mvc;

namespace RecipeForm.Controllers
{
    public class RecipeController : Controller
    {
        [HttpGet]
        public  IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Submit()
        {
            return RedirectToAction("Index");
        }
    }
}
