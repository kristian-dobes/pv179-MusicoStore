using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.SQLite.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class fixsecondarycategoryseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 3 });

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

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 28, 23, 27, 24, 443, DateTimeKind.Local).AddTicks(2314));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 28, 23, 27, 24, 443, DateTimeKind.Local).AddTicks(2363));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 28, 23, 27, 24, 443, DateTimeKind.Local).AddTicks(2365));

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 5 },
                    { 1, 7 },
                    { 2, 4 },
                    { 3, 1 },
                    { 3, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 28, 23, 27, 24, 444, DateTimeKind.Local).AddTicks(8559), "O'Hara, MacGyver and Dietrich" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 28, 23, 27, 24, 445, DateTimeKind.Local).AddTicks(1646), "Rath - Ratke" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 28, 23, 27, 24, 445, DateTimeKind.Local).AddTicks(2037), "Dickinson - McGlynn" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 28, 23, 27, 24, 445, DateTimeKind.Local).AddTicks(2117), "Spinka LLC" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 28, 23, 27, 24, 445, DateTimeKind.Local).AddTicks(2271), "Shanahan, Bins and Tillman" });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 28, 23, 27, 24, 449, DateTimeKind.Local).AddTicks(2270));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 28, 23, 27, 24, 449, DateTimeKind.Local).AddTicks(2274));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 28, 23, 27, 24, 449, DateTimeKind.Local).AddTicks(2277));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 12, 28, 23, 27, 24, 449, DateTimeKind.Local).AddTicks(2281));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 12, 28, 23, 27, 24, 449, DateTimeKind.Local).AddTicks(2283));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2024, 12, 28, 23, 27, 24, 449, DateTimeKind.Local).AddTicks(2286));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2024, 12, 28, 23, 27, 24, 449, DateTimeKind.Local).AddTicks(2288));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 28, 23, 27, 24, 449, DateTimeKind.Local).AddTicks(2248));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 28, 23, 27, 24, 449, DateTimeKind.Local).AddTicks(2254));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 28, 23, 27, 24, 449, DateTimeKind.Local).AddTicks(2257));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 12, 28, 23, 27, 24, 449, DateTimeKind.Local).AddTicks(2261));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 12, 28, 23, 27, 24, 449, DateTimeKind.Local).AddTicks(2265));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 28, 22, 27, 24, 449, DateTimeKind.Utc).AddTicks(2446));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 28, 22, 27, 24, 449, DateTimeKind.Utc).AddTicks(2452));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 23, 27, 24, 449, DateTimeKind.Local).AddTicks(2152), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 7, 3, "Amplifiers", 941.45m, 2, 44 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 23, 27, 24, 449, DateTimeKind.Local).AddTicks(2164), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 9, 3, "Tuners", 232.44m, 3, 84 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 23, 27, 24, 449, DateTimeKind.Local).AddTicks(2167), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 2, 3, "Stage Lighting Kits", 231.21m, 1, 71 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Description", "EditCount", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 23, 27, 24, 449, DateTimeKind.Local).AddTicks(2170), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 4, "Acoustic Guitar", 910.29m, 3, 41 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 23, 27, 24, 449, DateTimeKind.Local).AddTicks(2173), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 3, 3, "Acoustic Guitar", 822.91m, 3, 46 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Description", "EditCount", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 23, 27, 24, 449, DateTimeKind.Local).AddTicks(2177), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 5, "Karaoke Machines", 642.54m, 26 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 23, 27, 24, 449, DateTimeKind.Local).AddTicks(2180), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 1, 1, "Microphone Stands", 995.16m, 2, 40 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "25896 Ondricka Springs", "South Augustus", new DateTime(2024, 12, 28, 23, 27, 24, 448, DateTimeKind.Local).AddTicks(7891), "Blaise98_Wyman9@gmail.com", "+447 127 434 382", "86552-7727", "Oregon", "Blaise98" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "61416 Timmy Station", "New King", new DateTime(2024, 12, 28, 23, 27, 24, 449, DateTimeKind.Local).AddTicks(1005), "Karlee.Daniel49.Larson@hotmail.com", "+076 807 890 923", "30664", "Idaho", "Karlee.Daniel49" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "5990 Novella Court", "Port Luzshire", new DateTime(2024, 12, 28, 23, 27, 24, 449, DateTimeKind.Local).AddTicks(1333), "Devyn7740@gmail.com", "+598 360 292 712", "00673", "Oregon", "Devyn77" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "24303 Kreiger Crossing", "Eusebiomouth", new DateTime(2024, 12, 28, 23, 27, 24, 449, DateTimeKind.Local).AddTicks(1560), "Else_Kozey_Ruecker51@gmail.com", "+348 971 577 998", "93699", "Washington", "Else_Kozey" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 28, 19, 38, 28, 739, DateTimeKind.Local).AddTicks(1826));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 28, 19, 38, 28, 739, DateTimeKind.Local).AddTicks(1876));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 28, 19, 38, 28, 739, DateTimeKind.Local).AddTicks(1879));

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 3 },
                    { 2, 7 },
                    { 3, 2 },
                    { 3, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 3, 7 }
                });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 28, 19, 38, 28, 740, DateTimeKind.Local).AddTicks(9204), "Robel Inc" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 28, 19, 38, 28, 741, DateTimeKind.Local).AddTicks(2200), "Schumm, Fritsch and Weber" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 28, 19, 38, 28, 741, DateTimeKind.Local).AddTicks(3113), "Green, Stark and Larson" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 28, 19, 38, 28, 741, DateTimeKind.Local).AddTicks(3224), "Funk, Beer and Wolf" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 28, 19, 38, 28, 741, DateTimeKind.Local).AddTicks(3335), "Keeling Group" });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(5423));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(5428));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(5431));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(5435));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(5437));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(5440));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(5443));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(5401));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(5407));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(5410));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(5414));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(5417));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 28, 18, 38, 28, 745, DateTimeKind.Utc).AddTicks(5522));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 28, 18, 38, 28, 745, DateTimeKind.Utc).AddTicks(5527));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(5298), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 8, 4, "Karaoke Machines", 902.55m, 3, 11 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(5310), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 5, 4, "Instrument Cases", 221.10m, 2, 56 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(5313), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 9, 5, "Drum Kit", 46.75m, 3, 86 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Description", "EditCount", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(5317), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 1, "Saxophone", 341.35m, 2, 90 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(5320), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 10, 5, "Amplifiers", 249.86m, 1, 42 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Description", "EditCount", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(5325), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 3, "Instrument Cases", 604.39m, 73 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(5328), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 8, 5, "Guitar Picks", 41.43m, 1, 86 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "24556 Felicity Well", "North Kolbyshire", new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(856), "Rebekah78_Renner20@yahoo.com", "+688 078 820 101", "05467", "Mississippi", "Rebekah78" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "268 Konopelski Plaza", "Donmouth", new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(4091), "Dane_Kemmer20_Armstrong@yahoo.com", "+203 556 661 251", "45048-4531", "Illinois", "Dane_Kemmer20" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "5191 River Lodge", "Herbertburgh", new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(4447), "Jonathon.Ritchie.Swaniawski@yahoo.com", "+658 919 413 811", "08968", "Georgia", "Jonathon.Ritchie" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "79312 Ayla Ridges", "Gerhardton", new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(4682), "Ned_Jacobson3_Brekke73@hotmail.com", "+331 474 435 528", "02882-8197", "West Virginia", "Ned_Jacobson3" });
        }
    }
}
