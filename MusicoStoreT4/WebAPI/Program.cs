using BusinessLayer.Services;
using BusinessLayer.Facades;
using BusinessLayer.Facades.Interfaces;
using DataAccessLayer.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebAPI.Middlewares;
using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;

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

builder.Services.AddDbContextFactory<MyDBContext>(options =>
{
    var folder = Environment.SpecialFolder.LocalApplicationData;
    var dbPath = Path.Join(Environment.GetFolderPath(folder), "MusicoStore.db");

    options
        .UseSqlite(
            $"Data Source={dbPath}",
            x => x.MigrationsAssembly("DAL.SQLite.Migrations")
        )
        .LogTo(s => System.Diagnostics.Debug.WriteLine(s))
        .UseLazyLoadingProxies()
        ;
});

builder.Services.AddScoped<IUserService, UserService>();

// Register Services
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IManufacturerService, ManufacturerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IManufacturerFacade, ManufacturerFacade>();

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
