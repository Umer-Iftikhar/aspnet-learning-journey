using Enhanced_Product_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Enhanced_Product_Management.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Product());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

           return View(product);
        }
    }
}
