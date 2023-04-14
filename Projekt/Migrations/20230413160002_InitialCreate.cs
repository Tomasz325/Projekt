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
                    Type = table.Column<string>(type: "TEXT", nullable: false)
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
                    Carmodel = table.Column<string>(type: "TEXT", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "DepartmentsProducts",
                columns: table => new
                {
                    departmentsId = table.Column<int>(type: "INTEGER", nullable: false),
                    productsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentsProducts", x => new { x.departmentsId, x.productsId });
                    table.ForeignKey(
                        name: "FK_DepartmentsProducts_Departments_departmentsId",
                        column: x => x.departmentsId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentsProducts_Products_productsId",
                        column: x => x.productsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsSuppliers",
                columns: table => new
                {
                    productsId = table.Column<int>(type: "INTEGER", nullable: false),
                    suppliersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsSuppliers", x => new { x.productsId, x.suppliersId });
                    table.ForeignKey(
                        name: "FK_ProductsSuppliers_Products_productsId",
                        column: x => x.productsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsSuppliers_Suppliers_suppliersId",
                        column: x => x.suppliersId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentsWorker",
                columns: table => new
                {
                    WorkersId = table.Column<int>(type: "INTEGER", nullable: false),
                    departmentsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentsWorker", x => new { x.WorkersId, x.departmentsId });
                    table.ForeignKey(
                        name: "FK_DepartmentsWorker_Departments_departmentsId",
                        column: x => x.departmentsId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentsWorker_Workers_WorkersId",
                        column: x => x.WorkersId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShiftsWorker",
                columns: table => new
                {
                    shiftsId = table.Column<int>(type: "INTEGER", nullable: false),
                    workersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftsWorker", x => new { x.shiftsId, x.workersId });
                    table.ForeignKey(
                        name: "FK_ShiftsWorker_Shifts_shiftsId",
                        column: x => x.shiftsId,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftsWorker_Workers_workersId",
                        column: x => x.workersId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Type" },
                values: new object[] { 1, "Warzywno-Owocowy" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Type" },
                values: new object[] { 2, "Napoje i przekąski" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Type" },
                values: new object[] { 3, "Nabiał" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Type" },
                values: new object[] { 4, "Mięso i wędliny" });

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
                values: new object[] { 14, "Bakoma Natrualny 400G", 5.0, 7.0, "Nabiał" });

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
                columns: new[] { "Id", "Carmodel", "Name", "Type" },
                values: new object[] { 1, "Iveco Daily", "Sokołów", "Dostawcze" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Carmodel", "Name", "Type" },
                values: new object[] { 2, "Fiat Ducato", "Mlekovita", "Dostawcze" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Carmodel", "Name", "Type" },
                values: new object[] { 3, "Skoda Octavia", "Sadowcy", "Osobowe" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Carmodel", "Name", "Type" },
                values: new object[] { 4, "MAN TGS 18.460", "Eurocash", "Tir" });

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

            migrationBuilder.InsertData(
                table: "DepartmentsProducts",
                columns: new[] { "departmentsId", "productsId" },
                values: new object[] { 1, 8 });

            migrationBuilder.InsertData(
                table: "DepartmentsProducts",
                columns: new[] { "departmentsId", "productsId" },
                values: new object[] { 1, 9 });

            migrationBuilder.InsertData(
                table: "DepartmentsProducts",
                columns: new[] { "departmentsId", "productsId" },
                values: new object[] { 1, 10 });

            migrationBuilder.InsertData(
                table: "DepartmentsProducts",
                columns: new[] { "departmentsId", "productsId" },
                values: new object[] { 1, 11 });

            migrationBuilder.InsertData(
                table: "DepartmentsProducts",
                columns: new[] { "departmentsId", "productsId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "DepartmentsProducts",
                columns: new[] { "departmentsId", "productsId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "DepartmentsProducts",
                columns: new[] { "departmentsId", "productsId" },
                values: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "DepartmentsProducts",
                columns: new[] { "departmentsId", "productsId" },
                values: new object[] { 2, 4 });

            migrationBuilder.InsertData(
                table: "DepartmentsProducts",
                columns: new[] { "departmentsId", "productsId" },
                values: new object[] { 2, 5 });

            migrationBuilder.InsertData(
                table: "DepartmentsProducts",
                columns: new[] { "departmentsId", "productsId" },
                values: new object[] { 2, 6 });

            migrationBuilder.InsertData(
                table: "DepartmentsProducts",
                columns: new[] { "departmentsId", "productsId" },
                values: new object[] { 2, 7 });

            migrationBuilder.InsertData(
                table: "DepartmentsProducts",
                columns: new[] { "departmentsId", "productsId" },
                values: new object[] { 3, 12 });

            migrationBuilder.InsertData(
                table: "DepartmentsProducts",
                columns: new[] { "departmentsId", "productsId" },
                values: new object[] { 3, 13 });

            migrationBuilder.InsertData(
                table: "DepartmentsProducts",
                columns: new[] { "departmentsId", "productsId" },
                values: new object[] { 3, 14 });

            migrationBuilder.InsertData(
                table: "DepartmentsProducts",
                columns: new[] { "departmentsId", "productsId" },
                values: new object[] { 4, 15 });

            migrationBuilder.InsertData(
                table: "DepartmentsProducts",
                columns: new[] { "departmentsId", "productsId" },
                values: new object[] { 4, 16 });

            migrationBuilder.InsertData(
                table: "DepartmentsWorker",
                columns: new[] { "WorkersId", "departmentsId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "DepartmentsWorker",
                columns: new[] { "WorkersId", "departmentsId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "DepartmentsWorker",
                columns: new[] { "WorkersId", "departmentsId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "DepartmentsWorker",
                columns: new[] { "WorkersId", "departmentsId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "ProductsSuppliers",
                columns: new[] { "productsId", "suppliersId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "ProductsSuppliers",
                columns: new[] { "productsId", "suppliersId" },
                values: new object[] { 2, 4 });

            migrationBuilder.InsertData(
                table: "ProductsSuppliers",
                columns: new[] { "productsId", "suppliersId" },
                values: new object[] { 3, 4 });

            migrationBuilder.InsertData(
                table: "ProductsSuppliers",
                columns: new[] { "productsId", "suppliersId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "ProductsSuppliers",
                columns: new[] { "productsId", "suppliersId" },
                values: new object[] { 5, 4 });

            migrationBuilder.InsertData(
                table: "ProductsSuppliers",
                columns: new[] { "productsId", "suppliersId" },
                values: new object[] { 6, 4 });

            migrationBuilder.InsertData(
                table: "ProductsSuppliers",
                columns: new[] { "productsId", "suppliersId" },
                values: new object[] { 7, 4 });

            migrationBuilder.InsertData(
                table: "ProductsSuppliers",
                columns: new[] { "productsId", "suppliersId" },
                values: new object[] { 8, 3 });

            migrationBuilder.InsertData(
                table: "ProductsSuppliers",
                columns: new[] { "productsId", "suppliersId" },
                values: new object[] { 9, 3 });

            migrationBuilder.InsertData(
                table: "ProductsSuppliers",
                columns: new[] { "productsId", "suppliersId" },
                values: new object[] { 10, 3 });

            migrationBuilder.InsertData(
                table: "ProductsSuppliers",
                columns: new[] { "productsId", "suppliersId" },
                values: new object[] { 11, 3 });

            migrationBuilder.InsertData(
                table: "ProductsSuppliers",
                columns: new[] { "productsId", "suppliersId" },
                values: new object[] { 12, 2 });

            migrationBuilder.InsertData(
                table: "ProductsSuppliers",
                columns: new[] { "productsId", "suppliersId" },
                values: new object[] { 13, 2 });

            migrationBuilder.InsertData(
                table: "ProductsSuppliers",
                columns: new[] { "productsId", "suppliersId" },
                values: new object[] { 14, 2 });

            migrationBuilder.InsertData(
                table: "ProductsSuppliers",
                columns: new[] { "productsId", "suppliersId" },
                values: new object[] { 15, 1 });

            migrationBuilder.InsertData(
                table: "ProductsSuppliers",
                columns: new[] { "productsId", "suppliersId" },
                values: new object[] { 16, 1 });

            migrationBuilder.InsertData(
                table: "ShiftsWorker",
                columns: new[] { "shiftsId", "workersId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ShiftsWorker",
                columns: new[] { "shiftsId", "workersId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "ShiftsWorker",
                columns: new[] { "shiftsId", "workersId" },
                values: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "ShiftsWorker",
                columns: new[] { "shiftsId", "workersId" },
                values: new object[] { 2, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsProducts_productsId",
                table: "DepartmentsProducts",
                column: "productsId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsWorker_departmentsId",
                table: "DepartmentsWorker",
                column: "departmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsSuppliers_suppliersId",
                table: "ProductsSuppliers",
                column: "suppliersId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftsWorker_workersId",
                table: "ShiftsWorker",
                column: "workersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentsProducts");

            migrationBuilder.DropTable(
                name: "DepartmentsWorker");

            migrationBuilder.DropTable(
                name: "ProductsSuppliers");

            migrationBuilder.DropTable(
                name: "ShiftsWorker");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Workers");
        }
    }
}
