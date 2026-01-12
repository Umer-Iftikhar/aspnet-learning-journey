using ContactForm.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactForm.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Submit(ContactSubmission model)
        {
            //TempData["Submission"] = model;
            TempData["UserName"] = model.Name;
            return RedirectToAction("ThankYou");
        }
        [HttpGet]
        public IActionResult ThankYou()
        {
            var name = TempData["UserName"];
            ViewBag.Name = name;
            return View(); 
        }
    }
}
