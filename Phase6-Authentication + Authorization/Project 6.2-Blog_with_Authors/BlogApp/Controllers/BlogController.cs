using BlogApp.Data;
using BlogApp.Models;
using BlogApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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
                    CreatedDate = p.CreatedDate,
                    AuthorId = p.AuthorId
                }
                ).ToList(),
                SearchQuery = searchQuery ?? string.Empty,
                SortOrder = sortOrder ?? "newest"
            };
            return View(viewModel);
        }
        [Authorize]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(PostFormViewModel vmodel)
        {
            if(!ModelState.IsValid)
            {
                return View(vmodel);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            var newPost = new Post { 
                AuthorId = userId,
                AuthorName = User.Identity?.Name ?? "Unknown",
                Content = vmodel.Content, 
                Title = vmodel.Title, 
                CreatedDate = DateTime.UtcNow 
            };
            _context.Posts.Add(newPost);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var detailPost = await _context.Posts.FindAsync(id);
            if (detailPost == null)
            {
                return NotFound();
            }
           
            return View(detailPost);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var editPost = await _context.Posts.FindAsync(id);
            if(editPost == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (editPost.AuthorId != userId)
            {
                return Forbid();
            }

            var editViewModel = new PostFormViewModel { Id = editPost.Id, Title = editPost.Title, Content = editPost.Content };
            return View(editViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PostFormViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var editPost = await _context.Posts.FindAsync(viewModel.Id);
            if (editPost == null)
            {
                return NotFound();
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (editPost.AuthorId != userId)
            {
                return Forbid();
            }
            editPost.Title = viewModel.Title;
            editPost.Content = viewModel.Content;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletePost = await _context.Posts.FindAsync(id);
            if(deletePost == null)
            {
                return NotFound();
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (deletePost.AuthorId != userId)
            {
                return Forbid();
            }
            _context.Posts.Remove(deletePost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}