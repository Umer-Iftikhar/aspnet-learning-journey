using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ToDoApp.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<TestItem> TestItems { get; set; }
}