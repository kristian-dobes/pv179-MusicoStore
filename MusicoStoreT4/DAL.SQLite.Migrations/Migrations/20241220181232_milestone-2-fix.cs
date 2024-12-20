using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.SQLite.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class milestone2fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "AuditLogs",
                newName: "ModifiedById");

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedById",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "CategoryId", "Created", "EditCount", "LastModifiedById", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 12, 20, 19, 12, 32, 45, DateTimeKind.Local).AddTicks(4548), 8, 1, 2, "Studio Monitors", 285.440906448078580m, 64 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Description", "EditCount", "LastModifiedById", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 20, 19, 12, 32, 45, DateTimeKind.Local).AddTicks(6568), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 6, 1, 4, "Studio Monitors", 888.376722137502940m, 11 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Description", "EditCount", "LastModifiedById", "ManufacturerId", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 20, 19, 12, 32, 45, DateTimeKind.Local).AddTicks(6631), "The Football Is Good For Training And Recreational Purposes", 5, 1, 1, 832.920864068872360m, 60 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Description", "EditCount", "LastModifiedById", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 20, 19, 12, 32, 45, DateTimeKind.Local).AddTicks(6655), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 5, 1, 1, "Microphone Stands", 142.659807442379470m, 82 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Description", "EditCount", "LastModifiedById", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 20, 19, 12, 32, 45, DateTimeKind.Local).AddTicks(6674), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 9, 1, 4, "PA Systems", 260.263970053370020m, 46 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "LastModifiedById", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 2, new DateTime(2024, 12, 20, 19, 12, 32, 45, DateTimeKind.Local).AddTicks(6693), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 5, 1, 2, "Tuners", 794.708059541154760m, 9 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Description", "EditCount", "LastModifiedById", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 20, 19, 12, 32, 45, DateTimeKind.Local).AddTicks(6711), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 3, 1, 2, "Digital Piano", 566.440561047907360m, 91 });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ModifiedById",
                table: "AuditLogs",
                newName: "ModifiedBy");

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 19, 10, 3, 2, 91, DateTimeKind.Local).AddTicks(9175));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 19, 10, 3, 2, 91, DateTimeKind.Local).AddTicks(9219));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 19, 10, 3, 2, 91, DateTimeKind.Local).AddTicks(9222));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 19, 10, 3, 2, 94, DateTimeKind.Local).AddTicks(2554), "Boyle, Jakubowski and Marks" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 19, 10, 3, 2, 94, DateTimeKind.Local).AddTicks(5232), "Altenwerth Group" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 19, 10, 3, 2, 94, DateTimeKind.Local).AddTicks(6577), "Price, Harber and Zulauf" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 19, 10, 3, 2, 94, DateTimeKind.Local).AddTicks(6885), "Haley, Cronin and Deckow" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 12, 19, 10, 3, 2, 94, DateTimeKind.Local).AddTicks(7013), "Mohr Inc" });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 19, 10, 3, 2, 107, DateTimeKind.Local).AddTicks(2008));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 19, 10, 3, 2, 107, DateTimeKind.Local).AddTicks(2012));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 19, 10, 3, 2, 107, DateTimeKind.Local).AddTicks(2015));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 12, 19, 10, 3, 2, 107, DateTimeKind.Local).AddTicks(2020));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 12, 19, 10, 3, 2, 107, DateTimeKind.Local).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2024, 12, 19, 10, 3, 2, 107, DateTimeKind.Local).AddTicks(2025));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2024, 12, 19, 10, 3, 2, 107, DateTimeKind.Local).AddTicks(2028));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 19, 10, 3, 2, 107, DateTimeKind.Local).AddTicks(1979));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 19, 10, 3, 2, 107, DateTimeKind.Local).AddTicks(1989));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 12, 19, 10, 3, 2, 107, DateTimeKind.Local).AddTicks(1993));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 12, 19, 10, 3, 2, 107, DateTimeKind.Local).AddTicks(1997));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 12, 19, 10, 3, 2, 107, DateTimeKind.Local).AddTicks(2001));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 19, 9, 3, 2, 107, DateTimeKind.Utc).AddTicks(2117));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 12, 19, 9, 3, 2, 107, DateTimeKind.Utc).AddTicks(2120));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Created", "EditCount", "LastModifiedBy", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 2, new DateTime(2024, 12, 19, 10, 3, 2, 103, DateTimeKind.Local).AddTicks(2140), 10, "Brisa69", 3, "Acoustic Guitar", 579.945262138154650m, 20 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Description", "EditCount", "LastModifiedBy", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 19, 10, 3, 2, 103, DateTimeKind.Local).AddTicks(4374), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 7, "Earl.Jast", 5, "Saxophone", 354.353250661768810m, 72 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Description", "EditCount", "LastModifiedBy", "ManufacturerId", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 19, 10, 3, 2, 103, DateTimeKind.Local).AddTicks(4477), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 10, "Rene_Bailey", 5, 23.5002587558028850m, 23 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Description", "EditCount", "LastModifiedBy", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 19, 10, 3, 2, 103, DateTimeKind.Local).AddTicks(4531), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 1, "Giles_Rice", 3, "Saxophone", 367.616889434167660m, 62 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Description", "EditCount", "LastModifiedBy", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 19, 10, 3, 2, 103, DateTimeKind.Local).AddTicks(4591), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 2, "Kayleigh.Koepp", 5, "Tuners", 202.777747449093730m, 15 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "LastModifiedBy", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 1, new DateTime(2024, 12, 19, 10, 3, 2, 103, DateTimeKind.Local).AddTicks(4649), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 8, "Virgil.Thompson94", 1, "PA Systems", 37.9141941191793130m, 82 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Description", "EditCount", "LastModifiedBy", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 19, 10, 3, 2, 103, DateTimeKind.Local).AddTicks(4720), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 7, "Casimir_Kling", 3, "Studio Monitors", 500.171984279610490m, 27 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "268 Hoppe Ridges", "East Anastaciofurt", new DateTime(2024, 12, 19, 10, 3, 2, 105, DateTimeKind.Local).AddTicks(505), "Dexter.Johns.Thiel25@gmail.com", "+995 861 942 885", "99819", "South Carolina", "Dexter.Johns" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "9271 Rau Burgs", "Port Javiermouth", new DateTime(2024, 12, 19, 10, 3, 2, 105, DateTimeKind.Local).AddTicks(3004), "Abigayle_Collier9.Wilkinson@yahoo.com", "+826 433 273 775", "75457", "New Hampshire", "Abigayle_Collier9" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "68189 Electa Circle", "Feilport", new DateTime(2024, 12, 19, 10, 3, 2, 105, DateTimeKind.Local).AddTicks(3321), "Jon_Kulas79@hotmail.com", "+231 534 101 423", "08080-1607", "New Mexico", "Jon_Kulas" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "014 Rosendo Green", "West Casimirfurt", new DateTime(2024, 12, 19, 10, 3, 2, 105, DateTimeKind.Local).AddTicks(3541), "Jane_Reinger31@yahoo.com", "+757 832 451 417", "83533-0079", "Iowa", "Jane_Reinger" });
        }
    }
}
