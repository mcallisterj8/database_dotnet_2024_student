using Microsoft.EntityFrameworkCore;
using VanillaMvcApp.Data;
using VanillaMvcApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add database to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add seeding service to container
builder.Services.AddScoped<SeedingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

/*
    Create a scope with CreateScope() so we can retrieve a service instance.
    The "using" keyword ensures that the scope object is 
    disposed of properly when it goes out of scope.
*/
using var scope = app.Services.CreateScope();
// Retrieve a SeedingService instance.
var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
// Call the SeedDatabase() method so that we can seed the database.
seedingService.SeedDatabase();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
