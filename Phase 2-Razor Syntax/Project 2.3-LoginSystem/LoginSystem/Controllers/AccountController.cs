using LoginSystem.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
