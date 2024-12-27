using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RunGroupMVC_teddy.Data;
using RunGroupMVC_teddy.Helpers;
using RunGroupMVC_teddy.Interfaces;
using RunGroupMVC_teddy.Models;
using RunGroupMVC_teddy.Repository;
using RunGroupMVC_teddy.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IClubRepository,ClubRepository>();
builder.Services.AddScoped<IRaceRepository,RaceRepository>();
builder.Services.AddScoped<IDashboardRepository,DashboardRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IPhotoService,PhotoService>();
builder.Services.Configure<ClaudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();//cookie authentification
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
 .AddCookie();


var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
 await Seed.SeedUsersAndRolesAsync(app);
 //Seed.SeedData(app);
} 

if (!app.Environment.IsDevelopment())
{
 app.UseExceptionHandler("/Home/Error");
 app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
