using Microsoft.EntityFrameworkCore;
using Project_BerrrasBio.Models;
using Microsoft.Extensions.DependencyInjection;
using Project_BerrrasBio.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Project_BerrrasBioContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("Project_BerrrasBioContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();


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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Homepage}/{action=Index}/{id?}");

app.Run();
