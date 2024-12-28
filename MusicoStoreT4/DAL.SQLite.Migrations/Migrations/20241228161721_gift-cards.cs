using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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

            migrationBuilder.AddColumn<int>(
                name: "Source",
                table: "Logs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GiftCards",
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
                    table.PrimaryKey("PK_GiftCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CouponCodes",
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
                    table.PrimaryKey("PK_CouponCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CouponCodes_GiftCards_GiftCardId",
                        column: x => x.GiftCardId,
                        principalTable: "GiftCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CouponCodes_Orders_OrderId",
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
                table: "GiftCards",
                columns: new[] { "Id", "Created", "DiscountAmount", "ValidityEndDate", "ValidityStartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1166), 200.00m, new DateTime(2025, 6, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1169), new DateTime(2024, 11, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1168) },
                    { 2, new DateTime(2024, 10, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1174), 100.00m, new DateTime(2025, 4, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1177), new DateTime(2024, 10, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1176) }
                });

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
                columns: new[] { "Created", "OrderId" },
                values: new object[] { new DateTime(2024, 12, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1005), 3 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "OrderId" },
                values: new object[] { new DateTime(2024, 12, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1008), 4 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "OrderId" },
                values: new object[] { new DateTime(2024, 12, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1011), 5 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "GiftCardId", "OrderStatus" },
                values: new object[] { new DateTime(2024, 12, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(970), null, 0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "GiftCardId", "OrderStatus" },
                values: new object[] { new DateTime(2024, 12, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(976), null, 0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "GiftCardId", "OrderStatus" },
                values: new object[] { new DateTime(2024, 12, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(979), null, 0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "GiftCardId", "OrderStatus" },
                values: new object[] { new DateTime(2024, 12, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(983), null, 0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "GiftCardId", "OrderStatus" },
                values: new object[] { new DateTime(2024, 12, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(987), null, 0 });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 28, 16, 17, 20, 846, DateTimeKind.Utc).AddTicks(1079));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 28, 16, 17, 20, 846, DateTimeKind.Utc).AddTicks(1082));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "Name", "Price", "QuantityInStock" },
                values: new object[] { 2, new DateTime(2024, 12, 28, 17, 17, 20, 843, DateTimeKind.Local).AddTicks(9232), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 4, "Drum Kit", 570.172504559409280m, 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 12, 28, 17, 17, 20, 844, DateTimeKind.Local).AddTicks(1556), "The Football Is Good For Training And Recreational Purposes", 4, 3, "Violin", 547.355156961588130m, 56 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "EditCount", "ManufacturerId", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 17, 17, 20, 844, DateTimeKind.Local).AddTicks(1625), 9, 4, 202.803457034509750m, 30 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price" },
                values: new object[] { 2, new DateTime(2024, 12, 28, 17, 17, 20, 844, DateTimeKind.Local).AddTicks(1647), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 2, 5, "Drum Kit", 841.544487096196060m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 12, 28, 17, 17, 20, 844, DateTimeKind.Local).AddTicks(1667), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 6, 1, "Replacement Strings", 935.232292537739560m, 91 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 1, new DateTime(2024, 12, 28, 17, 17, 20, 844, DateTimeKind.Local).AddTicks(1703), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 6, 4, "Guitar Picks", 612.4402861205410m, 87 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Description", "EditCount", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 28, 17, 17, 20, 844, DateTimeKind.Local).AddTicks(1722), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 5, "Amplifiers", 936.598669674414220m, 52 });

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

            migrationBuilder.InsertData(
                table: "CouponCodes",
                columns: new[] { "Id", "Code", "Created", "GiftCardId", "IsUsed", "OrderId" },
                values: new object[,]
                {
                    { 1, "GIFT200-1", new DateTime(2024, 11, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1117), 1, false, null },
                    { 2, "GIFT200-2", new DateTime(2024, 11, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1125), 1, false, null },
                    { 3, "GIFT100-1", new DateTime(2024, 10, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1129), 2, false, null },
                    { 4, "GIFT100-2", new DateTime(2024, 10, 28, 17, 17, 20, 846, DateTimeKind.Local).AddTicks(1133), 2, false, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_GiftCardId",
                table: "Orders",
                column: "GiftCardId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponCodes_GiftCardId",
                table: "CouponCodes",
                column: "GiftCardId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponCodes_OrderId",
                table: "CouponCodes",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_GiftCards_GiftCardId",
                table: "Orders",
                column: "GiftCardId",
                principalTable: "GiftCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_GiftCards_GiftCardId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "CouponCodes");

            migrationBuilder.DropTable(
                name: "GiftCards");

            migrationBuilder.DropIndex(
                name: "IX_Orders_GiftCardId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "GiftCardId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Logs");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 20, 19, 12, 32, 41, DateTimeKind.Local).AddTicks(7663));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 20, 19, 12, 32, 41, DateTimeKind.Local).AddTicks(7709));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 20, 19, 12, 32, 41, DateTimeKind.Local).AddTicks(7711));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 20, 19, 12, 32, 43, DateTimeKind.Local).AddTicks(2586), "Simonis - Gusikowski" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 20, 19, 12, 32, 43, DateTimeKind.Local).AddTicks(5610), "Hane LLC" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 20, 19, 12, 32, 43, DateTimeKind.Local).AddTicks(8571), "Zboncak, Gulgowski and Boehm" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 20, 19, 12, 32, 43, DateTimeKind.Local).AddTicks(8811), "Fay, Blick and MacGyver" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 20, 19, 12, 32, 43, DateTimeKind.Local).AddTicks(8920), "Funk, Herman and Gulgowski" });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 20, 19, 12, 32, 47, DateTimeKind.Local).AddTicks(5202));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 20, 19, 12, 32, 47, DateTimeKind.Local).AddTicks(5213));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 20, 19, 12, 32, 47, DateTimeKind.Local).AddTicks(5216));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 12, 20, 19, 12, 32, 47, DateTimeKind.Local).AddTicks(5219));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "OrderId" },
                values: new object[] { new DateTime(2024, 12, 20, 19, 12, 32, 47, DateTimeKind.Local).AddTicks(5222), 4 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "OrderId" },
                values: new object[] { new DateTime(2024, 12, 20, 19, 12, 32, 47, DateTimeKind.Local).AddTicks(5225), 5 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "OrderId" },
                values: new object[] { new DateTime(2024, 12, 20, 19, 12, 32, 47, DateTimeKind.Local).AddTicks(5228), 4 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 20, 19, 12, 32, 47, DateTimeKind.Local).AddTicks(5177));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 20, 19, 12, 32, 47, DateTimeKind.Local).AddTicks(5183));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 20, 19, 12, 32, 47, DateTimeKind.Local).AddTicks(5186));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 12, 20, 19, 12, 32, 47, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 12, 20, 19, 12, 32, 47, DateTimeKind.Local).AddTicks(5194));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 20, 18, 12, 32, 47, DateTimeKind.Utc).AddTicks(5287));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 20, 18, 12, 32, 47, DateTimeKind.Utc).AddTicks(5291));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 12, 20, 19, 12, 32, 45, DateTimeKind.Local).AddTicks(4548), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 8, "Studio Monitors", 285.440906448078580m, 64 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 1, new DateTime(2024, 12, 20, 19, 12, 32, 45, DateTimeKind.Local).AddTicks(6568), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 6, 4, "Studio Monitors", 888.376722137502940m, 11 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "EditCount", "ManufacturerId", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 20, 19, 12, 32, 45, DateTimeKind.Local).AddTicks(6631), 5, 1, 832.920864068872360m, 60 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price" },
                values: new object[] { 3, new DateTime(2024, 12, 20, 19, 12, 32, 45, DateTimeKind.Local).AddTicks(6655), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 5, 1, "Microphone Stands", 142.659807442379470m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 2, new DateTime(2024, 12, 20, 19, 12, 32, 45, DateTimeKind.Local).AddTicks(6674), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 9, 4, "PA Systems", 260.263970053370020m, 46 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 2, new DateTime(2024, 12, 20, 19, 12, 32, 45, DateTimeKind.Local).AddTicks(6693), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 5, 2, "Tuners", 794.708059541154760m, 9 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Description", "EditCount", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 20, 19, 12, 32, 45, DateTimeKind.Local).AddTicks(6711), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 3, "Digital Piano", 566.440561047907360m, 91 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "55444 Joanie Brooks", "Lonietown", new DateTime(2024, 12, 20, 19, 12, 32, 47, DateTimeKind.Local).AddTicks(1181), "Dedrick11_Osinski62@gmail.com", "+573 337 181 092", "06867", "Alaska", "Dedrick11" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "586 Hayley Canyon", "Port Jefferyhaven", new DateTime(2024, 12, 20, 19, 12, 32, 47, DateTimeKind.Local).AddTicks(4127), "Scottie.Botsford.Flatley@hotmail.com", "+351 446 428 244", "10860-7758", "Ohio", "Scottie.Botsford" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "64850 Gunner Corners", "South Francesview", new DateTime(2024, 12, 20, 19, 12, 32, 47, DateTimeKind.Local).AddTicks(4449), "Freida_Block_Kling@hotmail.com", "+682 498 654 825", "65335", "Maine", "Freida_Block" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "83154 Roberts Circles", "Brockside", new DateTime(2024, 12, 20, 19, 12, 32, 47, DateTimeKind.Local).AddTicks(4685), "Quinton25_Denesik70@hotmail.com", "+523 090 604 967", "86363", "Arkansas", "Quinton25" });
        }
    }
}
