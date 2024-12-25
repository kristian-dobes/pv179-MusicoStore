using BusinessLayer.Services;
using BusinessLayer.Facades;
using BusinessLayer.Facades.Interfaces;
using DataAccessLayer.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebAPI.Middlewares;
using BusinessLayer.Services.Interfaces;
using Infrastructure.Repository.Interfaces;
using Infrastructure.Repository;
using Infrastructure.UnitOfWork;
using Infrastructure.Repository.Implementations;
using Infrastructure.Repository.Implementations.Implementations;
using Mapster;
using BusinessLayer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("https://localhost:7256", "https://localhost:5270")  // Web MVC origin (https and http) 
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Configure Swagger to accept a static token
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Enter the API key as follows: Bearer YourHardcodedToken",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddScoped<AuditSaveChangesInterceptor>();

var databaseName = builder.Configuration["DatabaseName"];
var folder = Environment.SpecialFolder.LocalApplicationData;
var dbPath = Path.Join(Environment.GetFolderPath(folder), databaseName);
string imagesFolder = Path.Combine(Path.GetDirectoryName(dbPath) ?? string.Empty, "ProductImages");

builder.Services.AddDbContextFactory<MyDBContext>(options =>
{
    var auditInterceptor = builder.Services.BuildServiceProvider().GetRequiredService<AuditSaveChangesInterceptor>();

    options
        .UseSqlite(
            $"Data Source={dbPath}",
            x => x.MigrationsAssembly("DAL.SQLite.Migrations")
        )
        .LogTo(s => System.Diagnostics.Debug.WriteLine(s))
        .UseLazyLoadingProxies()
        .AddInterceptors(auditInterceptor)
        ;
});

builder.Services.AddScoped<IUserService, UserService>();

// Register Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IAuditLogRepository, AuditLogRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ILogRepository, LogRepository>();

// Register Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Register Services
builder.Services.AddScoped<IAuditLogService, AuditLogService>();
builder.Services.AddScoped<IImageService>(provider =>
{
    var uow = provider.GetRequiredService<IUnitOfWork>();
    var imagesPath = imagesFolder;
    return new ImageService(uow, imagesPath);
});
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IManufacturerService, ManufacturerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IManufacturerFacade, ManufacturerFacade>();
builder.Services.AddScoped<ILogService, LogService>();

// Mapster Mapping configuration for using DTOs
new MappingConfig().RegisterMappings();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use((context, next) =>
{
    var allowedOrigins = new[] { "http://localhost:5270", "https://localhost:7256" };

    var origin = context.Request.Headers["Origin"].ToString();

    if (allowedOrigins.Contains(origin))
    {
        context.Response.Headers["Access-Control-Allow-Origin"] = origin;
        context.Response.Headers["Access-Control-Allow-Methods"] = "OPTIONS, GET, POST, PUT, PATCH, DELETE";
        context.Response.Headers["Access-Control-Allow-Headers"] = "Content-Type, Authorization";
    }

    if (context.Request.Method == "OPTIONS")
    {
        context.Response.StatusCode = 200; // Respond to OPTIONS preflight request
        return Task.CompletedTask;
    }

    return next();
});

app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<TokenAuthenticationMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowSpecificOrigin");

app.UseMiddleware<JsonToXmlMiddleware>();

app.MapControllers();
app.Run();
