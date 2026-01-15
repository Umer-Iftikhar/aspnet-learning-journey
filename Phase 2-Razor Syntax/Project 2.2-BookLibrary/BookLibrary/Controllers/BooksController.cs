using Microsoft.AspNetCore.Mvc;
using BookLibrary.Models;
using BookLibrary.ViewModels;

namespace BookLibrary.Controllers
{
    public class BooksController : Controller
    {
        public static List<Book> book = new List<Book>
        {
            new Book { Id = 1, Title = "1984", Author = "George Orwell", Year = 1949, Genre = "Fiction" },
            new Book { Id = 2, Title = "A Brief History of Time", Author = "Stephen Hawking", Year = 1988, Genre = "Science" },
            new Book { Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Year = 1925, Genre = "Fiction" },
            new Book { Id = 4, Title = "Silent Spring", Author = "Rachel Carson", Year = 1962, Genre = "Science" },
            new Book { Id = 5, Title = "Brave New World", Author = "Aldous Huxley", Year = 1932, Genre = "Fiction" },
            new Book { Id = 6, Title = "The Elegant Universe", Author = "Brian Greene", Year = 1999, Genre = "Science" },
            new Book {Id = 7, Title = "Sapiens", Author = "Yuval Noah Harari", Year = 2011, Genre = "History"},
            new Book {Id = 8, Title = "Guns, Germs, and Steel", Author = "Jared Diamond", Year = 1997, Genre = "History"},
            new Book {Id = 9, Title = "Long Walk to Freedom", Year = 1994, Genre = "Biography"},
            new Book {Id = 10, Title = "The Diary of a Young Girl", Author = "Anne Frank", Year = 1947, Genre = "Biography"},
            new Book {Id = 11, Title = "The Republic", Author = "Plato", Genre = "Philosophy"},
            new Book {Id = 12, Title = "Beyond Good and Evil" , Author = "Friedrich Nietzsche", Year = 1886, Genre = "Philosophy"},
            new Book {Id = 13, Title = "Atomic Habits", Author = "James Clear", Year = 2018, Genre = "Self-Help"},
            new Book {Id = 14, Title = "How to Win Friends and Influence People", Author = "Dale Carnegie", Year = 1936, Genre = "Self-Help"},
            new Book {Id = 15, Title = "The Hound of the Baskervilles", Author = "Arthur Conan Doyle", Year = 1902, Genre = "Mystery"},
            new Book {Id = 16, Title = "And Then There Were None", Author = "Agatha Christie", Year = 1939, Genre = "Mystery"},
            new Book {Id = 17, Title = "Onepiece", Author = "Eichiro Oda", Year = 1997, Genre = "Adventure"}
        };
        public IActionResult Index()
        {
            return View();
        }
    }
}
