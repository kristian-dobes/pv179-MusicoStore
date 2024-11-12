using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.SQLite.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    QuantityInStock = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    ManufacturerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrderItemId = table.Column<int>(type: "INTEGER", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Created", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3788), "Musical Instruments" },
                    { 2, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3791), "Audio Equipment" },
                    { 3, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3793), "Accessories" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Created", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3797), "Shure" },
                    { 2, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3800), "Yamaha" },
                    { 3, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3802), "Fender" },
                    { 4, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3804), "Sennheiser" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Created", "Date", "OrderItemId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3705), new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3712), new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3716), new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3719), new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3723), new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3729), "Professional condenser microphone for studio recording", 4, "Microphone", 99.99m, 10 },
                    { 2, 1, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3738), "Music concert DVD of popular artist", 2, "DVD", 19.99m, 50 },
                    { 3, 3, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3740), "Acoustic guitar with solid spruce top", 1, "Guitar", 299.99m, 5 },
                    { 4, 2, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3743), "Digital keyboard with weighted keys", 3, "Keyboard", 499.99m, 3 },
                    { 5, 3, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3745), "5-piece drum set with cymbals and hardware", 1, "Drum Set", 699.99m, 2 },
                    { 6, 1, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3749), "Adjustable microphone stand with boom arm", 1, "Microphone Stand", 29.99m, 20 },
                    { 7, 3, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3751), "Electric bass guitar with active pickups", 4, "Bass Guitar", 399.99m, 8 },
                    { 8, 2, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3754), "Digital piano with weighted keys and built-in speakers", 3, "Piano", 899.99m, 4 },
                    { 9, 3, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3756), "Full-size violin with bow and case", 4, "Violin", 199.99m, 6 },
                    { 10, 1, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3760), "Active studio monitor speaker", 4, "Studio Monitor", 149.99m, 12 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Created", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3765), 1, 99.99m, 1, 1 },
                    { 2, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3769), 1, 21.99m, 2, 2 },
                    { 3, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3771), 2, 280m, 3, 100 },
                    { 4, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3775), 3, 499.99m, 4, 5 },
                    { 5, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3777), 4, 720.05m, 5, 1 },
                    { 6, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3780), 5, 29.99m, 6, 3 },
                    { 7, new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3783), 4, 25.54m, 6, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderItemId",
                table: "Orders",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturerId",
                table: "Products",
                column: "ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
