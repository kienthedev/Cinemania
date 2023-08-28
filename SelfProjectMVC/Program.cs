using SelfProjectDataAccess.Interfaces;
using SelfProjectDataAccess.Models;
using SelfProjectDataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(SelfProjectContext));
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<SelfProjectContext>();
builder.Services.AddSession();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "genre-name",
    pattern: "genre/{genrename}",
    defaults: new { controller = "Genres", action = "Details"});

app.MapControllerRoute(
    name: "movie-name",
    pattern: "{moviename}",
    defaults: new { controller = "Movies", action = "Details" });

app.MapControllerRoute(
    name: "detail-movie",
    pattern: "{controller=Movies}/{action=Details}/{id}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
