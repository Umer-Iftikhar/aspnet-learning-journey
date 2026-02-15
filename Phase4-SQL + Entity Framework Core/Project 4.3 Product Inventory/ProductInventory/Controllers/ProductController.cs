using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductInventory.Data;

namespace ProductInventory.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allProducts = await _context.Products.Include(p => p.Category).ToListAsync();
            return View(allProducts);
        }
    }
}
