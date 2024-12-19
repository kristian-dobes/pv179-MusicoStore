using DataAccessLayer.Models.Enums;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Data;

namespace Tests.Other
{
    public static class MockDbContext
    {
        private static string DbName = Guid.NewGuid().ToString();

        public static MyDBContext GenerateMock()
        {
            var dbContextOptions =
                new DbContextOptionsBuilder<MyDBContext>()
                    .UseInMemoryDatabase(databaseName: DbName)
                    .UseLazyLoadingProxies()
                    .UseInternalServiceProvider(
                        new ServiceCollection()
                            .AddEntityFrameworkProxies()
                            .AddEntityFrameworkInMemoryDatabase()
                            .BuildServiceProvider()
                    ).Options;

            var dbContext = new MyDBContext(dbContextOptions);

            dbContext.Categories.AddRange(GenerateMockCategories());
            dbContext.Manufacturers.AddRange(GenerateMockManufacturers());
            dbContext.Products.AddRange(GenerateMockProducts());
            dbContext.Users.AddRange(GenerateMockUsers());
            dbContext.Orders.AddRange(GenerateMockOrders());
            dbContext.OrderItems.AddRange(GenerateMockOrderItems());
            dbContext.Customers.AddRange(GenerateMockCustomers());

            dbContext.SaveChanges();

            return dbContext;
        }

        private static List<Category> GenerateMockCategories()
        {
            return new List<Category>
            {
                new Category { Id = 1, Name = "Guitars" },
                new Category { Id = 2, Name = "Drums" },
                new Category { Id = 3, Name = "Keyboards" },
                new Category { Id = 4, Name = "Accessories" }
            };
        }

        private static List<Manufacturer> GenerateMockManufacturers()
        {
            return new List<Manufacturer>
            {
                new Manufacturer { Id = 1, Name = "Fender" },
                new Manufacturer { Id = 2, Name = "Gibson" },
                new Manufacturer { Id = 3, Name = "Yamaha" },
                new Manufacturer { Id = 4, Name = "Pearl" },
                new Manufacturer { Id = 5, Name = "Roland" }
            };
        }

        private static List<Product> GenerateMockProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Fender Stratocaster",
                    Description = "Classic electric guitar with a bright tone",
                    Price = 699.99m,
                    QuantityInStock = 15,
                    CategoryId = 1,
                    ManufacturerId = 1,
                    LastModifiedBy = "admin",
                    EditCount = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Gibson Les Paul",
                    Description = "Iconic electric guitar known for its rich, warm sound",
                    Price = 1199.99m,
                    QuantityInStock = 10,
                    CategoryId = 1,
                    ManufacturerId = 2,
                    LastModifiedBy = "admin",
                    EditCount = 1
                },
                new Product
                {
                    Id = 3,
                    Name = "Yamaha Acoustic Drum Kit",
                    Description = "Full set of acoustic drums with cymbals",
                    Price = 599.99m,
                    QuantityInStock = 8,
                    CategoryId = 2,
                    ManufacturerId = 3,
                    LastModifiedBy = "admin",
                    EditCount = 1
                },
                new Product
                {
                    Id = 4,
                    Name = "Roland Digital Piano",
                    Description = "High-quality digital piano with realistic feel",
                    Price = 799.99m,
                    QuantityInStock = 12,
                    CategoryId = 3,
                    ManufacturerId = 5,
                    LastModifiedBy = "admin",
                    EditCount = 1
                },
                new Product
                {
                    Id = 5,
                    Name = "Pearl Drumsticks",
                    Description = "High-quality drumsticks for professional drummers",
                    Price = 14.99m,
                    QuantityInStock = 200,
                    CategoryId = 4,
                    ManufacturerId = 4,
                    LastModifiedBy = "admin",
                    EditCount = 1
                }
            };
        }

        private static List<User> GenerateMockUsers()
        {
            return new List<User>
            {
                new User
                {
                    Id = 1,
                    Username = "john_doe",
                    Email = "john.doe@example.com",
                    Role = Role.Customer
                },
                new User
                {
                    Id = 2,
                    Username = "jane_smith",
                    Email = "jane.smith@example.com",
                    Role = Role.Admin
                }
            };
        }

        private static List<Order> GenerateMockOrders()
        {
            return new List<Order>
            {
                new Order { Id = 1, UserId = 1, Date = DateTime.Now },
                new Order { Id = 2, UserId = 2, Date = DateTime.Now.AddDays(-1) },
                new Order { Id = 3, UserId = 3, Date = DateTime.Now.AddDays(-2) },
                new Order { Id = 4, UserId = 4, Date = DateTime.Now.AddDays(-3) }
            };
        }

        private static List<OrderItem> GenerateMockOrderItems()
        {
            return new List<OrderItem>
            {
                new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1, Price = 699.99m },  // Fender Stratocaster
                new OrderItem { Id = 2, OrderId = 1, ProductId = 2, Quantity = 1, Price = 1199.99m }, // Gibson Les Paul
                new OrderItem { Id = 3, OrderId = 2, ProductId = 3, Quantity = 2, Price = 599.99m }, // Yamaha Acoustic Drum Kit
                new OrderItem { Id = 4, OrderId = 3, ProductId = 4, Quantity = 1, Price = 799.99m }, // Roland Digital Piano
                new OrderItem { Id = 5, OrderId = 3, ProductId = 5, Quantity = 3, Price = 14.99m },  // Pearl Drumsticks
                new OrderItem { Id = 6, OrderId = 4, ProductId = 1, Quantity = 2, Price = 699.99m },  // Fender Stratocaster
                new OrderItem { Id = 7, OrderId = 4, ProductId = 2, Quantity = 1, Price = 1199.99m }, // Gibson Les Paul
                new OrderItem { Id = 8, OrderId = 4, ProductId = 3, Quantity = 1, Price = 599.99m },  // Yamaha Acoustic Drum Kit
            };
        }

        private static List<Customer> GenerateMockCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    Id = 3,
                    Username = "john_doe",
                    Email = "john.doe@example.com",
                    PhoneNumber = "123-456-789",
                    Address = "123 Main St",
                    City = "Bratislava",
                    State = "Bratislava",
                    PostalCode = "811 04",
                    Role = Role.Customer
                },
                new Customer
                {
                    Id = 4,
                    Username = "jane_smith",
                    Email = "jane.smith@example.com",
                    PhoneNumber = "987-654-321",
                    Address = "456 Elm St",
                    City = "Košice",
                    State = "Košice",
                    PostalCode = "040 01",
                    Role = Role.Customer
                },
                new Customer
                {
                    Id = 5,
                    Username = "michael_jones",
                    Email = "michael.jones@example.com",
                    PhoneNumber = "111-222-333",
                    Address = "789 Oak St",
                    City = "Nitra",
                    State = "Nitra",
                    PostalCode = "950 01",
                    Role = Role.Customer
                },
                new Customer
                {
                    Id = 6,
                    Username = "emily_clark",
                    Email = "emily.clark@example.com",
                    PhoneNumber = "444-555-666",
                    Address = "101 Pine St",
                    City = "Trnava",
                    State = "Trnava",
                    PostalCode = "917 01",
                    Role = Role.Customer
                },
                new Customer
                {
                    Id = 7,
                    Username = "lucas_king",
                    Email = "lucas.king@example.com",
                    PhoneNumber = "777-888-999",
                    Address = "202 Maple St",
                    City = "Prešov",
                    State = "Prešov",
                    PostalCode = "080 01",
                    Role = Role.Customer
                },
                new Customer
                {
                    Id = 8,
                    Username = "sophia_white",
                    Email = "sophia.white@example.com",
                    PhoneNumber = "888-999-000",
                    Address = "303 Birch St",
                    City = "Žilina",
                    State = "Žilina",
                    PostalCode = "010 01",
                    Role = Role.Customer
                },
                new Customer
                {
                    Id = 9,
                    Username = "jack_martin",
                    Email = "jack.martin@example.com",
                    PhoneNumber = "555-666-777",
                    Address = "404 Cedar St",
                    City = "Martin",
                    State = "Martin",
                    PostalCode = "036 01",
                    Role = Role.Customer
                }
            };
        }
    }
}
