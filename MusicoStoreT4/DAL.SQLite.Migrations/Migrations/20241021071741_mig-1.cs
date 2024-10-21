using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.SQLite.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<string>(type: "TEXT", nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2753));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2758));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2761));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2767));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2770));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2773));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2776));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2723));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2727));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2731));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2735));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2738));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2742));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2746));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "UserId" },
                values: new object[] { new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2649), 2 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "UserId" },
                values: new object[] { new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2658), 3 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "UserId" },
                values: new object[] { new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2663), 3 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "UserId" },
                values: new object[] { new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2667), 2 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "UserId" },
                values: new object[] { new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2673), 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2681));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2688));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2691));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2694));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2698));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2702));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2705));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2709));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2712));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2716));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "Discriminator", "Email", "Name", "Role" },
                values: new object[] { 1, new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2781), "User", "admin@bestmusic.com", "Admin", 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Created", "Discriminator", "Email", "Name", "PhoneNumber", "PostalCode", "Role", "State" },
                values: new object[,]
                {
                    { 2, "Straight 68, NC", "Night City", new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2787), "Customer", "johnny@samurai.nc", "Johnny Silverhand", "+04 0578 457 666", "1020", 1, "The Free City of Night City" },
                    { 3, "Botanická 69", "Brno", new DateTime(2024, 10, 21, 9, 17, 40, 878, DateTimeKind.Local).AddTicks(2793), "Customer", "hluchymuzikant@seznam.cz", "Martin Hluchý", "+420 556 556 000", "602 00", 1, "Czechia" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3788));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3791));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3793));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3797));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3800));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3802));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3804));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3765));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3769));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3771));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3775));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3777));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3780));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3783));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3705));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3712));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3716));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3719));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3723));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3729));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3738));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3740));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3743));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3745));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3749));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3751));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3754));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3756));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2024, 10, 18, 9, 29, 26, 364, DateTimeKind.Local).AddTicks(3760));
        }
    }
}
