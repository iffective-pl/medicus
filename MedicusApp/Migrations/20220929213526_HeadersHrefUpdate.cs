using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicusApp.Migrations
{
    public partial class HeadersHrefUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Headers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Href",
                value: "docs");

            migrationBuilder.UpdateData(
                table: "Headers",
                keyColumn: "Id",
                keyValue: 6,
                column: "Href",
                value: "docs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Headers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Href",
                value: "");

            migrationBuilder.UpdateData(
                table: "Headers",
                keyColumn: "Id",
                keyValue: 6,
                column: "Href",
                value: "");
        }
    }
}
