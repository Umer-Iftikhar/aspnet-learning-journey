namespace BookLibrary.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalCategories { get; set; }
        public string MostPopularCategory { get; set; }
        public int TotalBooks { get; set; }
        public string NewestAddedBook { get; set; }
        public decimal AverageBooksPerCategory { get; set; }
    }
}