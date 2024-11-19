using System;
using System.Collections.Generic;
using Bogus;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Enums;
using Microsoft.EntityFrameworkCore;

public static class DataGenerator
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        //Bogus Seeding for simple entities (Categories, Manufacturers, Products, Customers)
        var categories = GenerateCategories();
        var manufacturers = GenerateManufacturers(5);
        var products = GenerateProducts(7, categories, manufacturers);
        var customers = GenerateCustomers(4);

        modelBuilder.Entity<Category>().HasData(categories);
        modelBuilder.Entity<Manufacturer>().HasData(manufacturers);
        modelBuilder.Entity<Product>().HasData(products);
        modelBuilder.Entity<Customer>().HasData(customers);

        // Manual Seeding for Orders and OrderItems
        var orders = PrepareOrderModels();
        var orderItems = PrepareOrderItemsModels();

        modelBuilder.Entity<Order>().HasData(orders);
        modelBuilder.Entity<OrderItem>().HasData(orderItems);
    }

    // Dictionary to store product for each category
    private static readonly Dictionary<string, List<string>> CategoryProducts = new()
    {
        { "Instruments", new() { "Acoustic Guitar", "Digital Piano", "Drum Kit", "Violin", "Saxophone" } },
        { "Accessories", new() { "Guitar Picks", "Instrument Cases", "Replacement Strings", "Tuners", "Microphone Stands" } },
        { "Equipment", new() { "Amplifiers", "PA Systems", "Studio Monitors", "Karaoke Machines", "Stage Lighting Kits" } }
    };

    public static List<Category> GenerateCategories()
    {
        int id = 1;

        return CategoryProducts.Keys.Select(categoryName => new Category
        {
            Id = id++,
            Name = categoryName
        }).ToList();
    }

    public static List<Manufacturer> GenerateManufacturers(int count)
    {
        int id = 1;

        return new Faker<Manufacturer>()
            .RuleFor(m => m.Id, f => id++)
            .RuleFor(m => m.Name, f => f.Company.CompanyName())
            .Generate(count);
    }

    public static List<Product> GenerateProducts(int count, List<Category> categories, List<Manufacturer> manufacturers)
    {
        int id = 1;

        return new Faker<Product>()
            .RuleFor(p => p.Id, f => id++)
            .RuleFor(p => p.Name, f =>
            {
                var category = f.PickRandom(categories);
                var product = f.PickRandom(CategoryProducts[category.Name]);
                return product;
            })
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.Price, f => f.Random.Decimal(10, 1000))
            .RuleFor(p => p.CategoryId, f => f.PickRandom(categories).Id)
            .RuleFor(p => p.ManufacturerId, f => f.PickRandom(manufacturers).Id)
            .RuleFor(p => p.QuantityInStock, f => f.Random.Int(1, 100))
            .Generate(count);
    }

    public static List<Customer> GenerateCustomers(int count)
    {
        int id = 2; // Start from 2 to avoid conflict with Admin user

        return new Faker<Customer>()
            .RuleFor(c => c.Id, f => id++)
            .RuleFor(c => c.Username, f => f.Internet.UserName())
            .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Username))
            .RuleFor(c => c.Role, f => Role.Customer)
            .RuleFor(c => c.PhoneNumber, f => f.Phone.PhoneNumber("+### ### ### ###"))
            .RuleFor(c => c.Address, f => f.Address.StreetAddress())
            .RuleFor(c => c.City, f => f.Address.City())
            .RuleFor(c => c.State, f => f.Address.State())
            .RuleFor(c => c.PostalCode, f => f.Address.ZipCode())
            .Generate(count);
    }

    private static List<Order> PrepareOrderModels()
    {
        return new List<Order>()
        {
            new Order()
            {
                Id = 1,
                Date = new DateTime(2024, 10, 1),
                UserId = 2
            },
            new Order()
            {
                Id = 2,
                Date = new DateTime(2024, 11, 15),
                UserId = 3,
            },
            new Order()
            {
                Id = 3,
                Date = new DateTime(2024, 12, 5),
                UserId = 3,
            },
            new Order()
            {
                Id = 4,
                Date = new DateTime(2025, 1, 20),
                UserId = 2,
            },
            new Order()
            {
                Id = 5,
                Date = new DateTime(2025, 2, 10),
                UserId = 2,
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
}