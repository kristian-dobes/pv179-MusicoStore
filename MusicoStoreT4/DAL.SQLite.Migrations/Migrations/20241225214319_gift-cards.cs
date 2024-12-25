using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.SQLite.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class giftcards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GiftCardId",
                table: "Orders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GiftCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiscountAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValidityStartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValidityEndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftCard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CouponCode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    IsUsed = table.Column<bool>(type: "INTEGER", nullable: false),
                    GiftCardId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CouponCode_GiftCard_GiftCardId",
                        column: x => x.GiftCardId,
                        principalTable: "GiftCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CouponCode_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 25, 22, 43, 19, 56, DateTimeKind.Local).AddTicks(2868));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 25, 22, 43, 19, 56, DateTimeKind.Local).AddTicks(2911));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 25, 22, 43, 19, 56, DateTimeKind.Local).AddTicks(2913));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 25, 22, 43, 19, 57, DateTimeKind.Local).AddTicks(8249), "Gleichner - Kris" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 25, 22, 43, 19, 58, DateTimeKind.Local).AddTicks(841), "Nicolas, Rutherford and Raynor" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 25, 22, 43, 19, 58, DateTimeKind.Local).AddTicks(1143), "Mills Group" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 25, 22, 43, 19, 58, DateTimeKind.Local).AddTicks(1277), "Considine - Casper" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 25, 22, 43, 19, 58, DateTimeKind.Local).AddTicks(1355), "Johnston, Jacobs and Casper" });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 25, 22, 43, 19, 62, DateTimeKind.Local).AddTicks(8442));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 25, 22, 43, 19, 62, DateTimeKind.Local).AddTicks(8446));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 25, 22, 43, 19, 62, DateTimeKind.Local).AddTicks(8449));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 12, 25, 22, 43, 19, 62, DateTimeKind.Local).AddTicks(8452));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "OrderId" },
                values: new object[] { new DateTime(2024, 12, 25, 22, 43, 19, 62, DateTimeKind.Local).AddTicks(8455), 3 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "OrderId" },
                values: new object[] { new DateTime(2024, 12, 25, 22, 43, 19, 62, DateTimeKind.Local).AddTicks(8458), 4 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "OrderId" },
                values: new object[] { new DateTime(2024, 12, 25, 22, 43, 19, 62, DateTimeKind.Local).AddTicks(8460), 5 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "GiftCardId", "OrderStatus" },
                values: new object[] { new DateTime(2024, 12, 25, 22, 43, 19, 62, DateTimeKind.Local).AddTicks(8420), null, 0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "GiftCardId", "OrderStatus" },
                values: new object[] { new DateTime(2024, 12, 25, 22, 43, 19, 62, DateTimeKind.Local).AddTicks(8426), null, 0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "GiftCardId", "OrderStatus" },
                values: new object[] { new DateTime(2024, 12, 25, 22, 43, 19, 62, DateTimeKind.Local).AddTicks(8429), null, 0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "GiftCardId", "OrderStatus" },
                values: new object[] { new DateTime(2024, 12, 25, 22, 43, 19, 62, DateTimeKind.Local).AddTicks(8432), null, 0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "GiftCardId", "OrderStatus" },
                values: new object[] { new DateTime(2024, 12, 25, 22, 43, 19, 62, DateTimeKind.Local).AddTicks(8436), null, 0 });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 25, 21, 43, 19, 62, DateTimeKind.Utc).AddTicks(8523));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 25, 21, 43, 19, 62, DateTimeKind.Utc).AddTicks(8528));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 25, 22, 43, 19, 60, DateTimeKind.Local).AddTicks(6979), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 8, 3, "Digital Piano", 565.362568440393670m, 8 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Created", "Description", "Name", "Price", "QuantityInStock" },
                values: new object[] { 1, new DateTime(2024, 12, 25, 22, 43, 19, 60, DateTimeKind.Local).AddTicks(9088), "The Football Is Good For Training And Recreational Purposes", "Replacement Strings", 684.96010820961580m, 61 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price" },
                values: new object[] { 3, new DateTime(2024, 12, 25, 22, 43, 19, 60, DateTimeKind.Local).AddTicks(9146), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 8, 1, "Amplifiers", 897.109330520378350m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 25, 22, 43, 19, 60, DateTimeKind.Local).AddTicks(9171), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 10, 3, "Violin", 222.696079361963560m, 42 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 12, 25, 22, 43, 19, 60, DateTimeKind.Local).AddTicks(9192), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 2, "Studio Monitors", 115.322522072856220m, 89 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Description", "EditCount", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 25, 22, 43, 19, 60, DateTimeKind.Local).AddTicks(9213), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 5, "Digital Piano", 401.858894914975180m, 89 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Description", "EditCount", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 25, 22, 43, 19, 60, DateTimeKind.Local).AddTicks(9232), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 3, "Karaoke Machines", 977.352757469786710m, 77 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "0490 Nasir Union", "Hansenshire", new DateTime(2024, 12, 25, 22, 43, 19, 62, DateTimeKind.Local).AddTicks(4189), "Tyrel_OConner29@gmail.com", "+043 037 356 960", "53132", "North Carolina", "Tyrel_OConner" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "682 McGlynn Road", "Lake Jaleelburgh", new DateTime(2024, 12, 25, 22, 43, 19, 62, DateTimeKind.Local).AddTicks(7377), "Marie.Morissette33_Grant23@yahoo.com", "+587 610 536 109", "22872", "Idaho", "Marie.Morissette33" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "75534 Champlin Pine", "Rebeccaland", new DateTime(2024, 12, 25, 22, 43, 19, 62, DateTimeKind.Local).AddTicks(7698), "Daren91.Kling42@gmail.com", "+375 947 240 784", "47305-4504", "Tennessee", "Daren91" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "565 Robel Isle", "Octavialand", new DateTime(2024, 12, 25, 22, 43, 19, 62, DateTimeKind.Local).AddTicks(7927), "Chadd90_Schuppe9@gmail.com", "+249 538 552 023", "14606-0254", "North Carolina", "Chadd90" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_GiftCardId",
                table: "Orders",
                column: "GiftCardId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponCode_GiftCardId",
                table: "CouponCode",
                column: "GiftCardId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponCode_OrderId",
                table: "CouponCode",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_GiftCard_GiftCardId",
                table: "Orders",
                column: "GiftCardId",
                principalTable: "GiftCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_GiftCard_GiftCardId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "CouponCode");

            migrationBuilder.DropTable(
                name: "GiftCard");

            migrationBuilder.DropIndex(
                name: "IX_Orders_GiftCardId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "GiftCardId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 23, 22, 41, 5, 370, DateTimeKind.Local).AddTicks(7819));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 23, 22, 41, 5, 370, DateTimeKind.Local).AddTicks(7857));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 23, 22, 41, 5, 370, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 23, 22, 41, 5, 372, DateTimeKind.Local).AddTicks(3189), "Beatty LLC" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 23, 22, 41, 5, 372, DateTimeKind.Local).AddTicks(5805), "Weissnat, Wolf and Cronin" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 23, 22, 41, 5, 372, DateTimeKind.Local).AddTicks(6180), "Klein and Sons" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 23, 22, 41, 5, 372, DateTimeKind.Local).AddTicks(6277), "Gleichner - Hirthe" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 23, 22, 41, 5, 372, DateTimeKind.Local).AddTicks(6362), "Ernser, Beier and Leffler" });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 23, 22, 41, 5, 376, DateTimeKind.Local).AddTicks(3046));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 23, 22, 41, 5, 376, DateTimeKind.Local).AddTicks(3053));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 23, 22, 41, 5, 376, DateTimeKind.Local).AddTicks(3056));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 12, 23, 22, 41, 5, 376, DateTimeKind.Local).AddTicks(3059));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "OrderId" },
                values: new object[] { new DateTime(2024, 12, 23, 22, 41, 5, 376, DateTimeKind.Local).AddTicks(3062), 4 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "OrderId" },
                values: new object[] { new DateTime(2024, 12, 23, 22, 41, 5, 376, DateTimeKind.Local).AddTicks(3065), 5 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "OrderId" },
                values: new object[] { new DateTime(2024, 12, 23, 22, 41, 5, 376, DateTimeKind.Local).AddTicks(3068), 4 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 23, 22, 41, 5, 376, DateTimeKind.Local).AddTicks(3021));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 23, 22, 41, 5, 376, DateTimeKind.Local).AddTicks(3029));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 23, 22, 41, 5, 376, DateTimeKind.Local).AddTicks(3033));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 12, 23, 22, 41, 5, 376, DateTimeKind.Local).AddTicks(3037));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 12, 23, 22, 41, 5, 376, DateTimeKind.Local).AddTicks(3040));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 23, 21, 41, 5, 376, DateTimeKind.Utc).AddTicks(3137));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 23, 21, 41, 5, 376, DateTimeKind.Utc).AddTicks(3141));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 23, 22, 41, 5, 374, DateTimeKind.Local).AddTicks(1754), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 2, 1, "Instrument Cases", 916.756656955665670m, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Created", "Description", "Name", "Price", "QuantityInStock" },
                values: new object[] { 2, new DateTime(2024, 12, 23, 22, 41, 5, 374, DateTimeKind.Local).AddTicks(3893), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Stage Lighting Kits", 696.452188913228980m, 20 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price" },
                values: new object[] { 1, new DateTime(2024, 12, 23, 22, 41, 5, 374, DateTimeKind.Local).AddTicks(3949), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 9, 5, "Tuners", 827.323363910434150m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 23, 22, 41, 5, 374, DateTimeKind.Local).AddTicks(3972), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 6, 2, "PA Systems", 77.8222499204874250m, 74 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "Name", "Price", "QuantityInStock" },
                values: new object[] { 2, new DateTime(2024, 12, 23, 22, 41, 5, 374, DateTimeKind.Local).AddTicks(3994), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 4, "Violin", 849.776702110556320m, 76 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Description", "EditCount", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 23, 22, 41, 5, 374, DateTimeKind.Local).AddTicks(4016), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 2, "Amplifiers", 433.57686887410840m, 11 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Description", "EditCount", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 23, 22, 41, 5, 374, DateTimeKind.Local).AddTicks(4037), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 1, "Tuners", 783.379086455068390m, 29 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "216 Karl Locks", "South Kristianview", new DateTime(2024, 12, 23, 22, 41, 5, 375, DateTimeKind.Local).AddTicks(9082), "Stanton15_Abbott83@hotmail.com", "+718 215 150 102", "62342-5756", "Florida", "Stanton15" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "3095 Littel Plains", "Goodwinville", new DateTime(2024, 12, 23, 22, 41, 5, 376, DateTimeKind.Local).AddTicks(2021), "Sydney3358@gmail.com", "+352 888 458 091", "57712-9318", "New Mexico", "Sydney33" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "7834 Kshlerin Ports", "New Lonnie", new DateTime(2024, 12, 23, 22, 41, 5, 376, DateTimeKind.Local).AddTicks(2305), "Ida_Fahey187@yahoo.com", "+980 902 011 823", "68552", "Florida", "Ida_Fahey1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "39363 Zieme Overpass", "McClureburgh", new DateTime(2024, 12, 23, 22, 41, 5, 376, DateTimeKind.Local).AddTicks(2524), "Willie_Bailey1017@gmail.com", "+992 488 379 498", "19758-6313", "Nevada", "Willie_Bailey10" });
        }
    }
}
