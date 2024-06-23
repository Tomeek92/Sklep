using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sklep;
using Sklep.Models;
using Sklep.Service;
using Sklep.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAddShopList,AddShopListService>();


var connectionString = "Server=DESKTOP-JD2U15O\\MSSQL1;Database=Sklep;Integrated Security=True; TrustServerCertificate=true;";
builder.Services.AddDbContext<SklepDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    
})
.AddEntityFrameworkStores<SklepDbContext>()
.AddDefaultTokenProviders();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
});

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
