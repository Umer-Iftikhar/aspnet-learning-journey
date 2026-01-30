using BookLibrary.Models;
using BookLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    public class DashboardController : Controller
    {
        // Access the same books list from BooksController
        private static List<Book> books = BooksController.Books;

        public IActionResult Index()
        {
            // 1. Total Books (simple)
            int totalBooks = books.Count;  // This is just .Count property, not LINQ

            // 2. Total Categories - use basic approach
            int totalCategories = books.Select(b => b.Genre).Distinct().Count();

            // 3. Most Popular Category s
            string mostPopularCategory = "None";
            int maxCount = 0;

            if (books == null || books.Count == 0)
            {
                mostPopularCategory = "No books yet";
            }
            else
            {
                for (int i = 0; i < books.Count; i++)
                {
                    string currentCategory = books[i].Genre;
                    int currentCount = 0;

                    // Count how many times this category appears
                    for (int j = 0; j < books.Count; j++)
                    {
                        if (books[j].Genre == currentCategory)
                        {
                            currentCount++;
                        }
                    }

                    // Update the global "Winner" if this count is higher
                    if (currentCount > maxCount)
                    {
                        maxCount = currentCount;
                        mostPopularCategory = currentCategory;
                    }
                }
            }

            // 4. Newest Book - just get last item
            string newestAddedBook = books.Count > 0 ? books[books.Count - 1].Title : "No books yet";

            // 5. Average - simple division
            decimal averageBooksPerCategory = totalCategories > 0? (decimal)totalBooks / totalCategories: 0;

            var viewModel = new DashboardViewModel
            {
                TotalCategories = totalCategories,
                MostPopularCategory = mostPopularCategory,
                TotalBooks = totalBooks,
                NewestAddedBook = newestAddedBook,
                AverageBooksPerCategory = averageBooksPerCategory
            };

            return View(viewModel);
        }
    }
}