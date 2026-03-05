using Microsoft.AspNetCore.Mvc;
using RecipeForm.Models;

namespace RecipeForm.Controllers
{
    public class RecipeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Submit(Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", recipe);
            }
            string recipeName = recipe.Name;
            List<string> ingredients = recipe.Ingredients;
            return RedirectToAction("Index");
        }
    }
}
