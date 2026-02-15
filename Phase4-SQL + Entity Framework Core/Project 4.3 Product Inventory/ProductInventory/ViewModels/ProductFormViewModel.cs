using ProductInventory.Models;

namespace ProductInventory.ViewModels
{
    public class ProductFormViewModel
    {
        public Product Product { get; set; } 
        public List<Category> Categories { get; set; } = new();
    }
}
