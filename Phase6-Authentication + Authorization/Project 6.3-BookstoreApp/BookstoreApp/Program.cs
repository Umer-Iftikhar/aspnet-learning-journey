using Microsoft.AspNetCore.Identity;
using BookstoreApp.Data;
using Microsoft.EntityFrameworkCore;
using BookstoreApp.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("Default")
    ?? throw new InvalidOperationException("Connection string 'Default' not found.");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));

builder.Services.AddDbContext<ApplicationDbContext>(options =>     options.UseMySql(connectionString, serverVersion));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
if (!await roleManager.RoleExistsAsync("Admin"))
{
    await roleManager.CreateAsync(new IdentityRole("Admin"));
}
var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
var adminUser = await userManager.FindByEmailAsync("admin123@gmail.com");

if (adminUser == null)
{
    var newAdmin = new ApplicationUser
    {
        UserName = "admin123@gmail.com",
        Email = "admin123@gmail.com"
    };
    var result = await userManager.CreateAsync(newAdmin, "Admin@123");
    if (result.Succeeded)
    {
        await userManager.AddToRoleAsync(newAdmin, "Admin");
    }
}





// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
