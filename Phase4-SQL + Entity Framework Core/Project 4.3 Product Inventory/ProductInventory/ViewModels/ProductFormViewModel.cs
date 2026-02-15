using ProductInventory.Models;

namespace ProductInventory.ViewModels
{
    public class ProductFormViewModel
    {
        public Product product;
        public List<Category> Categories { get; set; } = new();
    }
}
