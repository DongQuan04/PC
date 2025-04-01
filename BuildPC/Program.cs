using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BuildPC.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using BuildPC.Services;
using BuildPC.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//initialize premade data into db
builder.Services.AddScoped<ApplicationDbContextInitializer>();
builder.Services.AddScoped<PcCompatibilityService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbInitializer = services.GetRequiredService<ApplicationDbContextInitializer>();
    await dbInitializer.SeedAsync(); // Run seeding logic
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
