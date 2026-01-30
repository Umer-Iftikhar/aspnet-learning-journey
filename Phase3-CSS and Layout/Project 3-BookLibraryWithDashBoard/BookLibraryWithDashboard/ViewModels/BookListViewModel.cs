using BookLibrary.Models;

namespace BookLibrary.ViewModels
{
    public class BookListViewModel
    {
        public List<Book> Books { get; set; }
        public List<string> Genres { get; set; }
        public string? SelectedGenre { get; set; }
    }
}
