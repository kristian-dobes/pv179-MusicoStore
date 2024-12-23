using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.Services.Interfaces;
using BusinessLayer.Services;
using BusinessLayer.Facades.Interfaces;
using BusinessLayer.Facades;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var databaseName = builder.Configuration["DatabaseName"];

var folder = Environment.SpecialFolder.LocalApplicationData;
var dbPath = Path.Join(Environment.GetFolderPath(folder), databaseName);
string imagesFolder = Path.Combine(Path.GetDirectoryName(dbPath) ?? string.Empty, "ProductImages");

if (!Directory.Exists(imagesFolder))
{
    Directory.CreateDirectory(imagesFolder);
}

builder.Services.AddScoped<AuditSaveChangesInterceptor>();

// Register DbContext
builder.Services.AddDbContext<MyDBContext>((serviceProvider, options) =>
{
    var auditInterceptor = serviceProvider.GetRequiredService<AuditSaveChangesInterceptor>();
    options
        .UseSqlite($"Data Source={dbPath}", x => x.MigrationsAssembly("DAL.SQLite.Migrations"))
        .LogTo(s => System.Diagnostics.Debug.WriteLine(s))
        .UseLazyLoadingProxies()
        .AddInterceptors(auditInterceptor);
});

// Register Identity
builder.Services.AddIdentity<LocalIdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<MyDBContext>()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton(imagesFolder);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuditLogService, AuditLogService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IManufacturerService, ManufacturerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IImageService>(provider =>
{
    var dbContext = provider.GetRequiredService<MyDBContext>();
    var imagesPath = imagesFolder;
    return new ImageService(dbContext, imagesPath);
});
builder.Services.AddScoped<IManufacturerFacade, ManufacturerFacade>();
builder.Services.AddScoped<ILogService, LogService>();

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