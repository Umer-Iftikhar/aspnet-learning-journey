using LoginSystem.Models;
using Microsoft.AspNetCore.Mvc;
using LoginSystem.ViewModels;

namespace LoginSystem.Controllers
{
    public class AccountController : Controller
    {
        private static readonly List<User> _users = new()
        {
            new User { UserName = "admin", Password = "password" },
            new User { UserName = "user", Password = "123456" }
        };
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _users.FirstOrDefault(u => u.UserName == model.UserName);

            if (user == null || user.Password != model.Password)
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View(model);
            }

            HttpContext.Session.SetString("Username", model.UserName);

            return RedirectToAction("Dashboard");

        }

        public IActionResult Dashboard()
        {
            var username = HttpContext.Session.GetString("Username");

            if (username == null)
                return RedirectToAction("Login");

            ViewData["Username"] = username;
            return View();

        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Login");
        }
    }
}
