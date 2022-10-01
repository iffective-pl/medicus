using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedicusApp.Migrations
{
    public partial class MainPageAdvantages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainPages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Advantages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false),
                    Href = table.Column<string>(type: "text", nullable: false),
                    MainPageId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advantages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advantages_MainPages_MainPageId",
                        column: x => x.MainPageId,
                        principalTable: "MainPages",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "MainPages",
                column: "Id",
                value: 1);

            migrationBuilder.InsertData(
                table: "Advantages",
                columns: new[] { "Id", "Href", "Icon", "MainPageId", "Name" },
                values: new object[,]
                {
                    { 1, "docs", "heart", 1, "Wysokiej klasy specjaliści" },
                    { 2, "", "ventilator", 1, "Nowoczesny sprzęt do ultrasonografii i echokardiografii" },
                    { 3, "", "wheelchair", 1, "Łatwy dostęp" },
                    { 4, "", "city", 1, "Komfortowe nowe wnętrza w idealnej lokalizacji" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advantages_MainPageId",
                table: "Advantages",
                column: "MainPageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advantages");

            migrationBuilder.DropTable(
                name: "MainPages");
        }
    }
}
