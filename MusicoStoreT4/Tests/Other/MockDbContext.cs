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
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Clothing" },
                new Category { Id = 3, Name = "Books" }
            };
        }

        private static List<Manufacturer> GenerateMockManufacturers()
        {
            return new List<Manufacturer>
            {
                new Manufacturer { Id = 1, Name = "Sony" },
                new Manufacturer { Id = 2, Name = "Nike" },
                new Manufacturer { Id = 3, Name = "Penguin Books" }
            };
        }

        private static List<Product> GenerateMockProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    Description = "A powerful laptop",
                    Price = 999.99m,
                    QuantityInStock = 10,
                    CategoryId = 1,
                    ManufacturerId = 1,
                    LastModifiedBy = "admin",
                    EditCount = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "T-shirt",
                    Description = "Comfortable cotton t-shirt",
                    Price = 19.99m,
                    QuantityInStock = 50,
                    CategoryId = 2,
                    ManufacturerId = 2,
                    LastModifiedBy = "admin",
                    EditCount = 1
                },
                new Product
                {
                    Id = 3,
                    Name = "Book Title",
                    Description = "A bestselling book",
                    Price = 14.99m,
                    QuantityInStock = 100,
                    CategoryId = 3,
                    ManufacturerId = 3,
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
                new Order { Id = 2, UserId = 2, Date = DateTime.Now.AddDays(-1) }
            };
        }

        private static List<OrderItem> GenerateMockOrderItems()
        {
            return new List<OrderItem>
            {
                new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1, Price = 999.99m },
                new OrderItem { Id = 2, OrderId = 1, ProductId = 2, Quantity = 2, Price = 19.99m },
                new OrderItem { Id = 3, OrderId = 2, ProductId = 3, Quantity = 3, Price = 14.99m }
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
                }
            };
        }
    }
}
