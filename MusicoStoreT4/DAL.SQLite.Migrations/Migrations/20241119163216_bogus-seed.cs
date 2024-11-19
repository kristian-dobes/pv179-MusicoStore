using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.SQLite.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class bogusseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderItems_OrderItemId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderItemId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2);

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
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "OrderItemId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "OrderItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 19, 17, 32, 15, 454, DateTimeKind.Local).AddTicks(5711), "Instruments" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 19, 17, 32, 15, 454, DateTimeKind.Local).AddTicks(5820), "Accessories" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 19, 17, 32, 15, 454, DateTimeKind.Local).AddTicks(5828), "Equipment" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 19, 17, 32, 15, 458, DateTimeKind.Local).AddTicks(5372), "Herman Inc" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 19, 17, 32, 15, 459, DateTimeKind.Local).AddTicks(1783), "Kemmer, Goldner and Trantow" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 19, 17, 32, 15, 459, DateTimeKind.Local).AddTicks(2756), "Brakus, Miller and Stanton" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 19, 17, 32, 15, 459, DateTimeKind.Local).AddTicks(3264), "Schneider Inc" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Created", "Name" },
                values: new object[] { 5, new DateTime(2024, 11, 19, 17, 32, 15, 459, DateTimeKind.Local).AddTicks(3563), "Jenkins - Bartoletti" });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 19, 17, 32, 15, 474, DateTimeKind.Local).AddTicks(8023));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 19, 17, 32, 15, 474, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 19, 17, 32, 15, 474, DateTimeKind.Local).AddTicks(8052));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 11, 19, 17, 32, 15, 474, DateTimeKind.Local).AddTicks(8065));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 11, 19, 17, 32, 15, 474, DateTimeKind.Local).AddTicks(8076));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2024, 11, 19, 17, 32, 15, 474, DateTimeKind.Local).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2024, 11, 19, 17, 32, 15, 474, DateTimeKind.Local).AddTicks(8101));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 19, 17, 32, 15, 474, DateTimeKind.Local).AddTicks(7914));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 19, 17, 32, 15, 474, DateTimeKind.Local).AddTicks(7943));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 19, 17, 32, 15, 474, DateTimeKind.Local).AddTicks(7964));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 11, 19, 17, 32, 15, 474, DateTimeKind.Local).AddTicks(7984));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 11, 19, 17, 32, 15, 474, DateTimeKind.Local).AddTicks(8004));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 11, 19, 17, 32, 15, 464, DateTimeKind.Local).AddTicks(7559), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 5, "Acoustic Guitar", 294.131160291333520m, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 11, 19, 17, 32, 15, 465, DateTimeKind.Local).AddTicks(1517), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 1, "PA Systems", 205.565336005722760m, 47 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 2, new DateTime(2024, 11, 19, 17, 32, 15, 465, DateTimeKind.Local).AddTicks(1687), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 4, "Saxophone", 575.13010600655290m, 9 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Created", "Description", "Name", "Price", "QuantityInStock" },
                values: new object[] { 1, new DateTime(2024, 11, 19, 17, 32, 15, 465, DateTimeKind.Local).AddTicks(1754), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Digital Piano", 741.332166524702380m, 93 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 11, 19, 17, 32, 15, 465, DateTimeKind.Local).AddTicks(1815), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 2, "Instrument Cases", 215.650002243658060m, 29 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Created", "Description", "Name", "Price", "QuantityInStock" },
                values: new object[] { 2, new DateTime(2024, 11, 19, 17, 32, 15, 465, DateTimeKind.Local).AddTicks(1875), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Acoustic Guitar", 564.097375148073130m, 63 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 2, new DateTime(2024, 11, 19, 17, 32, 15, 465, DateTimeKind.Local).AddTicks(1932), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 2, "PA Systems", 440.167071478381930m, 60 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "8095 Monahan Flat", "Port Mandyburgh", new DateTime(2024, 11, 19, 17, 32, 15, 470, DateTimeKind.Local).AddTicks(4682), "Verdie_Hermann1_Casper32@hotmail.com", "+295 981 389 688", "31622", "North Dakota", "Verdie_Hermann1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "1457 Evert Village", "Nathanielview", new DateTime(2024, 11, 19, 17, 32, 15, 470, DateTimeKind.Local).AddTicks(9989), "Baby_Welch81.Runolfsdottir@yahoo.com", "+236 394 085 884", "44056-8452", "Maryland", "Baby_Welch81" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Created", "Discriminator", "Email", "PhoneNumber", "PostalCode", "Role", "State", "Username" },
                values: new object[,]
                {
                    { 4, "73042 Quitzon Forest", "East Fordton", new DateTime(2024, 11, 19, 17, 32, 15, 471, DateTimeKind.Local).AddTicks(846), "Customer", "Keegan.Cormier63.Goyette@yahoo.com", "+372 630 432 037", "97554", 1, "Indiana", "Keegan.Cormier63" },
                    { 5, "34044 Jasen Manor", "Jameyport", new DateTime(2024, 11, 19, 17, 32, 15, 471, DateTimeKind.Local).AddTicks(1665), "Customer", "Jadon3321@gmail.com", "+734 109 103 854", "54357", 1, "Ohio", "Jadon33" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AddColumn<int>(
                name: "OrderItemId",
                table: "Orders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "OrderItems",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(597), "Musical Instruments" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(601), "Audio Equipment" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(603), "Accessories" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(606), "Shure" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(610), "Yamaha" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(612), "Fender" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(614), "Sennheiser" });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(575));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(579));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(582));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(585));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(588));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(591));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(593));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "OrderItemId" },
                values: new object[] { new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(482), null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "OrderItemId" },
                values: new object[] { new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(488), null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "OrderItemId" },
                values: new object[] { new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(492), null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "OrderItemId" },
                values: new object[] { new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(495), null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "OrderItemId" },
                values: new object[] { new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(499), null });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Created", "FileName", "FilePath", "MimeType", "ProductId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 17, 22, 7, 6, 694, DateTimeKind.Utc).AddTicks(634), "drums.png", "images\\drums.png", "image/png", 3 },
                    { 2, new DateTime(2024, 11, 17, 22, 7, 6, 694, DateTimeKind.Utc).AddTicks(637), "guitar.png", "images\\guitar.png", "image/png", 5 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(505), "Professional condenser microphone for studio recording", 4, "Microphone", 99.99m, 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 1, new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(510), "Music concert DVD of popular artist", 2, "DVD", 19.99m, 50 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(550), "Acoustic guitar with solid spruce top", 1, "Guitar", 299.99m, 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Created", "Description", "Name", "Price", "QuantityInStock" },
                values: new object[] { 2, new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(553), "Digital keyboard with weighted keys", "Keyboard", 499.99m, 3 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(555), "5-piece drum set with cymbals and hardware", 1, "Drum Set", 699.99m, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Created", "Description", "Name", "Price", "QuantityInStock" },
                values: new object[] { 1, new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(559), "Adjustable microphone stand with boom arm", "Microphone Stand", 29.99m, 20 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(561), "Electric bass guitar with active pickups", 4, "Bass Guitar", 399.99m, 8 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[,]
                {
                    { 8, 2, new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(564), "Digital piano with weighted keys and built-in speakers", 3, "Piano", 899.99m, 4 },
                    { 9, 3, new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(566), "Full-size violin with bow and case", 4, "Violin", 199.99m, 6 },
                    { 10, 1, new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(570), "Active studio monitor speaker", 4, "Studio Monitor", 149.99m, 12 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "Straight 68, NC", "Night City", new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(623), "johnny@samurai.nc", "+04 0578 457 666", "1020", "The Free City of Night City", "Johnny Silverhand" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "Botanická 69", "Brno", new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(627), "hluchymuzikant@seznam.cz", "+420 556 556 000", "602 00", "Czechia", "Martin Hluchý" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "Discriminator", "Email", "Role", "Username" },
                values: new object[] { 1, new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(618), "User", "admin@bestmusic.com", 0, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderItemId",
                table: "Orders",
                column: "OrderItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderItems_OrderItemId",
                table: "Orders",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id");
        }
    }
}
