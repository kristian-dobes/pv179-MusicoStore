using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.SQLite.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class OrderUsedCouponCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "UsedCouponCode",
                table: "Orders",
                type: "TEXT",
                nullable: true);

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
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 7 },
                    { 3, 2 },
                    { 3, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 3, 7 }
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
                column: "Created",
                value: new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9939));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9947));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9951));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9957));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9960));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9965));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9969));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "UsedCouponCode" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9867), null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "UsedCouponCode" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9879), null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "UsedCouponCode" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9886), null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "UsedCouponCode" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9893), null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "UsedCouponCode" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9900), null });

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
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9783), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 7, 1, "Microphone Stands", 388.74m, 2, 88 });

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
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9795), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 8, 1, "Tuners", 212.88m, 1, 93 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9800), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 1, 4, 686.70m, 1, 97 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9807), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 2, 3, "Stage Lighting Kits", 147.63m, 2, 39 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 31, 4, 52, 55, 578, DateTimeKind.Local).AddTicks(9812), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 10, 1, "Violin", 839.63m, 1, 32 });

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

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProduct_Categories_CategoryId",
                table: "CategoryProduct",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProduct_Products_ProductId",
                table: "CategoryProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProduct_Categories_CategoryId",
                table: "CategoryProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProduct_Products_ProductId",
                table: "CategoryProduct");

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 2 });

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
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DropColumn(
                name: "UsedCouponCode",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 28, 17, 17, 20, 839, DateTimeKind.Local).AddTicks(9844));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 28, 17, 17, 20, 839, DateTimeKind.Local).AddTicks(9887));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 28, 17, 17, 20, 839, DateTimeKind.Local).AddTicks(9889));

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 5 },
                    { 1, 7 },
                    { 3, 1 },
                    { 3, 3 }
                });

            migrationBuilder.UpdateData(
                table: "CouponCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1117));

            migrationBuilder.UpdateData(
                table: "CouponCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1125));

            migrationBuilder.UpdateData(
                table: "CouponCodes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 10, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1129));

            migrationBuilder.UpdateData(
                table: "CouponCodes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 10, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1133));

            migrationBuilder.UpdateData(
                table: "GiftCards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "ValidityEndDate", "ValidityStartDate" },
                values: new object[] { new DateTime(2024, 11, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1166), new DateTime(2025, 6, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1169), new DateTime(2024, 11, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1168) });

            migrationBuilder.UpdateData(
                table: "GiftCards",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "ValidityEndDate", "ValidityStartDate" },
                values: new object[] { new DateTime(2024, 10, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1174), new DateTime(2025, 4, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1177), new DateTime(2024, 10, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1176) });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 28, 17, 17, 20, 841, DateTimeKind.Local).AddTicks(5627), "Ryan, Gleichner and Tromp" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 28, 17, 17, 20, 841, DateTimeKind.Local).AddTicks(8984), "Dietrich, Jast and Stokes" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 28, 17, 17, 20, 841, DateTimeKind.Local).AddTicks(9289), "Cormier and Sons" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 28, 17, 17, 20, 842, DateTimeKind.Local).AddTicks(2443), "Hilpert and Sons" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 28, 17, 17, 20, 842, DateTimeKind.Local).AddTicks(3512), "Spinka - Larkin" });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(992));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(996));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(999));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 12, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1003));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 12, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1005));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2024, 12, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1008));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2024, 12, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1011));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(970));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(976));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(979));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 12, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(983));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 12, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(987));

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Created", "FileName", "FilePath", "MimeType", "ProductId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 28, 16, 17, 20, 846, DateTimeKind.Utc).AddTicks(1079), "drums.png", "images\\drums.png", "image/png", 3 },
                    { 2, new DateTime(2024, 12, 28, 16, 17, 20, 846, DateTimeKind.Utc).AddTicks(1082), "guitar.png", "images\\guitar.png", "image/png", 5 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 17, 17, 20, 843, DateTimeKind.Local).AddTicks(9232), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 4, 2, "Drum Kit", 570.172504559409280m, 0, 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 17, 17, 20, 844, DateTimeKind.Local).AddTicks(1556), "The Football Is Good For Training And Recreational Purposes", 4, 3, "Violin", 547.355156961588130m, 0, 56 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 17, 17, 20, 844, DateTimeKind.Local).AddTicks(1625), "The Football Is Good For Training And Recreational Purposes", 9, 4, "Amplifiers", 202.803457034509750m, 0, 30 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 17, 17, 20, 844, DateTimeKind.Local).AddTicks(1647), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 2, 5, "Drum Kit", 841.544487096196060m, 0, 82 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 17, 17, 20, 844, DateTimeKind.Local).AddTicks(1667), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 6, 1, 935.232292537739560m, 0, 91 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 17, 17, 20, 844, DateTimeKind.Local).AddTicks(1703), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 6, 4, "Guitar Picks", 612.4402861205410m, 0, 87 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 17, 17, 20, 844, DateTimeKind.Local).AddTicks(1722), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 5, 2, "Amplifiers", 936.598669674414220m, 0, 52 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "36073 Jayde Crossing", "Evanmouth", new DateTime(2024, 12, 28, 17, 17, 20, 845, DateTimeKind.Local).AddTicks(6452), "Jordyn.Prohaska.Dooley87@gmail.com", "+197 249 376 552", "95327", "Rhode Island", "Jordyn.Prohaska" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "99068 Deja Spur", "North Hassanstad", new DateTime(2024, 12, 28, 17, 17, 20, 845, DateTimeKind.Local).AddTicks(9519), "Lee.Weissnat71.Ebert70@yahoo.com", "+799 202 536 199", "76918-0379", "Maryland", "Lee.Weissnat71" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "6728 Morton Heights", "East Eloy", new DateTime(2024, 12, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(135), "Francesco.Ferry8490@gmail.com", "+183 409 832 663", "86292-6467", "Ohio", "Francesco.Ferry84" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "9652 Gerhold Terrace", "Pietrostad", new DateTime(2024, 12, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(379), "Beryl.Pouros72.Becker85@yahoo.com", "+282 764 582 013", "84672-8107", "Illinois", "Beryl.Pouros72" });
        }
    }
}
