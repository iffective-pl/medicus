using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedicusApp.Migrations
{
    public partial class LinkOption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHeader",
                table: "Specializations");

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Href = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsIndex = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Href = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LinkId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Links_LinkId",
                        column: x => x.LinkId,
                        principalTable: "Links",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "Href", "IsIndex", "Name", "Order" },
                values: new object[] { 1, "/", true, "Strona główna", 1 });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "Href", "Name", "Order" },
                values: new object[,]
                {
                    { 2, "about", "O nas", 2 },
                    { 3, "register", "Rejestracja", 3 },
                    { 4, "docs", "Nasi specjaliści", 4 },
                    { 5, "usg", "USG", 5 },
                    { 6, "echo", "ECHO Serca", 6 },
                    { 7, "holter", "Holter", 7 },
                    { 8, "contact", "Kontakt", 8 }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "Href", "LinkId", "Name", "Order" },
                values: new object[,]
                {
                    { 1, "/cardiology", 4, "Kardiologia", 1 },
                    { 2, "/urology", 4, "Urologia", 2 },
                    { 3, "/orthopedy", 4, "Ortopedia", 3 },
                    { 4, "/ginecology", 4, "Ginekologia", 4 },
                    { 5, "/ginecology", 4, "Internista", 5 },
                    { 6, "/pediatri", 4, "Pediatria", 6 },
                    { 7, "/endokrynology", 4, "Endokrynologia", 7 },
                    { 8, "/kids", 5, "USG Dzieci", 1 },
                    { 9, "/adults", 5, "USG Dorosłych", 2 },
                    { 10, "/pregnancy", 5, "USG Ciąży", 3 },
                    { 11, "/kids", 6, "ECHO Dzieci", 1 },
                    { 12, "/adults", 6, "ECHO Dorosłych", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Options_LinkId",
                table: "Options",
                column: "LinkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.AddColumn<bool>(
                name: "IsHeader",
                table: "Specializations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 10,
                column: "IsHeader",
                value: true);

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 11,
                column: "IsHeader",
                value: true);

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 12,
                column: "IsHeader",
                value: true);
        }
    }
}
