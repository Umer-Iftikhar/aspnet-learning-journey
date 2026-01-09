using Microsoft.AspNetCore.Mvc;

namespace SimpleCalculator.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(double num1, double num2, string operation)
        {
            double result = 0;
            switch(operation)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
                default:
                    result = 0;
                    break;
            }
            ViewBag.Result = result;
            return View(); 
        }
    }
}
