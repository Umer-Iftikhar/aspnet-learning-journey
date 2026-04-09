using System.ComponentModel.DataAnnotations;
using Enhanced_Product_Management.Models;

namespace Enhanced_Product_Management.Tests
{
    public class ProductValidationTests
    {
        private IList<ValidationResult> ValidateModel(object model)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model);
            Validator.TryValidateObject(model, context, results, true);
            return results;
        }

        [Fact]
        public void Product_WithValidData_ShouldPassValidation()
        {
            var product = new Product
            {
                Name = "Test Product",
                Price = 10,
                Stock = 5
            };
            ValidateModel(product);

            Assert.Empty(ValidateModel(product));

        }

        [Theory]
        [InlineData(-1)]
        [InlineData(10001)]
        public void Product_WithInvalidPrice_ShouldFailValidation(decimal invalidPrice)
        {
            var product = new Product
            {
                Name = "Test",
                Price = invalidPrice,
                Stock = 5
            };
            var result = ValidateModel(product);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void Product_InStockWithZeroPrice_ShouldFailValidation()
        {
            var product = new Product
            {
                Name = "Test",
                Price = 0,
                Stock = 5
            };
            var result = ValidateModel(product);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void Product_WithoutName_ShouldFailValidation()
        {
            var product = new Product
            {
                Price = 10,
                Stock = 5
            };
            var result = ValidateModel(product);
            Assert.NotEmpty(result);
        }
    }
}
