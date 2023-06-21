using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StarWars.Characters.Data;
using StarWars.Characters.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StarWarsCharactersContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StarWarsCharactersContext") ?? throw new InvalidOperationException("Connection string 'StarWarsCharactersContext' not found.")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
