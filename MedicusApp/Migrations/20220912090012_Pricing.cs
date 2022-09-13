using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedicusApp.Migrations
{
    public partial class Pricing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false),
                    SpecId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prices_Specializations_SpecId",
                        column: x => x.SpecId,
                        principalTable: "Specializations",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "SpecId", "Title", "Value" },
                values: new object[,]
                {
                    { 1, 1, "Konsultacja", 150.0 },
                    { 2, 1, "Konsultacja + ECHO serca", 220.0 },
                    { 3, 1, "Konsultacja + ECHO serca + EKG", 250.0 },
                    { 4, 1, "ECHO Serca", 170.0 }
                });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "ECHO Serca");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_SpecId",
                table: "Prices",
                column: "SpecId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "ECHO");
        }
    }
}
