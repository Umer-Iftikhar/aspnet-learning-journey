using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookstoreApp.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\s.,!?'-]+$", ErrorMessage = "Name can only contain letters, numbers, spaces, and basic punctuation.")]
        [MaxLength(100)]
        [Display(Name = "Product Name")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = string.Empty;


        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Product Price")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Price must be a valid decimal number with up to 2 decimal places.")]
        [Column(TypeName = "decimal(18,2)")]  
        public decimal Price { get; set; }

        
        [MaxLength(500)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Product Description")]
        [MinLength(10, ErrorMessage = "Description must be at least 10 characters long.")]
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = string.Empty;


        [Required]
        [Display(Name = "Product Stock ")]
        public int Stock { get; set; }
    }
}
