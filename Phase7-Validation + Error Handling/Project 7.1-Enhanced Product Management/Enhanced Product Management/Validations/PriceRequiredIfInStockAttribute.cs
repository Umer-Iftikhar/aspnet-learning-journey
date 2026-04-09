using Enhanced_Product_Management.Models;
using System.ComponentModel.DataAnnotations;
namespace Enhanced_Product_Management.Validations
{
    public class PriceRequiredIfInStockAttribute : ValidationAttribute
    {
        public override ValidationResult IsValid(object value, ValidationContext context)
        {
            var product = context.ObjectInstance as Product;
            //ValidationResult ValidationReault = new ValidationResult("Price is required when the product is in stock.");
            

            if (product != null)
            {
                if (product.Stock > 0 && product.Price <= 0)
                {
                    return  new ValidationResult("Price is required when the product is in stock.");
                }
              
                return   ValidationResult.Success;
                
            }
        }
    }
}
