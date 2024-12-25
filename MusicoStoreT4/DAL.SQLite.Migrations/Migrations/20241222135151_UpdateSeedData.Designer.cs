﻿// <auto-generated />
using System;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.SQLite.Migrations.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20241222135151_UpdateSeedData")]
    partial class UpdateSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("DataAccessLayer.Models.AuditLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("ModifiedById")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 965, DateTimeKind.Local).AddTicks(6513),
                            Name = "Instruments"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 965, DateTimeKind.Local).AddTicks(6553),
                            Name = "Accessories"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 965, DateTimeKind.Local).AddTicks(6555),
                            Name = "Equipment"
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Models.LocalIdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("DataAccessLayer.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 967, DateTimeKind.Local).AddTicks(2835),
                            Name = "Miller Group"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 967, DateTimeKind.Local).AddTicks(8561),
                            Name = "Lakin LLC"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 967, DateTimeKind.Local).AddTicks(9862),
                            Name = "Kovacek, Blanda and Gutkowski"
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 968, DateTimeKind.Local).AddTicks(59),
                            Name = "Kessler, Goldner and Tremblay"
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 968, DateTimeKind.Local).AddTicks(176),
                            Name = "Dickinson Inc"
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4492),
                            Date = new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatus = 0,
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4502),
                            Date = new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatus = 0,
                            UserId = 3
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4506),
                            Date = new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatus = 0,
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4509),
                            Date = new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatus = 0,
                            UserId = 2
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4513),
                            Date = new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatus = 0,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4521),
                            OrderId = 1,
                            Price = 99.99m,
                            ProductId = 1,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4526),
                            OrderId = 1,
                            Price = 21.99m,
                            ProductId = 2,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4528),
                            OrderId = 2,
                            Price = 280m,
                            ProductId = 3,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4532),
                            OrderId = 3,
                            Price = 499.99m,
                            ProductId = 4,
                            Quantity = 5
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4535),
                            OrderId = 3,
                            Price = 720.05m,
                            ProductId = 5,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 6,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4538),
                            OrderId = 4,
                            Price = 29.99m,
                            ProductId = 6,
                            Quantity = 3
                        },
                        new
                        {
                            Id = 7,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4540),
                            OrderId = 5,
                            Price = 25.54m,
                            ProductId = 6,
                            Quantity = 2
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EditCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LastModifiedById")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 969, DateTimeKind.Local).AddTicks(6683),
                            Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            EditCount = 1,
                            LastModifiedById = 1,
                            ManufacturerId = 1,
                            Name = "Amplifiers",
                            Price = 900.335303141710690m,
                            QuantityInStock = 3
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 969, DateTimeKind.Local).AddTicks(8976),
                            Description = "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                            EditCount = 2,
                            LastModifiedById = 1,
                            ManufacturerId = 2,
                            Name = "Digital Piano",
                            Price = 51.4046968833444760m,
                            QuantityInStock = 90
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 969, DateTimeKind.Local).AddTicks(9049),
                            Description = "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                            EditCount = 2,
                            LastModifiedById = 1,
                            ManufacturerId = 5,
                            Name = "Guitar Picks",
                            Price = 93.0524202743082760m,
                            QuantityInStock = 97
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 969, DateTimeKind.Local).AddTicks(9071),
                            Description = "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                            EditCount = 1,
                            LastModifiedById = 1,
                            ManufacturerId = 5,
                            Name = "Drum Kit",
                            Price = 120.915022801811140m,
                            QuantityInStock = 1
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 969, DateTimeKind.Local).AddTicks(9090),
                            Description = "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                            EditCount = 6,
                            LastModifiedById = 1,
                            ManufacturerId = 1,
                            Name = "Amplifiers",
                            Price = 49.1561730168610870m,
                            QuantityInStock = 86
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 969, DateTimeKind.Local).AddTicks(9109),
                            Description = "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                            EditCount = 6,
                            LastModifiedById = 1,
                            ManufacturerId = 5,
                            Name = "Amplifiers",
                            Price = 587.502477246248290m,
                            QuantityInStock = 35
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 969, DateTimeKind.Local).AddTicks(9137),
                            Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            EditCount = 3,
                            LastModifiedById = 1,
                            ManufacturerId = 3,
                            Name = "Violin",
                            Price = 501.311496680687980m,
                            QuantityInStock = 2
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Models.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductImages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2024, 12, 22, 13, 51, 50, 973, DateTimeKind.Utc).AddTicks(4606),
                            FileName = "drums.png",
                            FilePath = "images\\drums.png",
                            MimeType = "image/png",
                            ProductId = 3
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 12, 22, 13, 51, 50, 973, DateTimeKind.Utc).AddTicks(4609),
                            FileName = "guitar.png",
                            FilePath = "images\\guitar.png",
                            MimeType = "image/png",
                            ProductId = 5
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator().HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DataAccessLayer.Models.Customer", b =>
                {
                    b.HasBaseType("DataAccessLayer.Models.User");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Customer");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 971, DateTimeKind.Local).AddTicks(5614),
                            Email = "Noelia.Predovic.Feeney@yahoo.com",
                            Role = 1,
                            Username = "Noelia.Predovic",
                            Address = "2233 Garrison Harbor",
                            City = "Marjorieview",
                            PhoneNumber = "+464 089 730 017",
                            PostalCode = "80174",
                            State = "Colorado"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 971, DateTimeKind.Local).AddTicks(8853),
                            Email = "Weston16.Friesen27@yahoo.com",
                            Role = 1,
                            Username = "Weston16",
                            Address = "01225 Jacobs Ford",
                            City = "Yvonneton",
                            PhoneNumber = "+739 782 782 397",
                            PostalCode = "91024-1061",
                            State = "Wyoming"
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 971, DateTimeKind.Local).AddTicks(9205),
                            Email = "Horace63_DAmore@gmail.com",
                            Role = 1,
                            Username = "Horace63",
                            Address = "5052 Carolanne Terrace",
                            City = "Willchester",
                            PhoneNumber = "+616 608 412 284",
                            PostalCode = "48218-2775",
                            State = "Rhode Island"
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2024, 12, 22, 14, 51, 50, 972, DateTimeKind.Local).AddTicks(6914),
                            Email = "Christophe60_OReilly90@hotmail.com",
                            Role = 1,
                            Username = "Christophe60",
                            Address = "6536 Roselyn Shores",
                            City = "East Danielleville",
                            PhoneNumber = "+614 756 499 017",
                            PostalCode = "97384-1882",
                            State = "Texas"
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Models.LocalIdentityUser", b =>
                {
                    b.HasOne("DataAccessLayer.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Order", b =>
                {
                    b.HasOne("DataAccessLayer.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccessLayer.Models.OrderItem", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Models.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Product", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Models.Manufacturer", "Manufacturer")
                        .WithMany("Products")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("DataAccessLayer.Models.ProductImage", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Product", "Product")
                        .WithOne("Image")
                        .HasForeignKey("DataAccessLayer.Models.ProductImage", "ProductId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DataAccessLayer.Models.LocalIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DataAccessLayer.Models.LocalIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Models.LocalIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DataAccessLayer.Models.LocalIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Manufacturer", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Product", b =>
                {
                    b.Navigation("Image");

                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("DataAccessLayer.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
