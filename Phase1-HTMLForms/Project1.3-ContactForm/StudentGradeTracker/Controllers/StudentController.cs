using Microsoft.AspNetCore.Mvc;
using StudentGradeTracker.Models;

namespace StudentGradeTracker.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>();
        static StudentController()
        {
            students.Add(new Student { Name = "Umer", Id = 1, Grade = 80 });
            students.Add(new Student { Name = "Ali", Id = 2, Grade = 60 });
            students.Add(new Student { Name = "Ahsan", Id = 3, Grade = 48 });
        }
        public IActionResult Index()
        {
            return View(students);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Student student)
        {
            if (!ModelState.IsValid)  
            {
                return View(student);  
            }

            student.Id = students.Max(s => s.Id) + 1;
            students.Add(student);
            return RedirectToAction("Index");
        }
    }
}
