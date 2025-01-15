using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.SQLite.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class ImprovedBogusSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 31, 6, 3, 48, 907, DateTimeKind.Local).AddTicks(1684));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 31, 6, 3, 48, 907, DateTimeKind.Local).AddTicks(1717));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 31, 6, 3, 48, 907, DateTimeKind.Local).AddTicks(1721));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Created", "Name" },
                values: new object[,]
                {
                    { 4, new DateTime(2024, 12, 31, 6, 3, 48, 907, DateTimeKind.Local).AddTicks(1725), "Software" },
                    { 5, new DateTime(2024, 12, 31, 6, 3, 48, 907, DateTimeKind.Local).AddTicks(1729), "Learning" }
                });

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 2 }
                });

            migrationBuilder.UpdateData(
                table: "CouponCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 30, 6, 3, 48, 939, DateTimeKind.Local).AddTicks(1889));

            migrationBuilder.UpdateData(
                table: "CouponCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 30, 6, 3, 48, 939, DateTimeKind.Local).AddTicks(1903));

            migrationBuilder.UpdateData(
                table: "CouponCodes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 10, 31, 6, 3, 48, 939, DateTimeKind.Local).AddTicks(1911));

            migrationBuilder.UpdateData(
                table: "CouponCodes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 10, 31, 6, 3, 48, 939, DateTimeKind.Local).AddTicks(1919));

            migrationBuilder.UpdateData(
                table: "GiftCards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "ValidityEndDate", "ValidityStartDate" },
                values: new object[] { new DateTime(2024, 11, 30, 6, 3, 48, 939, DateTimeKind.Local).AddTicks(1960), new DateTime(2025, 6, 30, 6, 3, 48, 939, DateTimeKind.Local).AddTicks(1969), new DateTime(2024, 11, 30, 6, 3, 48, 939, DateTimeKind.Local).AddTicks(1965) });

            migrationBuilder.UpdateData(
                table: "GiftCards",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "ValidityEndDate", "ValidityStartDate" },
                values: new object[] { new DateTime(2024, 10, 31, 6, 3, 48, 939, DateTimeKind.Local).AddTicks(1980), new DateTime(2025, 4, 30, 6, 3, 48, 939, DateTimeKind.Local).AddTicks(1987), new DateTime(2024, 10, 31, 6, 3, 48, 939, DateTimeKind.Local).AddTicks(1983) });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 31, 6, 3, 48, 908, DateTimeKind.Local).AddTicks(8654), "Kreiger and Sons" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 31, 6, 3, 48, 909, DateTimeKind.Local).AddTicks(1769), "Zemlak, West and Schiller" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 31, 6, 3, 48, 909, DateTimeKind.Local).AddTicks(2204), "Schuster and Sons" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 31, 6, 3, 48, 909, DateTimeKind.Local).AddTicks(2338), "Doyle - Effertz" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 31, 6, 3, 48, 909, DateTimeKind.Local).AddTicks(2466), "Kessler - Kemmer" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Created", "Name" },
                values: new object[,]
                {
                    { 6, new DateTime(2024, 12, 31, 6, 3, 48, 909, DateTimeKind.Local).AddTicks(2569), "Bechtelar Group" },
                    { 7, new DateTime(2024, 12, 31, 6, 3, 48, 909, DateTimeKind.Local).AddTicks(2680), "Kuhn - Predovic" }
                });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[] { new DateTime(2024, 12, 31, 6, 3, 48, 918, DateTimeKind.Local).AddTicks(4331), 100, 2892.28m, 18, 4 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[] { new DateTime(2024, 12, 31, 6, 3, 48, 919, DateTimeKind.Local).AddTicks(9379), 101, 1680.77m, 6, 7 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[] { new DateTime(2024, 12, 31, 6, 3, 48, 919, DateTimeKind.Local).AddTicks(9602), 101, 2816.37m, 11, 9 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[] { new DateTime(2024, 12, 31, 6, 3, 48, 921, DateTimeKind.Local).AddTicks(3875), 102, 1680.77m, 6, 7 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[] { new DateTime(2024, 12, 31, 6, 3, 48, 922, DateTimeKind.Local).AddTicks(8333), 103, 2401.10m, 6, 10 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[] { new DateTime(2024, 12, 31, 6, 3, 48, 922, DateTimeKind.Local).AddTicks(8634), 103, 726.80m, 1, 1 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[] { new DateTime(2024, 12, 31, 6, 3, 48, 922, DateTimeKind.Local).AddTicks(8660), 103, 3129.30m, 11, 10 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Created", "Date", "GiftCardId", "OrderStatus", "UsedCouponCode", "UserId" },
                values: new object[,]
                {
                    { 100, new DateTime(2024, 12, 31, 6, 3, 48, 915, DateTimeKind.Local).AddTicks(9432), new DateTime(2024, 4, 23, 5, 28, 4, 266, DateTimeKind.Local).AddTicks(9903), null, 0, null, 3 },
                    { 101, new DateTime(2024, 12, 31, 6, 3, 48, 916, DateTimeKind.Local).AddTicks(3822), new DateTime(2024, 6, 25, 14, 45, 55, 277, DateTimeKind.Local).AddTicks(3208), null, 3, null, 2 },
                    { 102, new DateTime(2024, 12, 31, 6, 3, 48, 916, DateTimeKind.Local).AddTicks(3908), new DateTime(2024, 2, 16, 22, 21, 43, 530, DateTimeKind.Local).AddTicks(9238), null, 0, null, 2 },
                    { 104, new DateTime(2024, 12, 31, 6, 3, 48, 916, DateTimeKind.Local).AddTicks(3966), new DateTime(2023, 4, 23, 3, 59, 19, 681, DateTimeKind.Local).AddTicks(7457), null, 1, null, 5 },
                    { 110, new DateTime(2024, 12, 31, 6, 3, 48, 916, DateTimeKind.Local).AddTicks(4138), new DateTime(2024, 11, 14, 9, 12, 32, 438, DateTimeKind.Local).AddTicks(6500), null, 0, null, 3 },
                    { 111, new DateTime(2024, 12, 31, 6, 3, 48, 916, DateTimeKind.Local).AddTicks(4166), new DateTime(2023, 6, 3, 3, 13, 19, 96, DateTimeKind.Local).AddTicks(4373), null, 3, null, 4 },
                    { 112, new DateTime(2024, 12, 31, 6, 3, 48, 916, DateTimeKind.Local).AddTicks(4195), new DateTime(2023, 12, 30, 10, 41, 14, 887, DateTimeKind.Local).AddTicks(1922), null, 3, null, 5 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(8239), "The Football Is Good For Training And Recreational Purposes", 3, 6, "Sheet Music Collections", 726.80m, 5, 14 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Description", "EditCount", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(8250), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 5, "Electric Guitar", 379.55m, 1, 33 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(8255), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 3, 4, "Flute", 302.53m, 1, 11 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(8261), 2, 4, "Synthesizer Plugins", 57.13m, 4, 61 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(8266), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 2, 1, "Reeds", 251.36m, 2, 64 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(8272), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 3, 4, "Capos", 240.11m, 98 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(8277), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 4, 6, "Flute", 111.31m, 25 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Created", "Description", "EditCount", "LastModifiedById", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[,]
                {
                    { 9, new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(8289), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 3, 1, 2, "Amplifiers", 300.04m, 3, 85 },
                    { 11, new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(8300), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 1, 1, 1, "Cello", 312.93m, 1, 65 },
                    { 15, new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(8329), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 2, 1, 4, "Effects Processors", 763.86m, 3, 58 },
                    { 20, new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(8365), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 4, 1, 1, "Microphone Stands", 156.46m, 2, 80 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "42742 Emil Estate", "Champlinland", new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(3714), "Maribel.Daniel0@hotmail.com", "1-239-375-1243 x63743", "78431", "New Hampshire", "Maribel.Daniel" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "5091 Antonina Groves", "South Justyn", new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(6251), "Rocio72_Hauck75@gmail.com", "898.958.8285 x605", "16072", "Idaho", "Rocio72" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "913 Ora Shores", "Bauchport", new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(6685), "Armani72_Botsford38@hotmail.com", "978.749.0495 x80098", "66812", "Montana", "Armani72" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "197 Susie Plains", "Lionelberg", new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(6906), "Porter_Grant_Hettinger7@hotmail.com", "1-653-907-1946 x8876", "65480", "New Jersey", "Porter_Grant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Created", "Discriminator", "Email", "PhoneNumber", "PostalCode", "Role", "State", "Username" },
                values: new object[,]
                {
                    { 6, "652 Schmeler Island", "Port Keith", new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(7122), "Customer", "Annabelle48_Lehner@hotmail.com", "1-775-783-5693", "38312-5433", 1, "Florida", "Annabelle48" },
                    { 7, "3229 Ezekiel Bypass", "South Savion", new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(7334), "Customer", "Austin_Hegmann.McCullough@yahoo.com", "1-766-791-9143", "67661", 1, "Oregon", "Austin_Hegmann" },
                    { 8, "0886 Bednar Motorway", "West Aniyah", new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(7548), "Customer", "Zella57_Bergstrom65@yahoo.com", "1-882-692-1255 x7684", "51320-1250", 1, "Utah", "Zella57" }
                });

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 2, 11 },
                    { 3, 11 },
                    { 4, 5 },
                    { 4, 9 },
                    { 4, 15 },
                    { 5, 3 },
                    { 5, 4 },
                    { 5, 5 },
                    { 5, 7 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Created", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 9, new DateTime(2024, 12, 31, 6, 3, 48, 924, DateTimeKind.Local).AddTicks(4135), 104, 3036.40m, 2, 8 },
                    { 24, new DateTime(2024, 12, 31, 6, 3, 48, 933, DateTimeKind.Local).AddTicks(3800), 110, 1759.52m, 5, 7 },
                    { 26, new DateTime(2024, 12, 31, 6, 3, 48, 934, DateTimeKind.Local).AddTicks(8139), 111, 502.72m, 5, 2 },
                    { 29, new DateTime(2024, 12, 31, 6, 3, 48, 936, DateTimeKind.Local).AddTicks(2669), 112, 720.33m, 6, 3 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Created", "Date", "GiftCardId", "OrderStatus", "UsedCouponCode", "UserId" },
                values: new object[,]
                {
                    { 103, new DateTime(2024, 12, 31, 6, 3, 48, 916, DateTimeKind.Local).AddTicks(3937), new DateTime(2024, 12, 20, 4, 15, 55, 272, DateTimeKind.Local).AddTicks(3948), null, 3, null, 8 },
                    { 105, new DateTime(2024, 12, 31, 6, 3, 48, 916, DateTimeKind.Local).AddTicks(3994), new DateTime(2023, 8, 19, 21, 13, 48, 911, DateTimeKind.Local).AddTicks(5009), null, 0, null, 7 },
                    { 106, new DateTime(2024, 12, 31, 6, 3, 48, 916, DateTimeKind.Local).AddTicks(4025), new DateTime(2024, 3, 8, 14, 53, 44, 594, DateTimeKind.Local).AddTicks(2250), null, 1, null, 6 },
                    { 107, new DateTime(2024, 12, 31, 6, 3, 48, 916, DateTimeKind.Local).AddTicks(4054), new DateTime(2023, 10, 28, 9, 49, 59, 148, DateTimeKind.Local).AddTicks(1261), null, 1, null, 6 },
                    { 108, new DateTime(2024, 12, 31, 6, 3, 48, 916, DateTimeKind.Local).AddTicks(4081), new DateTime(2023, 12, 14, 2, 56, 17, 458, DateTimeKind.Local).AddTicks(9103), null, 0, null, 8 },
                    { 109, new DateTime(2024, 12, 31, 6, 3, 48, 916, DateTimeKind.Local).AddTicks(4109), new DateTime(2023, 7, 19, 1, 7, 26, 738, DateTimeKind.Local).AddTicks(6718), null, 3, null, 8 },
                    { 113, new DateTime(2024, 12, 31, 6, 3, 48, 916, DateTimeKind.Local).AddTicks(4223), new DateTime(2023, 5, 12, 9, 5, 4, 932, DateTimeKind.Local).AddTicks(332), null, 1, null, 6 },
                    { 114, new DateTime(2024, 12, 31, 6, 3, 48, 916, DateTimeKind.Local).AddTicks(4253), new DateTime(2023, 9, 14, 19, 40, 15, 900, DateTimeKind.Local).AddTicks(5832), null, 2, null, 6 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Created", "Description", "EditCount", "LastModifiedById", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[,]
                {
                    { 8, new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(8283), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 5, 1, 7, "Synthesizer Plugins", 248.43m, 4, 46 },
                    { 10, new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(8295), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 5, 1, 2, "Sheet Music Collections", 717.87m, 5, 22 },
                    { 12, new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(8310), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 3, 1, 6, "Plugin Bundles", 79.10m, 4, 15 },
                    { 13, new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(8316), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 1, 1, 7, "Synthesizer Plugins", 960.13m, 4, 4 },
                    { 14, new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(8322), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 5, 1, 7, "Music Theory Books", 69.14m, 5, 25 },
                    { 16, new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(8336), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 1, 1, 7, "Guitar Picks", 977.14m, 2, 95 },
                    { 17, new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(8343), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 1, 1, 6, "Karaoke Machines", 755.54m, 3, 32 },
                    { 18, new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(8351), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 5, 1, 7, "Amplifiers", 723.07m, 3, 84 },
                    { 19, new DateTime(2024, 12, 31, 6, 3, 48, 913, DateTimeKind.Local).AddTicks(8358), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 4, 1, 6, "Headphones", 436.86m, 3, 6 }
                });

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 12 },
                    { 1, 13 },
                    { 1, 18 },
                    { 2, 10 },
                    { 2, 12 },
                    { 2, 17 },
                    { 2, 18 },
                    { 2, 19 },
                    { 3, 10 },
                    { 3, 13 },
                    { 3, 16 },
                    { 4, 10 },
                    { 4, 17 },
                    { 4, 19 },
                    { 5, 8 },
                    { 5, 13 },
                    { 5, 17 },
                    { 5, 18 },
                    { 5, 19 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Created", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 8, new DateTime(2024, 12, 31, 6, 3, 48, 924, DateTimeKind.Local).AddTicks(3775), 104, 316.40m, 12, 4 },
                    { 10, new DateTime(2024, 12, 31, 6, 3, 48, 924, DateTimeKind.Local).AddTicks(4155), 104, 1954.28m, 16, 2 },
                    { 11, new DateTime(2024, 12, 31, 6, 3, 48, 924, DateTimeKind.Local).AddTicks(4174), 104, 138.28m, 14, 2 },
                    { 12, new DateTime(2024, 12, 31, 6, 3, 48, 926, DateTimeKind.Local).AddTicks(239), 105, 222.62m, 7, 2 },
                    { 13, new DateTime(2024, 12, 31, 6, 3, 48, 926, DateTimeKind.Local).AddTicks(576), 105, 414.84m, 14, 6 },
                    { 14, new DateTime(2024, 12, 31, 6, 3, 48, 927, DateTimeKind.Local).AddTicks(4961), 106, 791.00m, 12, 10 },
                    { 15, new DateTime(2024, 12, 31, 6, 3, 48, 927, DateTimeKind.Local).AddTicks(5201), 106, 316.40m, 12, 4 },
                    { 16, new DateTime(2024, 12, 31, 6, 3, 48, 928, DateTimeKind.Local).AddTicks(9323), 107, 1800.24m, 9, 6 },
                    { 17, new DateTime(2024, 12, 31, 6, 3, 48, 928, DateTimeKind.Local).AddTicks(9549), 107, 69.14m, 14, 1 },
                    { 18, new DateTime(2024, 12, 31, 6, 3, 48, 928, DateTimeKind.Local).AddTicks(9571), 107, 333.93m, 7, 3 },
                    { 19, new DateTime(2024, 12, 31, 6, 3, 48, 930, DateTimeKind.Local).AddTicks(3675), 108, 779.17m, 7, 7 },
                    { 20, new DateTime(2024, 12, 31, 6, 3, 48, 930, DateTimeKind.Local).AddTicks(3894), 108, 436.86m, 19, 1 },
                    { 21, new DateTime(2024, 12, 31, 6, 3, 48, 931, DateTimeKind.Local).AddTicks(8775), 109, 1256.80m, 5, 5 },
                    { 22, new DateTime(2024, 12, 31, 6, 3, 48, 931, DateTimeKind.Local).AddTicks(9078), 109, 960.44m, 6, 4 },
                    { 23, new DateTime(2024, 12, 31, 6, 3, 48, 933, DateTimeKind.Local).AddTicks(3570), 110, 993.72m, 8, 4 },
                    { 25, new DateTime(2024, 12, 31, 6, 3, 48, 934, DateTimeKind.Local).AddTicks(7920), 111, 237.30m, 12, 3 },
                    { 27, new DateTime(2024, 12, 31, 6, 3, 48, 936, DateTimeKind.Local).AddTicks(2428), 112, 158.20m, 12, 2 },
                    { 28, new DateTime(2024, 12, 31, 6, 3, 48, 936, DateTimeKind.Local).AddTicks(2645), 112, 3777.70m, 17, 5 },
                    { 30, new DateTime(2024, 12, 31, 6, 3, 48, 937, DateTimeKind.Local).AddTicks(6777), 113, 2169.21m, 18, 3 },
                    { 31, new DateTime(2024, 12, 31, 6, 3, 48, 937, DateTimeKind.Local).AddTicks(6997), 113, 251.36m, 5, 1 },
                    { 32, new DateTime(2024, 12, 31, 6, 3, 48, 937, DateTimeKind.Local).AddTicks(7015), 113, 2513.60m, 5, 10 },
                    { 33, new DateTime(2024, 12, 31, 6, 3, 48, 939, DateTimeKind.Local).AddTicks(1403), 114, 251.36m, 5, 1 },
                    { 34, new DateTime(2024, 12, 31, 6, 3, 48, 939, DateTimeKind.Local).AddTicks(1666), 114, 1512.65m, 3, 5 },
                    { 35, new DateTime(2024, 12, 31, 6, 3, 48, 939, DateTimeKind.Local).AddTicks(1684), 114, 553.70m, 12, 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 12 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 13 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 18 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 11 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 17 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 18 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 19 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 11 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 13 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 16 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 4, 15 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 4, 17 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 4, 19 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 5, 13 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 5, 17 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 5, 18 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 5, 19 });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 31, 4, 52, 55, 569, DateTimeKind.Local).AddTicks(8799));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 31, 4, 52, 55, 569, DateTimeKind.Local).AddTicks(8830));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 31, 4, 52, 55, 569, DateTimeKind.Local).AddTicks(8834));

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 1, 6 },
                    { 2, 1 },
                    { 2, 5 },
                    { 3, 4 },
                    { 3, 5 },
                    { 3, 6 }
                });

            migrationBuilder.UpdateData(
                table: "CouponCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 30, 4, 52, 55, 579, DateTimeKind.Local).AddTicks(23));

            migrationBuilder.UpdateData(
                table: "CouponCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 30, 4, 52, 55, 579, DateTimeKind.Local).AddTicks(34));

            migrationBuilder.UpdateData(
                table: "CouponCodes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 10, 31, 4, 52, 55, 579, DateTimeKind.Local).AddTicks(41));

            migrationBuilder.UpdateData(
                table: "CouponCodes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 10, 31, 4, 52, 55, 579, DateTimeKind.Local).AddTicks(48));

            migrationBuilder.UpdateData(
                table: "GiftCards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "ValidityEndDate", "ValidityStartDate" },
                values: new object[] { new DateTime(2024, 11, 30, 4, 52, 55, 579, DateTimeKind.Local).AddTicks(93), new DateTime(2025, 6, 30, 4, 52, 55, 579, DateTimeKind.Local).AddTicks(100), new DateTime(2024, 11, 30, 4, 52, 55, 579, DateTimeKind.Local).AddTicks(97) });

            migrationBuilder.UpdateData(
                table: "GiftCards",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "ValidityEndDate", "ValidityStartDate" },
                values: new object[] { new DateTime(2024, 10, 31, 4, 52, 55, 579, DateTimeKind.Local).AddTicks(109), new DateTime(2025, 4, 30, 4, 52, 55, 579, DateTimeKind.Local).AddTicks(116), new DateTime(2024, 10, 31, 4, 52, 55, 579, DateTimeKind.Local).AddTicks(113) });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 572, DateTimeKind.Local).AddTicks(4931), "Cremin - O'Hara" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 572, DateTimeKind.Local).AddTicks(7454), "O'Keefe, Sporer and O'Hara" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 572, DateTimeKind.Local).AddTicks(7776), "Dickens Group" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 572, DateTimeKind.Local).AddTicks(7917), "Harber, Turcotte and Towne" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 572, DateTimeKind.Local).AddTicks(8070), "Conroy - Jakubowski" });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9939), 1, 99.99m, 1, 1 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9947), 1, 21.99m, 2, 2 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9951), 2, 280m, 3, 100 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9957), 3, 499.99m, 4, 5 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9960), 3, 720.05m, 5, 1 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9965), 4, 29.99m, 6, 3 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9969), 5, 25.54m, 6, 2 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Created", "Date", "GiftCardId", "OrderStatus", "UsedCouponCode", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9867), new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, 2 },
                    { 2, new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9879), new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, 3 },
                    { 3, new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9886), new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, 3 },
                    { 4, new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9893), new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, 2 },
                    { 5, new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9900), new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9770), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 5, 1, "Instrument Cases", 122.71m, 3, 17 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Description", "EditCount", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9783), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 7, "Microphone Stands", 388.74m, 2, 88 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9789), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 8, 1, "Saxophone", 75.84m, 3, 87 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9795), 8, 1, "Tuners", 212.88m, 1, 93 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9800), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 1, 4, "Replacement Strings", 686.70m, 1, 97 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9807), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 2, 3, "Stage Lighting Kits", 147.63m, 39 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9812), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 10, 1, "Violin", 839.63m, 32 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "89950 Nikolaus Mills", "East Fern", new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(5871), "Eloise.Aufderhar_Jacobson46@hotmail.com", "+891 300 957 876", "90113", "Wisconsin", "Eloise.Aufderhar" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "101 Teagan Crest", "Walshland", new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(8591), "Loyce.Roob45.Cassin68@gmail.com", "+984 753 417 865", "11190-8586", "Vermont", "Loyce.Roob45" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "415 Orn Prairie", "New Zoila", new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(8949), "Brisa.Berge27@hotmail.com", "+037 785 815 319", "96668", "California", "Brisa.Berge" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "835 Colten Courts", "Ondrickatown", new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9210), "Armani55.Huel@yahoo.com", "+211 397 045 098", "20019-3159", "New Mexico", "Armani55" });
        }
    }
}
