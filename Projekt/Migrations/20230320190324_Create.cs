using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "workers",
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
                    table.PrimaryKey("PK_workers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "workers",
                columns: new[] { "Id", "Address", "Age", "Lastname", "Name", "Postalcode" },
                values: new object[] { 1, "ul.Krakowska", 30, "Nowak", "Jan", "31-004 Kraków" });

            migrationBuilder.InsertData(
                table: "workers",
                columns: new[] { "Id", "Address", "Age", "Lastname", "Name", "Postalcode" },
                values: new object[] { 2, "ul.Parkowa", 25, "Krzyszczak", "Kuba", "31-004 Kraków" });

            migrationBuilder.InsertData(
                table: "workers",
                columns: new[] { "Id", "Address", "Age", "Lastname", "Name", "Postalcode" },
                values: new object[] { 3, "ul.Bocheńska", 50, "Chrostowa", "Janina", "32-000 Niepołomice" });

            migrationBuilder.InsertData(
                table: "workers",
                columns: new[] { "Id", "Address", "Age", "Lastname", "Name", "Postalcode" },
                values: new object[] { 4, "ul.Kazimierza Wielkiego", 42, "Kowalska", "Krystyna", "32-700 Bochnia" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workers");
        }
    }
}
