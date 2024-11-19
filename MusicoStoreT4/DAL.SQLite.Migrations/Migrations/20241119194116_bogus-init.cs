using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.SQLite.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class bogusinit : Migration
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

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 19, 20, 41, 14, 988, DateTimeKind.Local).AddTicks(6623), "Instruments" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 19, 20, 41, 14, 988, DateTimeKind.Local).AddTicks(6700), "Accessories" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 19, 20, 41, 14, 988, DateTimeKind.Local).AddTicks(6709), "Equipment" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 19, 20, 41, 14, 993, DateTimeKind.Local).AddTicks(4054), "Cassin Group" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 19, 20, 41, 14, 993, DateTimeKind.Local).AddTicks(9782), "Weissnat - Johns" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 19, 20, 41, 14, 994, DateTimeKind.Local).AddTicks(404), "Waelchi, Murphy and Bergstrom" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 19, 20, 41, 14, 994, DateTimeKind.Local).AddTicks(845), "Swift - Bernhard" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Created", "Name" },
                values: new object[] { 5, new DateTime(2024, 11, 19, 20, 41, 14, 994, DateTimeKind.Local).AddTicks(1042), "Bradtke Group" });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 19, 20, 41, 15, 8, DateTimeKind.Local).AddTicks(7115));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 19, 20, 41, 15, 8, DateTimeKind.Local).AddTicks(7130));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 19, 20, 41, 15, 8, DateTimeKind.Local).AddTicks(7140));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 11, 19, 20, 41, 15, 8, DateTimeKind.Local).AddTicks(7152));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 11, 19, 20, 41, 15, 8, DateTimeKind.Local).AddTicks(7161));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2024, 11, 19, 20, 41, 15, 8, DateTimeKind.Local).AddTicks(7174));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2024, 11, 19, 20, 41, 15, 8, DateTimeKind.Local).AddTicks(7183));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 19, 20, 41, 15, 8, DateTimeKind.Local).AddTicks(7025));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 19, 20, 41, 15, 8, DateTimeKind.Local).AddTicks(7050));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 19, 20, 41, 15, 8, DateTimeKind.Local).AddTicks(7066));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 11, 19, 20, 41, 15, 8, DateTimeKind.Local).AddTicks(7083));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 11, 19, 20, 41, 15, 8, DateTimeKind.Local).AddTicks(7099));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 19, 19, 41, 15, 8, DateTimeKind.Utc).AddTicks(7346));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 19, 19, 41, 15, 8, DateTimeKind.Utc).AddTicks(7360));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 11, 19, 20, 41, 14, 999, DateTimeKind.Local).AddTicks(6470), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 1, "Stage Lighting Kits", 467.831560954574620m, 38 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 11, 19, 20, 41, 15, 0, DateTimeKind.Local).AddTicks(91), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 3, "Acoustic Guitar", 137.863110441171160m, 68 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 11, 19, 20, 41, 15, 0, DateTimeKind.Local).AddTicks(250), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 3, "Acoustic Guitar", 679.87203782267890m, 72 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 11, 19, 20, 41, 15, 0, DateTimeKind.Local).AddTicks(302), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 1, "Tuners", 568.868747298612850m, 48 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 1, new DateTime(2024, 11, 19, 20, 41, 15, 0, DateTimeKind.Local).AddTicks(353), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 3, "Karaoke Machines", 617.884472885447890m, 79 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 11, 19, 20, 41, 15, 0, DateTimeKind.Local).AddTicks(400), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 5, "Drum Kit", 784.195063040735380m, 82 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 2, new DateTime(2024, 11, 19, 20, 41, 15, 0, DateTimeKind.Local).AddTicks(447), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 2, "Stage Lighting Kits", 344.065370759100640m, 92 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "2046 Newton Summit", "North Georgiannabury", new DateTime(2024, 11, 19, 20, 41, 15, 4, DateTimeKind.Local).AddTicks(8868), "Colt.Padberg2140@gmail.com", "+045 370 130 438", "37977", "Colorado", "Colt.Padberg21" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "2472 Frieda Roads", "Shanahanborough", new DateTime(2024, 11, 19, 20, 41, 15, 5, DateTimeKind.Local).AddTicks(3661), "Keshaun_Parisian28@yahoo.com", "+055 913 188 287", "68025", "Kansas", "Keshaun_Parisian" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Created", "Discriminator", "Email", "PhoneNumber", "PostalCode", "Role", "State", "Username" },
                values: new object[,]
                {
                    { 4, "6006 Rolando Ports", "Ozellamouth", new DateTime(2024, 11, 19, 20, 41, 15, 5, DateTimeKind.Local).AddTicks(4434), "Customer", "Immanuel58_Bahringer48@hotmail.com", "+625 984 133 521", "76036", 1, "Virginia", "Immanuel58" },
                    { 5, "21502 Mayer Spring", "Lake Eveline", new DateTime(2024, 11, 19, 20, 41, 15, 5, DateTimeKind.Local).AddTicks(5014), "Customer", "Carson26.Kunde2@hotmail.com", "+538 273 136 433", "32833-8405", 1, "Wisconsin", "Carson26" }
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

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 17, 22, 7, 6, 694, DateTimeKind.Utc).AddTicks(634));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 17, 22, 7, 6, 694, DateTimeKind.Utc).AddTicks(637));

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
                columns: new[] { "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(550), "Acoustic guitar with solid spruce top", 1, "Guitar", 299.99m, 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 2, new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(553), "Digital keyboard with weighted keys", 3, "Keyboard", 499.99m, 3 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(555), "5-piece drum set with cymbals and hardware", 1, "Drum Set", 699.99m, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 1, new DateTime(2024, 11, 17, 23, 7, 6, 694, DateTimeKind.Local).AddTicks(559), "Adjustable microphone stand with boom arm", 1, "Microphone Stand", 29.99m, 20 });

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
