namespace BlogApp.ViewModels
{
    public class PostListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ContentPreview { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
