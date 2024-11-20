using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.SQLite.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Logs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Method = table.Column<string>(type: "TEXT", nullable: false),
                    Path = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 20, 21, 35, 32, 942, DateTimeKind.Local).AddTicks(5087));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 20, 21, 35, 32, 942, DateTimeKind.Local).AddTicks(5133));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 20, 21, 35, 32, 942, DateTimeKind.Local).AddTicks(5135));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 20, 21, 35, 32, 944, DateTimeKind.Local).AddTicks(679), "Predovic, Rau and Kuhn" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 20, 21, 35, 32, 944, DateTimeKind.Local).AddTicks(3499), "Moore, Douglas and O'Hara" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 20, 21, 35, 32, 944, DateTimeKind.Local).AddTicks(3926), "Bashirian - Goyette" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 20, 21, 35, 32, 944, DateTimeKind.Local).AddTicks(4013), "Rice - Trantow" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 20, 21, 35, 32, 944, DateTimeKind.Local).AddTicks(4085), "Jenkins Group" });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 20, 21, 35, 32, 949, DateTimeKind.Local).AddTicks(9109));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 20, 21, 35, 32, 949, DateTimeKind.Local).AddTicks(9113));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 20, 21, 35, 32, 949, DateTimeKind.Local).AddTicks(9116));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 11, 20, 21, 35, 32, 949, DateTimeKind.Local).AddTicks(9119));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 11, 20, 21, 35, 32, 949, DateTimeKind.Local).AddTicks(9121));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2024, 11, 20, 21, 35, 32, 949, DateTimeKind.Local).AddTicks(9124));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2024, 11, 20, 21, 35, 32, 949, DateTimeKind.Local).AddTicks(9127));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 20, 21, 35, 32, 949, DateTimeKind.Local).AddTicks(9086));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 20, 21, 35, 32, 949, DateTimeKind.Local).AddTicks(9093));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 20, 21, 35, 32, 949, DateTimeKind.Local).AddTicks(9096));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 11, 20, 21, 35, 32, 949, DateTimeKind.Local).AddTicks(9099));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 11, 20, 21, 35, 32, 949, DateTimeKind.Local).AddTicks(9103));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 20, 20, 35, 32, 949, DateTimeKind.Utc).AddTicks(9207));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 20, 20, 35, 32, 949, DateTimeKind.Utc).AddTicks(9210));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 2, new DateTime(2024, 11, 20, 21, 35, 32, 945, DateTimeKind.Local).AddTicks(9720), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 5, "Replacement Strings", 397.123759907865640m, 7 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Description", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 11, 20, 21, 35, 32, 946, DateTimeKind.Local).AddTicks(2009), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "PA Systems", 379.160196139204030m, 62 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Description", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 11, 20, 21, 35, 32, 946, DateTimeKind.Local).AddTicks(2065), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Karaoke Machines", 441.029498078598760m, 39 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Created", "Description", "Name", "Price", "QuantityInStock" },
                values: new object[] { 1, new DateTime(2024, 11, 20, 21, 35, 32, 946, DateTimeKind.Local).AddTicks(2085), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Replacement Strings", 70.4147970187073620m, 70 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Description", "ManufacturerId", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 11, 20, 21, 35, 32, 946, DateTimeKind.Local).AddTicks(2103), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 2, 370.574848034634970m, 11 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 2, new DateTime(2024, 11, 20, 21, 35, 32, 946, DateTimeKind.Local).AddTicks(2121), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 4, "Microphone Stands", 987.019699892134690m, 73 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 11, 20, 21, 35, 32, 946, DateTimeKind.Local).AddTicks(2139), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 3, "Acoustic Guitar", 622.773831855085120m, 9 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "90778 Ena Plains", "Port Raheemmouth", new DateTime(2024, 11, 20, 21, 35, 32, 947, DateTimeKind.Local).AddTicks(7864), "Adeline.Bailey60.Bashirian@hotmail.com", "+773 930 795 228", "70997", "New Hampshire", "Adeline.Bailey60" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "537 Becker Locks", "East Treverstad", new DateTime(2024, 11, 20, 21, 35, 32, 948, DateTimeKind.Local).AddTicks(761), "Anya_Rutherford63.Watsica65@gmail.com", "+468 873 847 762", "30614", "Texas", "Anya_Rutherford63" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "08953 Legros Fork", "Breitenbergfurt", new DateTime(2024, 11, 20, 21, 35, 32, 948, DateTimeKind.Local).AddTicks(1065), "Eulah.Lowe2232@yahoo.com", "+629 995 179 007", "69817-2818", "Tennessee", "Eulah.Lowe22" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "082 Zieme Fort", "East Zackmouth", new DateTime(2024, 11, 20, 21, 35, 32, 948, DateTimeKind.Local).AddTicks(1300), "Jennings0_Ankunding62@gmail.com", "+047 809 290 834", "49742", "Massachusetts", "Jennings0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 19, 20, 41, 14, 988, DateTimeKind.Local).AddTicks(6623));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 19, 20, 41, 14, 988, DateTimeKind.Local).AddTicks(6700));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 19, 20, 41, 14, 988, DateTimeKind.Local).AddTicks(6709));

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

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 19, 20, 41, 14, 994, DateTimeKind.Local).AddTicks(1042), "Bradtke Group" });

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
                columns: new[] { "CategoryId", "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 11, 19, 20, 41, 14, 999, DateTimeKind.Local).AddTicks(6470), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 1, "Stage Lighting Kits", 467.831560954574620m, 38 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Description", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 11, 19, 20, 41, 15, 0, DateTimeKind.Local).AddTicks(91), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Acoustic Guitar", 137.863110441171160m, 68 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Description", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 11, 19, 20, 41, 15, 0, DateTimeKind.Local).AddTicks(250), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Acoustic Guitar", 679.87203782267890m, 72 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Created", "Description", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 11, 19, 20, 41, 15, 0, DateTimeKind.Local).AddTicks(302), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Tuners", 568.868747298612850m, 48 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Description", "ManufacturerId", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 11, 19, 20, 41, 15, 0, DateTimeKind.Local).AddTicks(353), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 3, 617.884472885447890m, 79 });

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
                columns: new[] { "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 11, 19, 20, 41, 15, 0, DateTimeKind.Local).AddTicks(447), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 2, "Stage Lighting Kits", 344.065370759100640m, 92 });

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "6006 Rolando Ports", "Ozellamouth", new DateTime(2024, 11, 19, 20, 41, 15, 5, DateTimeKind.Local).AddTicks(4434), "Immanuel58_Bahringer48@hotmail.com", "+625 984 133 521", "76036", "Virginia", "Immanuel58" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "21502 Mayer Spring", "Lake Eveline", new DateTime(2024, 11, 19, 20, 41, 15, 5, DateTimeKind.Local).AddTicks(5014), "Carson26.Kunde2@hotmail.com", "+538 273 136 433", "32833-8405", "Wisconsin", "Carson26" });
        }
    }
}
