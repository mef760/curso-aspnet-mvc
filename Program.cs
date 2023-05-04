using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcCars.Data;
using MvcCars.Models;
using MvcCars.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CarContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CarContext") ?? throw new InvalidOperationException("Connection string 'CarContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<CarContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<CarService<Car>>();
builder.Services.AddScoped<CarService<Marca>>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
