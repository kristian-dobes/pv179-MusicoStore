using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.SQLite.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class crosssourcerequestlogging : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Source",
                table: "Logs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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
                column: "Created",
                value: new DateTime(2024, 12, 23, 22, 41, 5, 376, DateTimeKind.Local).AddTicks(3062));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2024, 12, 23, 22, 41, 5, 376, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2024, 12, 23, 22, 41, 5, 376, DateTimeKind.Local).AddTicks(3068));

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
                columns: new[] { "CategoryId", "Created", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 2, new DateTime(2024, 12, 23, 22, 41, 5, 374, DateTimeKind.Local).AddTicks(3893), 1, "Stage Lighting Kits", 696.452188913228980m, 20 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 1, new DateTime(2024, 12, 23, 22, 41, 5, 374, DateTimeKind.Local).AddTicks(3949), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 9, 5, "Tuners", 827.323363910434150m, 67 });

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
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 23, 22, 41, 5, 374, DateTimeKind.Local).AddTicks(3994), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 4, 1, "Violin", 849.776702110556320m, 76 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 23, 22, 41, 5, 374, DateTimeKind.Local).AddTicks(4016), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 2, 1, "Amplifiers", 433.57686887410840m, 11 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 23, 22, 41, 5, 374, DateTimeKind.Local).AddTicks(4037), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 1, 3, "Tuners", 783.379086455068390m, 29 });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "CategoryId", "Created", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 1, new DateTime(2024, 12, 20, 19, 12, 32, 45, DateTimeKind.Local).AddTicks(6568), 4, "Studio Monitors", 888.376722137502940m, 11 });

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
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 20, 19, 12, 32, 45, DateTimeKind.Local).AddTicks(6674), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 9, 4, "PA Systems", 260.263970053370020m, 46 });

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
                columns: new[] { "Created", "Description", "EditCount", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 20, 19, 12, 32, 45, DateTimeKind.Local).AddTicks(6711), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 3, 2, "Digital Piano", 566.440561047907360m, 91 });

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
