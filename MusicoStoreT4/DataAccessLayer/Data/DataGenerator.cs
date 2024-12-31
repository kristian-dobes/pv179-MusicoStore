using System;
using System.Collections.Generic;
using Bogus;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Enums;
using Microsoft.EntityFrameworkCore;

public static class DataGenerator
{
    private const int NumberOfUsers = 7;
    private const int NumberOfOrders = 15;
    private const int NumberOfProducts = 20;
    private const int NumberOfManufacturers = 7;

    public static void Seed(this ModelBuilder modelBuilder)
    {
        // Bogus Seeding for simple entities (Categories, Manufacturers, Products, Customers)
        var categories = GenerateCategories();
        var manufacturers = GenerateManufacturers(NumberOfManufacturers);
        var products = GenerateProducts(NumberOfProducts, categories, manufacturers);
        var customers = GenerateCustomers(NumberOfUsers);
        var categoryProducts = GenerateCategoryProducts(products);

        modelBuilder.Entity<Category>().HasData(categories);
        modelBuilder.Entity<Manufacturer>().HasData(manufacturers);
        modelBuilder
            .Entity<Product>()
            .HasData(
                products.Select(p => new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    QuantityInStock = p.QuantityInStock,
                    LastModifiedById = p.LastModifiedById,
                    EditCount = p.EditCount,
                    PrimaryCategoryId = p.PrimaryCategoryId,
                    ManufacturerId = p.ManufacturerId
                })
            );
        modelBuilder.Entity<Customer>().HasData(customers);
        modelBuilder.Entity("CategoryProduct").HasData(categoryProducts);

        var orders = GenerateOrders(NumberOfOrders, customers);
        var orderItems = GenerateOrderItems(orders, products);

        modelBuilder.Entity<Order>().HasData(orders);
        modelBuilder.Entity<OrderItem>().HasData(orderItems);

        // Images
        //var images = PrepareImagesModels();
        //modelBuilder.Entity<ProductImage>().HasData(images);

        var coupons = PrepareCouponCodesModels();
        modelBuilder.Entity<CouponCode>().HasData(coupons);

        var giftCards = PrepareGiftCardsModels(coupons);
        modelBuilder.Entity<GiftCard>().HasData(giftCards);
    }

    // Dictionary to store product for each category
    private static readonly Dictionary<string, List<string>> CategoryProducts =
        new()
        {
        { "Instruments", new() { "Acoustic Guitar", "Digital Piano", "Drum Kit", "Violin", "Saxophone", "Electric Guitar", "Bass Guitar", "Trumpet", "Flute", "Cello", "Ukulele", "Harmonica", "Mandolin", "Banjo", "Clarinet" } },
        { "Accessories", new() { "Guitar Picks", "Instrument Cases", "Replacement Strings", "Tuners", "Microphone Stands", "Capos", "Guitar Straps", "Drumsticks", "Reeds", "Music Stands", "Pedalboards", "Metronomes", "Rosin" } },
        { "Equipment", new() { "Amplifiers", "PA Systems", "Studio Monitors", "Karaoke Machines", "Stage Lighting Kits", "Mixing Consoles", "Audio Interfaces", "Wireless Microphone Systems", "Headphones", "Recording Microphones", "DI Boxes", "Equalizers", "Effects Processors" } },
        { "Software", new() { "Digital Audio Workstations (DAWs)", "Virtual Instruments", "Music Notation Software", "Audio Editing Tools", "Loop Libraries", "Plugin Bundles", "Synthesizer Plugins", "Drum Machine Software" } },
        { "Learning", new() { "Music Theory Books", "Instrument Tutorials", "Chord Charts", "Online Course Subscriptions", "Practice Apps", "Ear Training Tools", "Sheet Music Collections" } }
        };

    public static List<Category> GenerateCategories()
    {
        int id = 1;

        return CategoryProducts
            .Keys.Select(categoryName => new Category { Id = id++, Name = categoryName })
            .ToList();
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
            .RuleFor(p => p.Name, (f, p) =>
            {
                // Ensure product matches its category
                var category = f.PickRandom(categories);
                var product = f.PickRandom(CategoryProducts[category.Name]);
                p.PrimaryCategoryId = category.Id; // Assign the correct category ID
                return product;
            })
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.Price, f => Math.Round(f.Random.Decimal(10, 1000), 2))
            .RuleFor(p => p.LastModifiedById, f => 1)
            .RuleFor(p => p.EditCount, f => f.Random.Int(1, 5))
            .RuleFor(p => p.ManufacturerId, f => f.PickRandom(manufacturers).Id)
            .RuleFor(p => p.QuantityInStock, f => f.Random.Int(1, 100))
            .RuleFor(p => p.SecondaryCategories, (f, p) =>
            {
                var secondaryCategories = f.PickRandom(categories.Where(c => c.Id != p.PrimaryCategoryId).ToList(), f.Random.Int(0, 3)).ToList();
                return secondaryCategories;
            }
            )
            .Generate(count);
    }

    public static List<Dictionary<string, object>> GenerateCategoryProducts(List<Product> products)
    {
        return products
            .SelectMany(product =>
                product
                    .SecondaryCategories.Where(c => c.Id != product.PrimaryCategoryId)
                    .Select(category => new Dictionary<string, object>
                    {
                    { "ProductId", product.Id },
                    { "CategoryId", category.Id }
                    })
            )
            .ToList();
    }

    public static List<Customer> GenerateCustomers(int count)
    {
        int id = 2; // Start from 2 to avoid conflict with Admin user

        return new Faker<Customer>()
            .RuleFor(c => c.Id, f => id++)
            .RuleFor(c => c.Username, f => f.Internet.UserName())
            .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Username))
            .RuleFor(c => c.Role, f => Role.Customer)
            .RuleFor(c => c.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(c => c.Address, f => f.Address.StreetAddress())
            .RuleFor(c => c.City, f => f.Address.City())
            .RuleFor(c => c.State, f => f.Address.State())
            .RuleFor(c => c.PostalCode, f => f.Address.ZipCode())
            .Generate(count);
    }

    public static List<Order> GenerateOrders(int count, List<Customer> customers)
    {
        int id = 100; // Start ID
        return new Faker<Order>()
            .RuleFor(o => o.Id, _ => id++) // Ensure unique IDs
            .RuleFor(o => o.Date, f => f.Date.Past(2))
            .RuleFor(o => o.UserId, f => f.PickRandom(customers).Id)
            .RuleFor(o => o.OrderStatus, f => f.PickRandom<PaymentStatus>())
            .Generate(count);
    }

    public static List<OrderItem> GenerateOrderItems(List<Order> orders, List<Product> products)
    {
        int id = 1; // Start ID for order items
        return orders.SelectMany(order =>
            new Faker<OrderItem>()
                .RuleFor(oi => oi.Id, _ => id++) // Ensure unique IDs
                .RuleFor(oi => oi.OrderId, _ => order.Id)
                .RuleFor(oi => oi.ProductId, f => f.PickRandom(products).Id)
                .RuleFor(oi => oi.Quantity, f => f.Random.Int(1, 10))
                .RuleFor(oi => oi.Price, (f, oi) =>
                {
                    var product = products.First(p => p.Id == oi.ProductId);
                    return Math.Round(product.Price * oi.Quantity, 2);
                })
                .Generate(new Random().Next(1, 5))) // Random number of items per order
            .ToList();
    }

    private static List<CouponCode> PrepareCouponCodesModels()
    {
        return new List<CouponCode>()
        {
            new CouponCode()
            {
                Id = 1,
                Created = DateTime.Now.AddMonths(-1),
                Code = "GIFT200-1",
                IsUsed = false,
                GiftCardId = 1,
                OrderId = null,
            },
            new CouponCode()
            {
                Id = 2,
                Created = DateTime.Now.AddMonths(-1),
                Code = "GIFT200-2",
                IsUsed = false,
                GiftCardId = 1,
                OrderId = null,
            },
            new CouponCode()
            {
                Id = 3,
                Created = DateTime.Now.AddMonths(-2),
                Code = "GIFT100-1",
                IsUsed = false,
                GiftCardId = 2,
                OrderId = null,
            },
            new CouponCode()
            {
                Id = 4,
                Created = DateTime.Now.AddMonths(-2),
                Code = "GIFT100-2",
                IsUsed = false,
                GiftCardId = 2,
                OrderId = null,
            }
        };
    }

    private static List<GiftCard> PrepareGiftCardsModels(List<CouponCode> couponCodes)
    {
        return new List<GiftCard>()
        {
            new GiftCard()
            {
                Id = 1,
                Created = DateTime.Now.AddMonths(-1),
                DiscountAmount = 200.00m,
                ValidityStartDate = DateTime.Now.AddMonths(-1),
                ValidityEndDate = DateTime.Now.AddMonths(6)
            },
            new GiftCard()
            {
                Id = 2,
                Created = DateTime.Now.AddMonths(-2),
                DiscountAmount = 100.00m,
                ValidityStartDate = DateTime.Now.AddMonths(-2),
                ValidityEndDate = DateTime.Now.AddMonths(4)
            }
        };
    }
}