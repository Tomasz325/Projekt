using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Liability = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<double>(type: "REAL", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Shours = table.Column<string>(type: "TEXT", nullable: false),
                    Fhours = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Carsize = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Lastname = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Postalcode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Liability", "Type" },
                values: new object[] { 1, "Janina Chrostowa", "Warzywno-Owocowy" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Liability", "Type" },
                values: new object[] { 2, "Jan Nowak", "Napoje i przekąski" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Liability", "Type" },
                values: new object[] { 3, "Kuba Krzyszczak", "Nabiał" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Liability", "Type" },
                values: new object[] { 4, "Krystyna Kowalska", "Mięso i wędliny" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Quantity", "Type" },
                values: new object[] { 1, "Pepsi 2L", 6.5, 12.0, "Napój gazowany" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Quantity", "Type" },
                values: new object[] { 2, "Tymbark Jabłkowy 1L", 5.4000000000000004, 8.0, "Sok" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Quantity", "Type" },
                values: new object[] { 3, "Cisowianka 1,5 L", 1.8, 20.0, "Woda" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Quantity", "Type" },
                values: new object[] { 4, "Lay's Paprykowe", 7.2000000000000002, 6.0, "Przekąski" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Quantity", "Type" },
                values: new object[] { 5, "Doritos Klasyczne", 7.0, 10.0, "Przekąski" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Quantity", "Type" },
                values: new object[] { 6, "Orzeszki Ziemne", 11.199999999999999, 7.0, "Przekąski" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Quantity", "Type" },
                values: new object[] { 7, "Coca-Cola 1,5 L", 8.5, 16.0, "Napój gazowany" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Quantity", "Type" },
                values: new object[] { 8, "Marchewka Polska 1KG", 15.0, 16.0, "Warzywa" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Quantity", "Type" },
                values: new object[] { 9, "Papryka Czerwona 1KG", 26.0, 20.0, "Warzywa" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Quantity", "Type" },
                values: new object[] { 10, "Jabłko 1KG", 5.5, 25.0, "Owoce" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Quantity", "Type" },
                values: new object[] { 11, "Gruszka 1KG", 12.800000000000001, 10.0, "Owoce" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Quantity", "Type" },
                values: new object[] { 12, "Mleko Łaciate 1L", 4.9900000000000002, 12.0, "Nabiał" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Quantity", "Type" },
                values: new object[] { 13, "Ser Półtłusty 250G", 3.9900000000000002, 12.0, "Nabiał" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Quantity", "Type" },
                values: new object[] { 14, "Bakoma Natrualny 400G", 5.0, 7.0, "Yoghurt" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Quantity", "Type" },
                values: new object[] { 15, "Schab Bez Kości 1KG", 19.5, 20.0, "Mięso" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Quantity", "Type" },
                values: new object[] { 16, "Szynka Drwala 1KG", 37.5, 15.0, "Mięso" });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "Fhours", "Shours", "Type" },
                values: new object[] { 1, "14:00", "6:00", "Dzienna" });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "Fhours", "Shours", "Type" },
                values: new object[] { 2, "22:00", "14:00", "Nocna" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Carsize", "Name", "Type" },
                values: new object[] { 1, "Duże", "Sokołów", "Dostawcze" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Carsize", "Name", "Type" },
                values: new object[] { 2, "Średnie", "Mlekovita", "Dostawcze" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Carsize", "Name", "Type" },
                values: new object[] { 3, "Małe", "Sadowcy", "Osobowe" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Carsize", "Name", "Type" },
                values: new object[] { 4, "Duże", "Eurocash", "Tir" });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "Address", "Age", "Lastname", "Name", "Postalcode" },
                values: new object[] { 1, "ul.Krakowska", 30, "Nowak", "Jan", "31-004 Kraków" });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "Address", "Age", "Lastname", "Name", "Postalcode" },
                values: new object[] { 2, "ul.Parkowa", 25, "Krzyszczak", "Kuba", "31-004 Kraków" });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "Address", "Age", "Lastname", "Name", "Postalcode" },
                values: new object[] { 3, "ul.Bocheńska", 50, "Chrostowa", "Janina", "32-000 Niepołomice" });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "Address", "Age", "Lastname", "Name", "Postalcode" },
                values: new object[] { 4, "ul.Kazimierza Wielkiego", 42, "Kowalska", "Krystyna", "32-700 Bochnia" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Workers");
        }
    }
}
