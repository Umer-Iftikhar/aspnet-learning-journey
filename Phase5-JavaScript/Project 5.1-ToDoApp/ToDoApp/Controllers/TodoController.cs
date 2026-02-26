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
            //var debugConn = _context.Database.GetConnectionString();
            var records = await _context.TodoItems.ToListAsync();
            return View(records);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string taskDescription)
        {
            if (string.IsNullOrWhiteSpace(taskDescription))
            {
                return RedirectToAction("Index");
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
        [HttpPost]
        public async Task<IActionResult> ToggleCompletion(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item != null)
            {
                item.IsCompleted = !item.IsCompleted;
                await _context.SaveChangesAsync();
            }
            else
            {
                return Json(new { success = false, message = "Item not found" });
            }
            return Json(new{ success = true, message = "Status updated" });

        }

        [HttpPost]
        public async Task<IActionResult> ClearAll()
        {
            var allItems =await _context.TodoItems.ToListAsync();
            _context.TodoItems.RemoveRange(allItems);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
     }
}
