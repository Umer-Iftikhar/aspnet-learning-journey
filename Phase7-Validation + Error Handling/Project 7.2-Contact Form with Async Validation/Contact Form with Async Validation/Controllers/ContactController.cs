using Contact_Form_with_Async_Validation.Data;
using Contact_Form_with_Async_Validation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contact_Form_with_Async_Validation.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Submit(ContactSubmission model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Index), model);
            }
            // Check if the email already exists in the database
            var emailExists = await _context.ContactSubmissions.AnyAsync(c => c.Email == model.Email);
            if (emailExists)
            {
                ModelState.AddModelError("Email", "Email already in use. Try a different one."); 
                return View(nameof(Index), model);
            }

            model.SubmittedAt = DateTime.UtcNow;
            _context.ContactSubmissions.Add(model); // Add the new submission to the context
            await _context.SaveChangesAsync();
            

            return RedirectToAction(nameof(ThankYou));
        }
        [HttpGet]
        public IActionResult ThankYou()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ValidateEmail(string Email)
        {
            var exists = await _context.ContactSubmissions.AnyAsync(c => c.Email == Email);
            // AnyAsync returns true if any record matches the condition, otherwise false
            if (exists)
            {
                return Json("Email already in use. Try a different one");
            }
            else
            {
                return Json(true);
            }
        }
    }
}
