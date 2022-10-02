using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedicusApp.Migrations
{
    public partial class MainPageServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Href = table.Column<string>(type: "text", nullable: false),
                    Source = table.Column<string>(type: "text", nullable: false),
                    MainPageId = table.Column<int>(type: "integer", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    Deleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_MainPages_MainPageId",
                        column: x => x.MainPageId,
                        principalTable: "MainPages",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Deleted", "Description", "Href", "MainPageId", "Name", "Source" },
                values: new object[,]
                {
                    { 1, null, "", "", 1, "Konsultacje", "medicus-static/consult.jpg" },
                    { 2, null, "", "", 1, "ECHO Serca", "medicus-static/heartecho.jpg" },
                    { 3, null, "", "", 1, "USG Dorosłych", "medicus-static/usg-male.jpg" },
                    { 4, null, "", "", 1, "USG Ciąży", "medicus-static/usg-female.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_MainPageId",
                table: "Services",
                column: "MainPageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
