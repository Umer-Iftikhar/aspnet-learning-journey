namespace BlogApp.ViewModels
{
    public class PostIndexViewModel
    {
        public List<PostListViewModel> Posts { get; set; } = new List<PostListViewModel>();
        public string SearchQuery { get; set; } = string.Empty;
        public string SortOrder { get; set; } = string.Empty;
    }
}
