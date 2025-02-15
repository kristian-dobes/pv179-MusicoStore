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
    [Migration("20241018072926_initial")]
    partial class initial
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
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3788),
                            Name = "Musical Instruments"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3791),
                            Name = "Audio Equipment"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3793),
                            Name = "Accessories"
                        });
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
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3797),
                            Name = "Shure"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3800),
                            Name = "Yamaha"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3802),
                            Name = "Fender"
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3804),
                            Name = "Sennheiser"
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

                    b.Property<int?>("OrderItemId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderItemId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3705),
                            Date = new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3712),
                            Date = new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3716),
                            Date = new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3719),
                            Date = new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3723),
                            Date = new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
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
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3765),
                            OrderId = 1,
                            Price = 99.99m,
                            ProductId = 1,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3769),
                            OrderId = 1,
                            Price = 21.99m,
                            ProductId = 2,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3771),
                            OrderId = 2,
                            Price = 280m,
                            ProductId = 3,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3775),
                            OrderId = 3,
                            Price = 499.99m,
                            ProductId = 4,
                            Quantity = 5
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3777),
                            OrderId = 4,
                            Price = 720.05m,
                            ProductId = 5,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 6,
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3780),
                            OrderId = 5,
                            Price = 29.99m,
                            ProductId = 6,
                            Quantity = 3
                        },
                        new
                        {
                            Id = 7,
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3783),
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
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3729),
                            Description = "Professional condenser microphone for studio recording",
                            ManufacturerId = 4,
                            Name = "Microphone",
                            Price = 99.99m,
                            QuantityInStock = 10
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3738),
                            Description = "Music concert DVD of popular artist",
                            ManufacturerId = 2,
                            Name = "DVD",
                            Price = 19.99m,
                            QuantityInStock = 50
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3740),
                            Description = "Acoustic guitar with solid spruce top",
                            ManufacturerId = 1,
                            Name = "Guitar",
                            Price = 299.99m,
                            QuantityInStock = 5
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3743),
                            Description = "Digital keyboard with weighted keys",
                            ManufacturerId = 3,
                            Name = "Keyboard",
                            Price = 499.99m,
                            QuantityInStock = 3
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3745),
                            Description = "5-piece drum set with cymbals and hardware",
                            ManufacturerId = 1,
                            Name = "Drum Set",
                            Price = 699.99m,
                            QuantityInStock = 2
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3749),
                            Description = "Adjustable microphone stand with boom arm",
                            ManufacturerId = 1,
                            Name = "Microphone Stand",
                            Price = 29.99m,
                            QuantityInStock = 20
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3751),
                            Description = "Electric bass guitar with active pickups",
                            ManufacturerId = 4,
                            Name = "Bass Guitar",
                            Price = 399.99m,
                            QuantityInStock = 8
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3754),
                            Description = "Digital piano with weighted keys and built-in speakers",
                            ManufacturerId = 3,
                            Name = "Piano",
                            Price = 899.99m,
                            QuantityInStock = 4
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3756),
                            Description = "Full-size violin with bow and case",
                            ManufacturerId = 4,
                            Name = "Violin",
                            Price = 199.99m,
                            QuantityInStock = 6
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 1,
                            Created = new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3760),
                            Description = "Active studio monitor speaker",
                            ManufacturerId = 4,
                            Name = "Studio Monitor",
                            Price = 149.99m,
                            QuantityInStock = 12
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Models.Order", b =>
                {
                    b.HasOne("DataAccessLayer.Models.OrderItem", null)
                        .WithMany("Comments")
                        .HasForeignKey("OrderItemId");
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

            modelBuilder.Entity("DataAccessLayer.Models.OrderItem", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Product", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
