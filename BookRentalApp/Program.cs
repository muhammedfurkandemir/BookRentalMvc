using BookRentalApp.Models;
using BookRentalApp.Utilities.Helpers.FileHelper;
using BookRentalApp.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Veritabanı için RentalBookContext classının istenilen yerde new lenelerek dependency injection ile .net core yapısında verilmesilmesini sağlar.
builder.Services.AddDbContext<RentalBookContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<RentalBookContext>();

builder.Services.AddRazorPages();
//istediğimiz yapının dependency injection ile newlenmesi için kullanılır.
builder.Services.AddScoped<IBookTypeRepository, BookTypeRepository>();

builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddScoped<IFileHelper,FileHelper>();

builder.Services.AddScoped<IRentalRepository, RentalRepository>();

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

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
