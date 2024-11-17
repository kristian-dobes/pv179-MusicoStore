using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<RequestLoggingMiddleware>(); // Logging middleware
app.UseMiddleware<TokenAuthenticationMiddleware>(); // Token authentication middleware

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseMiddleware<JsonToXmlMiddleware>();

app.MapControllers();
app.Run();
