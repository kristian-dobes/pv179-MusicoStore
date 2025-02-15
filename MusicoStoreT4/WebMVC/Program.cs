using BusinessLayer.Cache;
using BusinessLayer.Cache.Interfaces;
using BusinessLayer.Facades;
using BusinessLayer.Facades.Interfaces;
using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Implementations;
using Infrastructure.Repository.Implementations.Implementations;
using Infrastructure.Repository.Interfaces;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Presentations.Shared.Middlewares;
using System.Globalization;
using WebMVC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<AuditSaveChangesInterceptor>();

var databaseName = builder.Configuration["DatabaseName"];

var folder = Environment.SpecialFolder.LocalApplicationData;
var dbPath = Path.Join(Environment.GetFolderPath(folder), databaseName);
string imagesFolder = Path.Combine(Path.GetDirectoryName(dbPath) ?? string.Empty, "ProductImages");

if (!Directory.Exists(imagesFolder))
{
    Directory.CreateDirectory(imagesFolder);
}

// Register DbContext
builder.Services.AddDbContext<MyDBContext>(options =>
{
    var auditInterceptor = builder.Services.BuildServiceProvider().GetRequiredService<AuditSaveChangesInterceptor>();
    
    options
        .UseSqlite($"Data Source={dbPath}", x => x.MigrationsAssembly("DAL.SQLite.Migrations"))
        .LogTo(s => System.Diagnostics.Debug.WriteLine(s))
        .UseLazyLoadingProxies()
        .AddInterceptors(auditInterceptor)
        ;
});

new MapsterConfig().RegisterMappings();

// Register Identity
builder
    .Services.AddIdentity<LocalIdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<MyDBContext>()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton(imagesFolder);

// Add session services
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Adjust as needed
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Register Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IAuditLogRepository, AuditLogRepository>();
builder.Services.AddScoped<ILogRepository, LogRepository>();
builder.Services.AddScoped<ICouponCodeRepository, CouponCodeRepository>();
builder.Services.AddScoped<IGiftCardRepository, GiftCardRepository>();

// Register Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Register Services
builder.Services.AddScoped<IMemoryCacheWrapper, MemoryCacheWrapper>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuditLogService, AuditLogService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IManufacturerService, ManufacturerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ILogService, LogService>();
builder.Services.AddScoped<IGiftCardService, GiftCardService>();
builder.Services.AddScoped<IImageService>(provider =>
{
    var uow = provider.GetRequiredService<IUnitOfWork>();
    var imagesPath = imagesFolder;
    return new ImageService(uow, imagesPath);
});

// Register Facades
builder.Services.AddScoped<IManufacturerFacade, ManufacturerFacade>();
builder.Services.AddScoped<IAuthFacade, AuthFacade>();

// Register Mapster mappings
new MapsterConfig().RegisterMappings();

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

// Set the default culture to en-US (for Dollars) 
var defaultCulture = new CultureInfo("en-US"); // Can be changed to "fr-FR" for Euros (any other culture)
CultureInfo.DefaultThreadCurrentCulture = defaultCulture;
CultureInfo.DefaultThreadCurrentUICulture = defaultCulture;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseMiddleware<RequestLoggingMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Add session middleware
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name: "default", 
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    await SeedRoles(scope.ServiceProvider);
}

app.Run();

// Seed Roles for Identity
async Task SeedRoles(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    if (!await roleManager.RoleExistsAsync("User"))
    {
        await roleManager.CreateAsync(new IdentityRole("User"));
    }
}
