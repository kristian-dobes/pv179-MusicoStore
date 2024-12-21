using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.SQLite.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class newImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages");

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
                columns: new[] { "Created", "Description", "EditCount", "LastModifiedBy", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 19, 10, 3, 2, 103, DateTimeKind.Local).AddTicks(2140), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 10, "Brisa69", 3, "Acoustic Guitar", 579.945262138154650m, 20 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Created", "LastModifiedBy", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 1, new DateTime(2024, 12, 19, 10, 3, 2, 103, DateTimeKind.Local).AddTicks(4374), "Earl.Jast", 5, "Saxophone", 354.353250661768810m, 72 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "LastModifiedBy", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 12, 19, 10, 3, 2, 103, DateTimeKind.Local).AddTicks(4477), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 10, "Rene_Bailey", "Amplifiers", 23.5002587558028850m, 23 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "LastModifiedBy", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 12, 19, 10, 3, 2, 103, DateTimeKind.Local).AddTicks(4531), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 1, "Giles_Rice", 3, "Saxophone", 367.616889434167660m, 62 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "LastModifiedBy", "Name", "Price", "QuantityInStock" },
                values: new object[] { 2, new DateTime(2024, 12, 19, 10, 3, 2, 103, DateTimeKind.Local).AddTicks(4591), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 2, "Kayleigh.Koepp", "Tuners", 202.777747449093730m, 15 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Description", "EditCount", "LastModifiedBy", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 12, 19, 10, 3, 2, 103, DateTimeKind.Local).AddTicks(4649), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 8, "Virgil.Thompson94", "PA Systems", 37.9141941191793130m, 82 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "Created", "Description", "LastModifiedBy", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 12, 19, 10, 3, 2, 103, DateTimeKind.Local).AddTicks(4720), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Casimir_Kling", 3, "Studio Monitors", 500.171984279610490m, 27 });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages");

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
                columns: new[] { "Created", "Description", "EditCount", "LastModifiedBy", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 11, 21, 0, 26, 26, 639, DateTimeKind.Local).AddTicks(494), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 1, "Daphne26", 4, "Violin", 298.68680736865090m, 79 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Created", "LastModifiedBy", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 11, 21, 0, 26, 26, 639, DateTimeKind.Local).AddTicks(2713), "Matteo47", 4, "Violin", 291.922491040609870m, 83 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "LastModifiedBy", "Name", "Price", "QuantityInStock" },
                values: new object[] { 1, new DateTime(2024, 11, 21, 0, 26, 26, 639, DateTimeKind.Local).AddTicks(2816), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 3, "Emanuel_Champlin99", "Instrument Cases", 822.71815116112720m, 64 });

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
                columns: new[] { "CategoryId", "Created", "Description", "EditCount", "LastModifiedBy", "Name", "Price", "QuantityInStock" },
                values: new object[] { 3, new DateTime(2024, 11, 21, 0, 26, 26, 639, DateTimeKind.Local).AddTicks(2958), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 4, "Birdie_Ullrich", "Instrument Cases", 157.844873763985420m, 87 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Description", "EditCount", "LastModifiedBy", "Name", "Price", "QuantityInStock" },
                values: new object[] { new DateTime(2024, 11, 21, 0, 26, 26, 639, DateTimeKind.Local).AddTicks(3017), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 9, "Nathen.Kessler", "Acoustic Guitar", 479.775910378363930m, 25 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "Created", "Description", "LastModifiedBy", "ManufacturerId", "Name", "Price", "QuantityInStock" },
                values: new object[] { 2, new DateTime(2024, 11, 21, 0, 26, 26, 639, DateTimeKind.Local).AddTicks(3102), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Gregg2", 5, "PA Systems", 602.927327148677290m, 68 });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }
    }
}
