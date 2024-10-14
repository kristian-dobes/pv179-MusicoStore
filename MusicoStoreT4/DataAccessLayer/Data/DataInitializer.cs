using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public static class DataInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var orders = PrepareOrderModels();
            var products = PrepareProductModels();
            var orderItems = PrepareOrderItemsModels();
            var categories = PrepareCategoryModels();
            var manufacturers = PrepareManufacturerModels();

            modelBuilder.Entity<Order>().HasData(orders);
            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<OrderItem>().HasData(orderItems);
            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Manufacturer>().HasData(manufacturers);
        }

        private static List<Order> PrepareOrderModels()
        {
            return new List<Order>()
                {
                    new Order()
                    {
                        Id = 1,
                        Date = new DateTime(2024, 10, 1),
                    },
                    new Order()
                    {
                        Id = 2,
                        Date = new DateTime(2024, 11, 15),
                    },
                    new Order()
                    {
                        Id = 3,
                        Date = new DateTime(2024, 12, 5),
                    },
                    new Order()
                    {
                        Id = 4,
                        Date = new DateTime(2025, 1, 20),
                    },
                    new Order()
                    {
                        Id = 5,
                        Date = new DateTime(2025, 2, 10),
                    },
                };
        }

        private static List<Product> PrepareProductModels()
        {
            return new List<Product>()
    {
        new Product()
        {
            Id = 1,
            Name = "Microphone",
            Description = "Professional condenser microphone for studio recording",
            Price = 99.99m,
            QuantityInStock = 10,
            CategoryId = 3,
            ManufacturerId = 4
        },
        new Product()
        {
            Id = 2,
            Name = "DVD",
            Description = "Music concert DVD of popular artist",
            Price = 19.99m,
            QuantityInStock = 50,
            CategoryId = 1,
            ManufacturerId = 2
        },
        new Product()
        {
            Id = 3,
            Name = "Guitar",
            Description = "Acoustic guitar with solid spruce top",
            Price = 299.99m,
            QuantityInStock = 5,
            CategoryId = 3,
            ManufacturerId = 1
        },
        new Product()
        {
            Id = 4,
            Name = "Keyboard",
            Description = "Digital keyboard with weighted keys",
            Price = 499.99m,
            QuantityInStock = 3,
            CategoryId = 2,
            ManufacturerId = 3
        },
        new Product()
        {
            Id = 5,
            Name = "Drum Set",
            Description = "5-piece drum set with cymbals and hardware",
            Price = 699.99m,
            QuantityInStock = 2,
            CategoryId = 3,
            ManufacturerId = 1
        },
        new Product()
        {
            Id = 6,
            Name = "Microphone Stand",
            Description = "Adjustable microphone stand with boom arm",
            Price = 29.99m,
            QuantityInStock = 20,
            CategoryId = 1,
            ManufacturerId = 1
        },
        new Product()
        {
            Id = 7,
            Name = "Bass Guitar",
            Description = "Electric bass guitar with active pickups",
            Price = 399.99m,
            QuantityInStock = 8,
            CategoryId = 3,
            ManufacturerId = 4
        },
        new Product()
        {
            Id = 8,
            Name = "Piano",
            Description = "Digital piano with weighted keys and built-in speakers",
            Price = 899.99m,
            QuantityInStock = 4,
            CategoryId = 2,
            ManufacturerId = 3
        },
        new Product()
        {
            Id = 9,
            Name = "Violin",
            Description = "Full-size violin with bow and case",
            Price = 199.99m,
            QuantityInStock = 6,
            CategoryId = 3,
            ManufacturerId = 4
        },
        new Product()
        {
            Id = 10,
            Name = "Studio Monitor",
            Description = "Active studio monitor speaker",
            Price = 149.99m,
            QuantityInStock = 12,
            CategoryId = 1,
            ManufacturerId = 4
        },
    };
        }


        private static List<OrderItem> PrepareOrderItemsModels()
        {
            return new List<OrderItem>()
            {
                new OrderItem()
                {
                    Id = 1,
                    OrderId = 1,
                    ProductId = 1,
                    Quantity = 1,
                    Price = 99.99m,
                },
                new OrderItem()
                {
                    Id = 2,
                    OrderId = 1,
                    ProductId = 2,
                    Quantity = 2,
                    Price = 21.99m,
                },
                new OrderItem()
                {
                    Id = 3,
                    OrderId = 2,
                    ProductId = 3,
                    Quantity = 100,
                    Price = 280m,
                },
                new OrderItem()
                {
                    Id = 4,
                    OrderId = 3,
                    ProductId = 4,
                    Quantity = 5,
                    Price = 499.99m,
                },
                new OrderItem()
                {
                    Id = 5,
                    OrderId = 4,
                    ProductId = 5,
                    Quantity = 1,
                    Price = 720.05m,
                },
                new OrderItem()
                {
                    Id = 6,
                    OrderId = 5,
                    ProductId = 6,
                    Quantity = 3,
                    Price = 29.99m,
                },
                new OrderItem()
                {
                    Id = 7,
                    OrderId = 4,
                    ProductId = 6,
                    Quantity = 2,
                    Price = 25.54m,
                },
            };
        }

        private static List<Category> PrepareCategoryModels()
        {
            return new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Musical Instruments",
                },
                new Category()
                {
                    Id = 2,
                    Name = "Audio Equipment",
                },
                new Category()
                {
                    Id = 3,
                    Name = "Accessories",
                },
            };
        }

        private static List<Manufacturer> PrepareManufacturerModels()
        {
            return new List<Manufacturer>()
            {
                new Manufacturer()
                {
                    Id = 1,
                    Name = "Shure",
                },
                new Manufacturer()
                {
                    Id = 2,
                    Name = "Yamaha",
                },
                new Manufacturer()
                {
                    Id = 3,
                    Name = "Fender",
                },
                new Manufacturer()
                {
                    Id = 4,
                    Name = "Sennheiser",
                },
            };
        }
    }
}
