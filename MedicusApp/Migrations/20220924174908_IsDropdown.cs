using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicusApp.Migrations
{
    public partial class IsDropdown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDropdown",
                table: "Headers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Headers",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsDropdown",
                value: true);

            migrationBuilder.UpdateData(
                table: "Headers",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsDropdown",
                value: true);

            migrationBuilder.UpdateData(
                table: "Headers",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsDropdown",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDropdown",
                table: "Headers");
        }
    }
}
