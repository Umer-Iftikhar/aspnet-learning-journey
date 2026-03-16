namespace BookstoreApp.Models
{
    public class ApplicationUser : Microsoft.AspNetCore.Identity.IdentityUser
    {
        public string? FullName { get; set; }
    }
}
