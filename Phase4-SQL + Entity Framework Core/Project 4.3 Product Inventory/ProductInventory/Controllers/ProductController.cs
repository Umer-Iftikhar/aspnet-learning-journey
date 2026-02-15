using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductInventory.Data;
using ProductInventory.Models;
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
        public async Task<IActionResult> Index(int? categoryId)
        {
            var viewModel = new ProductIndexViewModel
            {
                Products = await _context.Products
                    .Include(p => p.Category)
                    .AsQueryable()
                    .Where(p => !categoryId.HasValue || p.CategoryId == categoryId)
                    .ToListAsync(),
                Categories = await _context.Categories.ToListAsync(),
                //SelectedCategoryId = categoryId
            };
            return View(viewModel);
            
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
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            var viewModel = new ProductFormViewModel
            {
                Product = product,
                Categories = await _context.Categories.ToListAsync()
            };
            return View(viewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(ProductFormViewModel viewModel)
        {
            var existingProduct = await _context.Products.FindAsync(viewModel.Product.Id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.Name = viewModel.Product.Name;
            existingProduct.Price = viewModel.Product.Price;
            existingProduct.CategoryId = viewModel.Product.CategoryId;
            existingProduct.Stock = viewModel.Product.Stock;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));   
        }
    }
    
}
