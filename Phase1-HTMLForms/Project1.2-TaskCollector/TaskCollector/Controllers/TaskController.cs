using Microsoft.AspNetCore.Mvc;

namespace TaskCollector.Controllers
{
    public class TaskController : Controller
    {
        static List<string> tasks = new List<string>();
        public IActionResult Index()
        {
            ViewBag.Tasks = tasks;
            return View();
        }
        [HttpPost]
        public IActionResult Add(string task)
        {
            tasks.Add(task);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult ClearAll()
        {
            tasks.Clear();
            return RedirectToAction("Index");
        }
    }
}
