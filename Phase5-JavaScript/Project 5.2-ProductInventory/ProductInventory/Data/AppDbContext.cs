using Microsoft.EntityFrameworkCore;
using ProductInventory.Models;
using System.Collections.Generic;

namespace ProductInventory.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                        .HasOne(p => p.Category)          // Product has ONE Category
                        .WithMany(c => c.Products)        // Category has MANY Products
                        .HasForeignKey(p => p.CategoryId) 
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
    
}
