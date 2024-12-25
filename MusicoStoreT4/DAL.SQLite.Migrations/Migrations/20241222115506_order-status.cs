using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.SQLite.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class orderstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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
                column: "Created",
                value: new DateTime(2024, 12, 22, 12, 55, 5, 485, DateTimeKind.Local).AddTicks(4354));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2024, 12, 22, 12, 55, 5, 485, DateTimeKind.Local).AddTicks(4357));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2024, 12, 22, 12, 55, 5, 485, DateTimeKind.Local).AddTicks(4360));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "OrderStatus" },
                values: new object[] { new DateTime(2024, 12, 22, 12, 55, 5, 485, DateTimeKind.Local).AddTicks(4317), 0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "OrderStatus" },
                values: new object[] { new DateTime(2024, 12, 22, 12, 55, 5, 485, DateTimeKind.Local).AddTicks(4323), 0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "OrderStatus" },
                values: new object[] { new DateTime(2024, 12, 22, 12, 55, 5, 485, DateTimeKind.Local).AddTicks(4327), 0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "OrderStatus" },
                values: new object[] { new DateTime(2024, 12, 22, 12, 55, 5, 485, DateTimeKind.Local).AddTicks(4330), 0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "OrderStatus" },
                values: new object[] { new DateTime(2024, 12, 22, 12, 55, 5, 485, DateTimeKind.Local).AddTicks(4334), 0 });

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
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 22, 12, 55, 5, 483, DateTimeKind.Local).AddTicks(3638), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 6, 5, "Replacement Strings", 648.791675394628690m, 99 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 12, 22, 12, 55, 5, 483, DateTimeKind.Local).AddTicks(5584), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 4, 2, "Digital Piano", 152.395904823962680m, 95 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 1, new DateTime(2024, 12, 22, 12, 55, 5, 483, DateTimeKind.Local).AddTicks(5639), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 2, 3, "Acoustic Guitar", 123.552377699405590m, 20 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 22, 12, 55, 5, 483, DateTimeKind.Local).AddTicks(5663), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 2, 5, "Digital Piano", 380.42522448412690m, 42 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "Name", "Price", "QuantityInStock" },
                values: new object[] { 1, new DateTime(2024, 12, 22, 12, 55, 5, 483, DateTimeKind.Local).AddTicks(5685), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 7, "Acoustic Guitar", 359.180652350369620m, 31 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 22, 12, 55, 5, 483, DateTimeKind.Local).AddTicks(5707), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 1, 5, "Guitar Picks", 104.2001504519020660m, 70 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Description", "EditCount", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 22, 12, 55, 5, 483, DateTimeKind.Local).AddTicks(5727), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 5, "Stage Lighting Kits", 452.806314006262690m, 37 });

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
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "Username" },
                values: new object[] { "88573 Ruth Alley", "Stoneville", new DateTime(2024, 12, 22, 12, 55, 5, 485, DateTimeKind.Local).AddTicks(3816), "Jaunita_Osinski69_Kautzer94@hotmail.com", "+433 113 647 525", "54583", "Jaunita_Osinski69" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders");

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
                column: "Created",
                value: new DateTime(2024, 12, 20, 19, 12, 32, 47, DateTimeKind.Local).AddTicks(5222));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2024, 12, 20, 19, 12, 32, 47, DateTimeKind.Local).AddTicks(5225));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2024, 12, 20, 19, 12, 32, 47, DateTimeKind.Local).AddTicks(5228));

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
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 20, 19, 12, 32, 45, DateTimeKind.Local).AddTicks(4548), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 8, 2, "Studio Monitors", 285.440906448078580m, 64 });

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
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 12, 20, 19, 12, 32, 45, DateTimeKind.Local).AddTicks(6631), "The Football Is Good For Training And Recreational Purposes", 5, 1, "Amplifiers", 832.920864068872360m, 60 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 20, 19, 12, 32, 45, DateTimeKind.Local).AddTicks(6655), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 5, 1, "Microphone Stands", 142.659807442379470m, 82 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "Name", "Price", "QuantityInStock" },
                values: new object[] { 2, new DateTime(2024, 12, 20, 19, 12, 32, 45, DateTimeKind.Local).AddTicks(6674), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 9, "PA Systems", 260.263970053370020m, 46 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 20, 19, 12, 32, 45, DateTimeKind.Local).AddTicks(6693), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 5, 2, "Tuners", 794.708059541154760m, 9 });

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
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "Username" },
                values: new object[] { "83154 Roberts Circles", "Brockside", new DateTime(2024, 12, 20, 19, 12, 32, 47, DateTimeKind.Local).AddTicks(4685), "Quinton25_Denesik70@hotmail.com", "+523 090 604 967", "86363", "Quinton25" });
        }
    }
}
