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
    [Migration("20241119194116_bogus-init")]
    partial class bogusinit
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
                            Created = new DateTime(2024, 11, 19, 20, 41, 14, 988, DateTimeKind.Local).AddTicks(6623),
                            Name = "Instruments"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 11, 19, 20, 41, 14, 988, DateTimeKind.Local).AddTicks(6700),
                            Name = "Accessories"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 11, 19, 20, 41, 14, 988, DateTimeKind.Local).AddTicks(6709),
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
                            Created = new DateTime(2024, 11, 19, 20, 41, 14, 993, DateTimeKind.Local).AddTicks(4054),
                            Name = "Cassin Group"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 11, 19, 20, 41, 14, 993, DateTimeKind.Local).AddTicks(9782),
                            Name = "Weissnat - Johns"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 11, 19, 20, 41, 14, 994, DateTimeKind.Local).AddTicks(404),
                            Name = "Waelchi, Murphy and Bergstrom"
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2024, 11, 19, 20, 41, 14, 994, DateTimeKind.Local).AddTicks(845),
                            Name = "Swift - Bernhard"
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2024, 11, 19, 20, 41, 14, 994, DateTimeKind.Local).AddTicks(1042),
                            Name = "Bradtke Group"
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
                            Created = new DateTime(2024, 11, 19, 20, 41, 15, 8, DateTimeKind.Local).AddTicks(7025),
                            Date = new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 11, 19, 20, 41, 15, 8, DateTimeKind.Local).AddTicks(7050),
                            Date = new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 3
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 11, 19, 20, 41, 15, 8, DateTimeKind.Local).AddTicks(7066),
                            Date = new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2024, 11, 19, 20, 41, 15, 8, DateTimeKind.Local).AddTicks(7083),
                            Date = new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2024, 11, 19, 20, 41, 15, 8, DateTimeKind.Local).AddTicks(7099),
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
                            Created = new DateTime(2024, 11, 19, 20, 41, 15, 8, DateTimeKind.Local).AddTicks(7115),
                            OrderId = 1,
                            Price = 99.99m,
                            ProductId = 1,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 11, 19, 20, 41, 15, 8, DateTimeKind.Local).AddTicks(7130),
                            OrderId = 1,
                            Price = 21.99m,
                            ProductId = 2,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 11, 19, 20, 41, 15, 8, DateTimeKind.Local).AddTicks(7140),
                            OrderId = 2,
                            Price = 280m,
                            ProductId = 3,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2024, 11, 19, 20, 41, 15, 8, DateTimeKind.Local).AddTicks(7152),
                            OrderId = 3,
                            Price = 499.99m,
                            ProductId = 4,
                            Quantity = 5
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2024, 11, 19, 20, 41, 15, 8, DateTimeKind.Local).AddTicks(7161),
                            OrderId = 4,
                            Price = 720.05m,
                            ProductId = 5,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 6,
                            Created = new DateTime(2024, 11, 19, 20, 41, 15, 8, DateTimeKind.Local).AddTicks(7174),
                            OrderId = 5,
                            Price = 29.99m,
                            ProductId = 6,
                            Quantity = 3
                        },
                        new
                        {
                            Id = 7,
                            Created = new DateTime(2024, 11, 19, 20, 41, 15, 8, DateTimeKind.Local).AddTicks(7183),
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
                            Created = new DateTime(2024, 11, 19, 20, 41, 14, 999, DateTimeKind.Local).AddTicks(6470),
                            Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            ManufacturerId = 1,
                            Name = "Stage Lighting Kits",
                            Price = 467.831560954574620m,
                            QuantityInStock = 38
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            Created = new DateTime(2024, 11, 19, 20, 41, 15, 0, DateTimeKind.Local).AddTicks(91),
                            Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            ManufacturerId = 3,
                            Name = "Acoustic Guitar",
                            Price = 137.863110441171160m,
                            QuantityInStock = 68
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Created = new DateTime(2024, 11, 19, 20, 41, 15, 0, DateTimeKind.Local).AddTicks(250),
                            Description = "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                            ManufacturerId = 3,
                            Name = "Acoustic Guitar",
                            Price = 679.87203782267890m,
                            QuantityInStock = 72
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            Created = new DateTime(2024, 11, 19, 20, 41, 15, 0, DateTimeKind.Local).AddTicks(302),
                            Description = "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                            ManufacturerId = 1,
                            Name = "Tuners",
                            Price = 568.868747298612850m,
                            QuantityInStock = 48
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Created = new DateTime(2024, 11, 19, 20, 41, 15, 0, DateTimeKind.Local).AddTicks(353),
                            Description = "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                            ManufacturerId = 3,
                            Name = "Karaoke Machines",
                            Price = 617.884472885447890m,
                            QuantityInStock = 79
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Created = new DateTime(2024, 11, 19, 20, 41, 15, 0, DateTimeKind.Local).AddTicks(400),
                            Description = "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                            ManufacturerId = 5,
                            Name = "Drum Kit",
                            Price = 784.195063040735380m,
                            QuantityInStock = 82
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            Created = new DateTime(2024, 11, 19, 20, 41, 15, 0, DateTimeKind.Local).AddTicks(447),
                            Description = "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                            ManufacturerId = 2,
                            Name = "Stage Lighting Kits",
                            Price = 344.065370759100640m,
                            QuantityInStock = 92
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2024, 11, 19, 19, 41, 15, 8, DateTimeKind.Utc).AddTicks(7346),
                            FileName = "drums.png",
                            FilePath = "images\\drums.png",
                            MimeType = "image/png",
                            ProductId = 3
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 11, 19, 19, 41, 15, 8, DateTimeKind.Utc).AddTicks(7360),
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
                            Created = new DateTime(2024, 11, 19, 20, 41, 15, 4, DateTimeKind.Local).AddTicks(8868),
                            Email = "Colt.Padberg2140@gmail.com",
                            Role = 1,
                            Username = "Colt.Padberg21",
                            Address = "2046 Newton Summit",
                            City = "North Georgiannabury",
                            PhoneNumber = "+045 370 130 438",
                            PostalCode = "37977",
                            State = "Colorado"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 11, 19, 20, 41, 15, 5, DateTimeKind.Local).AddTicks(3661),
                            Email = "Keshaun_Parisian28@yahoo.com",
                            Role = 1,
                            Username = "Keshaun_Parisian",
                            Address = "2472 Frieda Roads",
                            City = "Shanahanborough",
                            PhoneNumber = "+055 913 188 287",
                            PostalCode = "68025",
                            State = "Kansas"
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2024, 11, 19, 20, 41, 15, 5, DateTimeKind.Local).AddTicks(4434),
                            Email = "Immanuel58_Bahringer48@hotmail.com",
                            Role = 1,
                            Username = "Immanuel58",
                            Address = "6006 Rolando Ports",
                            City = "Ozellamouth",
                            PhoneNumber = "+625 984 133 521",
                            PostalCode = "76036",
                            State = "Virginia"
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2024, 11, 19, 20, 41, 15, 5, DateTimeKind.Local).AddTicks(5014),
                            Email = "Carson26.Kunde2@hotmail.com",
                            Role = 1,
                            Username = "Carson26",
                            Address = "21502 Mayer Spring",
                            City = "Lake Eveline",
                            PhoneNumber = "+538 273 136 433",
                            PostalCode = "32833-8405",
                            State = "Wisconsin"
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
