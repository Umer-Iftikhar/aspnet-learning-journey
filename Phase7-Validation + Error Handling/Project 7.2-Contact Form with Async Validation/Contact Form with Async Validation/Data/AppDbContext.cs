using Microsoft.EntityFrameworkCore;
using Contact_Form_with_Async_Validation.Models;


namespace Contact_Form_with_Async_Validation.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ContactSubmission> ContactSubmissions { get; set; }
    }
}
