using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.SQLite.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class LogsFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EditCount",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Action = table.Column<string>(type: "TEXT", nullable: false),
                    ModifiedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

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
                value: new DateTime(2024, 11, 21, 0, 26, 26, 633, DateTimeKind.Local).AddTicks(9502));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 21, 0, 26, 26, 633, DateTimeKind.Local).AddTicks(9550));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 21, 0, 26, 26, 633, DateTimeKind.Local).AddTicks(9554));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 21, 0, 26, 26, 636, DateTimeKind.Local).AddTicks(3427), "Lakin LLC" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 21, 0, 26, 26, 636, DateTimeKind.Local).AddTicks(6762), "McClure Inc" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 21, 0, 26, 26, 636, DateTimeKind.Local).AddTicks(7006), "Heller - Kuvalis" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 21, 0, 26, 26, 636, DateTimeKind.Local).AddTicks(7115), "Marks - Weimann" });

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2024, 11, 21, 0, 26, 26, 636, DateTimeKind.Local).AddTicks(7250), "Dietrich - Toy" });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 21, 0, 26, 26, 644, DateTimeKind.Local).AddTicks(452));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 21, 0, 26, 26, 644, DateTimeKind.Local).AddTicks(460));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 21, 0, 26, 26, 644, DateTimeKind.Local).AddTicks(464));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 11, 21, 0, 26, 26, 644, DateTimeKind.Local).AddTicks(470));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 11, 21, 0, 26, 26, 644, DateTimeKind.Local).AddTicks(474));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2024, 11, 21, 0, 26, 26, 644, DateTimeKind.Local).AddTicks(479));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2024, 11, 21, 0, 26, 26, 644, DateTimeKind.Local).AddTicks(483));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 21, 0, 26, 26, 644, DateTimeKind.Local).AddTicks(413));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 21, 0, 26, 26, 644, DateTimeKind.Local).AddTicks(424));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 21, 0, 26, 26, 644, DateTimeKind.Local).AddTicks(431));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 11, 21, 0, 26, 26, 644, DateTimeKind.Local).AddTicks(438));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 11, 21, 0, 26, 26, 644, DateTimeKind.Local).AddTicks(445));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 20, 23, 26, 26, 644, DateTimeKind.Utc).AddTicks(547));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 20, 23, 26, 26, 644, DateTimeKind.Utc).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "LastModifiedBy", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 2, new DateTime(2024, 11, 21, 0, 26, 26, 639, DateTimeKind.Local).AddTicks(494), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 1, "Daphne26", 4, "Violin", 298.68680736865090m, 79 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Description", "EditCount", "LastModifiedBy", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 11, 21, 0, 26, 26, 639, DateTimeKind.Local).AddTicks(2713), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 7, "Matteo47", 4, "Violin", 291.922491040609870m, 83 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "LastModifiedBy", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 1, new DateTime(2024, 11, 21, 0, 26, 26, 639, DateTimeKind.Local).AddTicks(2816), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 3, "Emanuel_Champlin99", 5, "Instrument Cases", 822.71815116112720m, 64 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "LastModifiedBy", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 2, new DateTime(2024, 11, 21, 0, 26, 26, 639, DateTimeKind.Local).AddTicks(2891), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 6, "Jarrell_Hirthe35", 4, "Digital Piano", 637.114120830458470m, 29 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "LastModifiedBy", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 11, 21, 0, 26, 26, 639, DateTimeKind.Local).AddTicks(2958), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 4, "Birdie_Ullrich", 5, "Instrument Cases", 157.844873763985420m, 87 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Created", "EditCount", "LastModifiedBy", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 1, new DateTime(2024, 11, 21, 0, 26, 26, 639, DateTimeKind.Local).AddTicks(3017), 9, "Nathen.Kessler", 1, "Acoustic Guitar", 479.775910378363930m, 25 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Description", "EditCount", "LastModifiedBy", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 11, 21, 0, 26, 26, 639, DateTimeKind.Local).AddTicks(3102), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 7, "Gregg2", 5, "PA Systems", 602.927327148677290m, 68 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "69411 Eldred Alley", "South Dorris", new DateTime(2024, 11, 21, 0, 26, 26, 641, DateTimeKind.Local).AddTicks(6042), "Zion3596@gmail.com", "+161 897 636 108", "08479", "Vermont", "Zion35" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "9446 Newton Roads", "Port Emelietown", new DateTime(2024, 11, 21, 0, 26, 26, 641, DateTimeKind.Local).AddTicks(8664), "Everardo.Beatty.Bergnaum@hotmail.com", "+668 376 644 976", "34978-1153", "Nevada", "Everardo.Beatty" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "46651 Perry Forges", "East Kayden", new DateTime(2024, 11, 21, 0, 26, 26, 641, DateTimeKind.Local).AddTicks(9021), "Maxie.Jerde.OConner@gmail.com", "+616 200 982 158", "65966-5165", "Ohio", "Maxie.Jerde" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "City", "Created", "Email", "PhoneNumber", "PostalCode", "State", "Username" },
                values: new object[] { "4600 Trey Turnpike", "Port Tiffany", new DateTime(2024, 11, 21, 0, 26, 26, 642, DateTimeKind.Local).AddTicks(6015), "Harold.McDermott7929@yahoo.com", "+839 251 646 412", "76990", "North Dakota", "Harold.McDermott79" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropColumn(
                name: "EditCount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Products");

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
                columns: new[] { "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 11, 19, 20, 41, 15, 0, DateTimeKind.Local).AddTicks(91), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 3, "Acoustic Guitar", 137.863110441171160m, 68 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Created", "Description", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 11, 19, 20, 41, 15, 0, DateTimeKind.Local).AddTicks(250), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 3, "Acoustic Guitar", 679.87203782267890m, 72 });

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
                columns: new[] { "CategoryId", "Created", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 11, 19, 20, 41, 15, 0, DateTimeKind.Local).AddTicks(400), 5, "Drum Kit", 784.195063040735380m, 82 });

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
