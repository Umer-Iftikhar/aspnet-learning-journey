using Microsoft.AspNetCore.Identity;

namespace AuthSystem.Models
{
    public class ApplicationUser : Microsoft.AspNetCore.Identity.IdentityUser
    {
        public string? FullName { get; set; }
    }
}
