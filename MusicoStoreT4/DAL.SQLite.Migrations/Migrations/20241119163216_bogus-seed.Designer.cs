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
    [Migration("20241119163216_bogus-seed")]
    partial class bogusseed
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
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 454, DateTimeKind.Local).AddTicks(5711),
                            Name = "Instruments"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 454, DateTimeKind.Local).AddTicks(5820),
                            Name = "Accessories"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 454, DateTimeKind.Local).AddTicks(5828),
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
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 458, DateTimeKind.Local).AddTicks(5372),
                            Name = "Herman Inc"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 459, DateTimeKind.Local).AddTicks(1783),
                            Name = "Kemmer, Goldner and Trantow"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 459, DateTimeKind.Local).AddTicks(2756),
                            Name = "Brakus, Miller and Stanton"
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 459, DateTimeKind.Local).AddTicks(3264),
                            Name = "Schneider Inc"
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 459, DateTimeKind.Local).AddTicks(3563),
                            Name = "Jenkins - Bartoletti"
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

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 474, DateTimeKind.Local).AddTicks(7914),
                            Date = new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 474, DateTimeKind.Local).AddTicks(7943),
                            Date = new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 3
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 474, DateTimeKind.Local).AddTicks(7964),
                            Date = new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 474, DateTimeKind.Local).AddTicks(7984),
                            Date = new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 474, DateTimeKind.Local).AddTicks(8004),
                            Date = new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
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

                    b.Property<int>("ProductId")
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
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 474, DateTimeKind.Local).AddTicks(8023),
                            OrderId = 1,
                            Price = 99.99m,
                            ProductId = 1,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 474, DateTimeKind.Local).AddTicks(8040),
                            OrderId = 1,
                            Price = 21.99m,
                            ProductId = 2,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 474, DateTimeKind.Local).AddTicks(8052),
                            OrderId = 2,
                            Price = 280m,
                            ProductId = 3,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 474, DateTimeKind.Local).AddTicks(8065),
                            OrderId = 3,
                            Price = 499.99m,
                            ProductId = 4,
                            Quantity = 5
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 474, DateTimeKind.Local).AddTicks(8076),
                            OrderId = 4,
                            Price = 720.05m,
                            ProductId = 5,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 6,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 474, DateTimeKind.Local).AddTicks(8090),
                            OrderId = 5,
                            Price = 29.99m,
                            ProductId = 6,
                            Quantity = 3
                        },
                        new
                        {
                            Id = 7,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 474, DateTimeKind.Local).AddTicks(8101),
                            OrderId = 4,
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
                            CategoryId = 3,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 464, DateTimeKind.Local).AddTicks(7559),
                            Description = "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                            ManufacturerId = 5,
                            Name = "Acoustic Guitar",
                            Price = 294.131160291333520m,
                            QuantityInStock = 2
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 465, DateTimeKind.Local).AddTicks(1517),
                            Description = "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                            ManufacturerId = 1,
                            Name = "PA Systems",
                            Price = 205.565336005722760m,
                            QuantityInStock = 47
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 465, DateTimeKind.Local).AddTicks(1687),
                            Description = "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit",
                            ManufacturerId = 4,
                            Name = "Saxophone",
                            Price = 575.13010600655290m,
                            QuantityInStock = 9
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 465, DateTimeKind.Local).AddTicks(1754),
                            Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            ManufacturerId = 3,
                            Name = "Digital Piano",
                            Price = 741.332166524702380m,
                            QuantityInStock = 93
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 465, DateTimeKind.Local).AddTicks(1815),
                            Description = "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                            ManufacturerId = 2,
                            Name = "Instrument Cases",
                            Price = 215.650002243658060m,
                            QuantityInStock = 29
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 465, DateTimeKind.Local).AddTicks(1875),
                            Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            ManufacturerId = 1,
                            Name = "Acoustic Guitar",
                            Price = 564.097375148073130m,
                            QuantityInStock = 63
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 465, DateTimeKind.Local).AddTicks(1932),
                            Description = "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                            ManufacturerId = 2,
                            Name = "PA Systems",
                            Price = 440.167071478381930m,
                            QuantityInStock = 60
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

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
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
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 470, DateTimeKind.Local).AddTicks(4682),
                            Email = "Verdie_Hermann1_Casper32@hotmail.com",
                            Role = 1,
                            Username = "Verdie_Hermann1",
                            Address = "8095 Monahan Flat",
                            City = "Port Mandyburgh",
                            PhoneNumber = "+295 981 389 688",
                            PostalCode = "31622",
                            State = "North Dakota"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 470, DateTimeKind.Local).AddTicks(9989),
                            Email = "Baby_Welch81.Runolfsdottir@yahoo.com",
                            Role = 1,
                            Username = "Baby_Welch81",
                            Address = "1457 Evert Village",
                            City = "Nathanielview",
                            PhoneNumber = "+236 394 085 884",
                            PostalCode = "44056-8452",
                            State = "Maryland"
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 471, DateTimeKind.Local).AddTicks(846),
                            Email = "Keegan.Cormier63.Goyette@yahoo.com",
                            Role = 1,
                            Username = "Keegan.Cormier63",
                            Address = "73042 Quitzon Forest",
                            City = "East Fordton",
                            PhoneNumber = "+372 630 432 037",
                            PostalCode = "97554",
                            State = "Indiana"
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2024, 11, 19, 17, 32, 15, 471, DateTimeKind.Local).AddTicks(1665),
                            Email = "Jadon3321@gmail.com",
                            Role = 1,
                            Username = "Jadon33",
                            Address = "34044 Jasen Manor",
                            City = "Jameyport",
                            PhoneNumber = "+734 109 103 854",
                            PostalCode = "54357",
                            State = "Ohio"
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
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
                        .WithMany()
                        .HasForeignKey("ProductId")
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
