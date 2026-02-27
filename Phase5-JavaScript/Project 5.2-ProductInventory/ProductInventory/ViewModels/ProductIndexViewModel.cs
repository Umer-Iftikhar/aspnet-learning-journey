using ProductInventory.Models;

namespace ProductInventory.ViewModels
{
    public class ProductIndexViewModel
    {
        public List<Product> Products { get; set; } = new();
        public List<Category> Categories { get; set; } = new();
        public int? SelectedCategoryId { get; set; }
    }
}
