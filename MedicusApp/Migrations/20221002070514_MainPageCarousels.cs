using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedicusApp.Migrations
{
    public partial class MainPageCarousels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carousels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Source = table.Column<string>(type: "text", nullable: false),
                    MainTitle = table.Column<string>(type: "text", nullable: true),
                    SubTitle = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true),
                    ButtonHref = table.Column<string>(type: "text", nullable: true),
                    ButtonText = table.Column<string>(type: "text", nullable: true),
                    MainPageId = table.Column<int>(type: "integer", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    Deleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carousels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carousels_MainPages_MainPageId",
                        column: x => x.MainPageId,
                        principalTable: "MainPages",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Carousels",
                columns: new[] { "Id", "ButtonHref", "ButtonText", "Deleted", "MainPageId", "MainTitle", "Source", "SubTitle", "Text" },
                values: new object[,]
                {
                    { 1, "docs", "Nasi specjaliści", null, 1, "MEDICUS we Włocławku", "medicus-static/main-1.jpg", "Przychodnia Specjalistyczna", "Leczymy naszych pacjentów od 1990 roku." },
                    { 2, null, null, null, 1, null, "medicus-static/main-2.jpg", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carousels_MainPageId",
                table: "Carousels",
                column: "MainPageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carousels");
        }
    }
}
