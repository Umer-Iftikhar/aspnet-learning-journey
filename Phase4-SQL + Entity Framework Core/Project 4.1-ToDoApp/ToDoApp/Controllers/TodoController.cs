using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly AppDbContext _context;

        public TodoController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var records = await _context.TodoItems.ToListAsync();
            return View(records);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string taskDescription)
        {
            if (string.IsNullOrWhiteSpace(taskDescription))
            {
                return BadRequest("Task description cannot be empty.");
            }
            var newItem = new TodoItem
            {
                TaskDescription = taskDescription,
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow
            };
            _context.TodoItems.Add(newItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }




     }
}
