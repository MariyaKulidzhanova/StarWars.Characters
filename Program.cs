using Microsoft.EntityFrameworkCore;
using StarWars.Characters.Data;
using StarWars.Characters.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StarWarsCharactersContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StarWarsCharactersContext")));

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
    pattern: "{controller=Characters}/{action=Index}/{id?}");

app.Run();
