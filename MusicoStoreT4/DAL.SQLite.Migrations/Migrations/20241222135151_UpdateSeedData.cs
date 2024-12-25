using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.SQLite.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Created", "OrderId" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4535), 3 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "OrderId" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4538), 4 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "OrderId" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 51, 50, 973, DateTimeKind.Local).AddTicks(4540), 5 });

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
                columns: new[] { "Created", "Description", "EditCount", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 51, 50, 969, DateTimeKind.Local).AddTicks(8976), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 2, 51.4046968833444760m, 90 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 12, 22, 14, 51, 50, 969, DateTimeKind.Local).AddTicks(9049), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 5, "Guitar Picks", 93.0524202743082760m, 97 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Description", "EditCount", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 51, 50, 969, DateTimeKind.Local).AddTicks(9071), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 1, "Drum Kit", 120.915022801811140m, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 12, 22, 14, 51, 50, 969, DateTimeKind.Local).AddTicks(9090), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 6, 1, "Amplifiers", 49.1561730168610870m, 86 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "EditCount", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 51, 50, 969, DateTimeKind.Local).AddTicks(9109), 6, "Amplifiers", 587.502477246248290m, 35 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 51, 50, 969, DateTimeKind.Local).AddTicks(9137), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 3, 3, "Violin", 501.311496680687980m, 2 });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 22, 12, 55, 5, 471, DateTimeKind.Local).AddTicks(3855));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 22, 12, 55, 5, 471, DateTimeKind.Local).AddTicks(3899));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 22, 12, 55, 5, 471, DateTimeKind.Local).AddTicks(3901));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 22, 12, 55, 5, 481, DateTimeKind.Local).AddTicks(1245), "Denesik and Sons" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 22, 12, 55, 5, 481, DateTimeKind.Local).AddTicks(6678), "Kertzmann LLC" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 22, 12, 55, 5, 481, DateTimeKind.Local).AddTicks(7597), "Grant, Wuckert and Jakubowski" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 22, 12, 55, 5, 481, DateTimeKind.Local).AddTicks(7783), "Von, Hilpert and MacGyver" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 22, 12, 55, 5, 481, DateTimeKind.Local).AddTicks(7903), "Wintheiser, Gorczany and Grant" });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 22, 12, 55, 5, 485, DateTimeKind.Local).AddTicks(4340));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 22, 12, 55, 5, 485, DateTimeKind.Local).AddTicks(4346));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 22, 12, 55, 5, 485, DateTimeKind.Local).AddTicks(4348));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 12, 22, 12, 55, 5, 485, DateTimeKind.Local).AddTicks(4352));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "OrderId" },
                values: new object[] { new DateTime(2024, 12, 22, 12, 55, 5, 485, DateTimeKind.Local).AddTicks(4354), 4 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "OrderId" },
                values: new object[] { new DateTime(2024, 12, 22, 12, 55, 5, 485, DateTimeKind.Local).AddTicks(4357), 5 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "OrderId" },
                values: new object[] { new DateTime(2024, 12, 22, 12, 55, 5, 485, DateTimeKind.Local).AddTicks(4360), 4 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 22, 12, 55, 5, 485, DateTimeKind.Local).AddTicks(4317));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 22, 12, 55, 5, 485, DateTimeKind.Local).AddTicks(4323));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 22, 12, 55, 5, 485, DateTimeKind.Local).AddTicks(4327));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 12, 22, 12, 55, 5, 485, DateTimeKind.Local).AddTicks(4330));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 12, 22, 12, 55, 5, 485, DateTimeKind.Local).AddTicks(4334));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 22, 11, 55, 5, 485, DateTimeKind.Utc).AddTicks(4422));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 22, 11, 55, 5, 485, DateTimeKind.Utc).AddTicks(4432));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 12, 22, 12, 55, 5, 483, DateTimeKind.Local).AddTicks(3638), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 6, 5, "Replacement Strings", 648.791675394628690m, 99 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Description", "EditCount", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 22, 12, 55, 5, 483, DateTimeKind.Local).AddTicks(5584), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 4, 152.395904823962680m, 95 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 1, new DateTime(2024, 12, 22, 12, 55, 5, 483, DateTimeKind.Local).AddTicks(5639), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 3, "Acoustic Guitar", 123.552377699405590m, 20 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Description", "EditCount", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 22, 12, 55, 5, 483, DateTimeKind.Local).AddTicks(5663), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 2, "Digital Piano", 380.42522448412690m, 42 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 1, new DateTime(2024, 12, 22, 12, 55, 5, 483, DateTimeKind.Local).AddTicks(5685), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 7, 4, "Acoustic Guitar", 359.180652350369620m, 31 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "EditCount", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 22, 12, 55, 5, 483, DateTimeKind.Local).AddTicks(5707), 1, "Guitar Picks", 104.2001504519020660m, 70 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 22, 12, 55, 5, 483, DateTimeKind.Local).AddTicks(5727), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 5, 2, "Stage Lighting Kits", 452.806314006262690m, 37 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "8595 Ludie Mount", "Port Leif", new DateTime(2024, 12, 22, 12, 55, 5, 485, DateTimeKind.Local).AddTicks(449), "Taurean8847@yahoo.com", "+353 861 086 651", "04265-7893", "New Mexico", "Taurean88" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "99002 Lia Squares", "West Savanna", new DateTime(2024, 12, 22, 12, 55, 5, 485, DateTimeKind.Local).AddTicks(3203), "Glenda.Lakin.Davis32@hotmail.com", "+871 800 690 586", "89495-5656", "North Carolina", "Glenda.Lakin" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "65875 Keebler Island", "Alexaton", new DateTime(2024, 12, 22, 12, 55, 5, 485, DateTimeKind.Local).AddTicks(3524), "Caleb38.Von19@gmail.com", "+198 944 796 106", "21386", "West Virginia", "Caleb38" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "88573 Ruth Alley", "Stoneville", new DateTime(2024, 12, 22, 12, 55, 5, 485, DateTimeKind.Local).AddTicks(3816), "Jaunita_Osinski69_Kautzer94@hotmail.com", "+433 113 647 525", "54583", "Arkansas", "Jaunita_Osinski69" });
        }
    }
}
