using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductInventory.Data;
using ProductInventory.ViewModels;

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
        public async Task<IActionResult> Create()
        {
            var viewModel = new ProductFormViewModel
            {
                Product = new Models.Product(),
                Categories = await _context.Categories.ToListAsync()
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductFormViewModel viewModel)
        {
            _context.Products.Add(viewModel.Product);
            await _context.SaveChangesAsync();
            viewModel.Categories = await _context.Categories.ToListAsync();
            return RedirectToAction(nameof(Index));
        }
    }
    
}
