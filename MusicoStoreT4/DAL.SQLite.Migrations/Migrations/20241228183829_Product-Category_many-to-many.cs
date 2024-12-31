using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.SQLite.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class ProductCategory_manytomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "PrimaryCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                newName: "IX_Products_PrimaryCategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "Action",
                table: "AuditLogs",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoryId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { 1, 1 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 6 },
                    { 2, 3 },
                    { 2, 5 },
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
                columns: new[] { "Created", "Description", "EditCount", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(5313), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 9, "Drum Kit", 46.75m, 86 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(5317), 1, "Saxophone", 341.35m, 2, 90 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(5320), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 10, 5, 249.86m, 1, 42 });

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
                columns: new[] { "Created", "EditCount", "ManufacturerId", "Name", "Price", "PrimaryCategoryId", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 19, 38, 28, 745, DateTimeKind.Local).AddTicks(5328), 8, 5, "Guitar Picks", 41.43m, 1, 86 });

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

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductId",
                table: "CategoryProduct",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_PrimaryCategoryId",
                table: "Products",
                column: "PrimaryCategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_PrimaryCategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.RenameColumn(
                name: "PrimaryCategoryId",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_PrimaryCategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "AuditLogs",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 22, 14, 51, 50, 965, DateTimeKind.Local).AddTicks(6513));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 22, 14, 51, 50, 965, DateTimeKind.Local).AddTicks(6553));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 22, 14, 51, 50, 965, DateTimeKind.Local).AddTicks(6555));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 51, 50, 967, DateTimeKind.Local).AddTicks(2835), "Miller Group" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 51, 50, 967, DateTimeKind.Local).AddTicks(8561), "Lakin LLC" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 51, 50, 967, DateTimeKind.Local).AddTicks(9862), "Kovacek, Blanda and Gutkowski" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 51, 50, 968, DateTimeKind.Local).AddTicks(59), "Kessler, Goldner and Tremblay" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 51, 50, 968, DateTimeKind.Local).AddTicks(176), "Dickinson Inc" });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4521));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4526));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4528));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4532));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4535));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4538));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4540));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4492));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4502));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4506));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4513));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 22, 13, 51, 50, 973, DateTimeKind.Utc).AddTicks(4606));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 22, 13, 51, 50, 973, DateTimeKind.Utc).AddTicks(4609));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 1, new DateTime(2024, 12, 22, 14, 51, 50, 969, DateTimeKind.Local).AddTicks(6683), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 1, 1, "Amplifiers", 900.335303141710690m, 3 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 12, 22, 14, 51, 50, 969, DateTimeKind.Local).AddTicks(8976), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 2, 2, "Digital Piano", 51.4046968833444760m, 90 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Description", "EditCount", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 51, 50, 969, DateTimeKind.Local).AddTicks(9049), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 2, "Guitar Picks", 93.0524202743082760m, 97 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Created", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 12, 22, 14, 51, 50, 969, DateTimeKind.Local).AddTicks(9071), 5, "Drum Kit", 120.915022801811140m, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "ManufacturerId", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 12, 22, 14, 51, 50, 969, DateTimeKind.Local).AddTicks(9090), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 6, 1, 49.1561730168610870m, 86 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Description", "EditCount", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 51, 50, 969, DateTimeKind.Local).AddTicks(9109), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 6, "Amplifiers", 587.502477246248290m, 35 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "Created", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 12, 22, 14, 51, 50, 969, DateTimeKind.Local).AddTicks(9137), 3, 3, "Violin", 501.311496680687980m, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "2233 Garrison Harbor", "Marjorieview", new DateTime(2024, 12, 22, 14, 51, 50, 971, DateTimeKind.Local).AddTicks(5614), "Noelia.Predovic.Feeney@yahoo.com", "+464 089 730 017", "80174", "Colorado", "Noelia.Predovic" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "01225 Jacobs Ford", "Yvonneton", new DateTime(2024, 12, 22, 14, 51, 50, 971, DateTimeKind.Local).AddTicks(8853), "Weston16.Friesen27@yahoo.com", "+739 782 782 397", "91024-1061", "Wyoming", "Weston16" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "5052 Carolanne Terrace", "Willchester", new DateTime(2024, 12, 22, 14, 51, 50, 971, DateTimeKind.Local).AddTicks(9205), "Horace63_DAmore@gmail.com", "+616 608 412 284", "48218-2775", "Rhode Island", "Horace63" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "6536 Roselyn Shores", "East Danielleville", new DateTime(2024, 12, 22, 14, 51, 50, 972, DateTimeKind.Local).AddTicks(6914), "Christophe60_OReilly90@hotmail.com", "+614 756 499 017", "97384-1882", "Texas", "Christophe60" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
