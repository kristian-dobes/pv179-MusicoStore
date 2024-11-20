using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var databaseName = builder.Configuration["DatabaseName"];

builder.Services.AddDbContext<MyDBContext>(options =>
{
    var folder = Environment.SpecialFolder.LocalApplicationData;
    var dbPath = Path.Join(Environment.GetFolderPath(folder), databaseName);

    options
        .UseSqlite($"Data Source={dbPath}", x => x.MigrationsAssembly("DAL.SQLite.Migrations"))
        .LogTo(s => System.Diagnostics.Debug.WriteLine(s))
        .UseLazyLoadingProxies();
});

builder.Services.AddIdentity<LocalIdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<MyDBContext>()
                .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
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