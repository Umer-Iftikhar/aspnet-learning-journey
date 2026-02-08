using BlogApp.Data;
using BlogApp.Models;
using BlogApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string searchQuery, string sortOrder)
        {
            var postsQuery = _context.Posts.AsQueryable();
            
            if(!string.IsNullOrWhiteSpace(searchQuery))
            {
                postsQuery = postsQuery.Where(p => p.Title.Contains(searchQuery));
            }

            if(sortOrder == "oldest")
            {
                postsQuery = postsQuery.OrderBy(p => p.CreatedDate);
            }
            else
            {
                postsQuery = postsQuery.OrderByDescending(p => p.CreatedDate);
            }

            var posts = await postsQuery.ToListAsync();

            var viewModel = new PostIndexViewModel
            {
                Posts = posts.Select(p => new PostListViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    ContentPreview = p.Content.Length > 100 ? p.Content.Substring(0, 100) + "...." : p.Content,
                    AuthorName = p.AuthorName,
                    CreatedDate = p.CreatedDate
                }
                ).ToList(),
                SearchQuery = searchQuery ?? string.Empty,
                SortOrder = sortOrder ?? "newest"
            };
            return View(viewModel);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostFormViewModel vmodel)
        {
            if(!ModelState.IsValid)
            {
                return View(vmodel);
            }
            var newPost = new Post { AuthorName = vmodel.AuthorName, Content = vmodel.Content, Title = vmodel.Title, CreatedDate = DateTime.UtcNow };
            _context.Posts.Add(newPost);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }
    }
}