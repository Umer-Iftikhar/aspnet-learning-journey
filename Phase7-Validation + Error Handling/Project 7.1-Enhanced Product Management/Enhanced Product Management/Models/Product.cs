using System.ComponentModel.DataAnnotations;
using Enhanced_Product_Management.Validations;

namespace Enhanced_Product_Management.Models
{
    [PriceRequiredIfInStock]
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]

        public string Name { get; set; } = string.Empty;

        [Range(0, 10000, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        [Range(0, 10000, ErrorMessage = "Stock must be within the limit (0-10000).")]
        public int Stock { get; set; }
    }   
}
