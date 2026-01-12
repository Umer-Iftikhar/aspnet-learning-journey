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
            TempData["Name"] = model.Name;
            TempData["Email"] = model.Email;
            TempData["Subject"] = model.Subject;
            TempData["Message"] = model.Message;

            return RedirectToAction("ThankYou");
        }
        [HttpGet]
        public IActionResult ThankYou()
        {
            return View();  
        }
    }
}
