using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicusApp.Migrations
{
    public partial class SpecDoctorsOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoctorsOrder",
                table: "Specs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Specs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DoctorsOrder",
                value: "[1,2]");

            migrationBuilder.UpdateData(
                table: "Specs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DoctorsOrder",
                value: "[7]");

            migrationBuilder.UpdateData(
                table: "Specs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DoctorsOrder",
                value: "[9]");

            migrationBuilder.UpdateData(
                table: "Specs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DoctorsOrder",
                value: "[3,4]");

            migrationBuilder.UpdateData(
                table: "Specs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DoctorsOrder",
                value: "[]");

            migrationBuilder.UpdateData(
                table: "Specs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DoctorsOrder",
                value: "[2]");

            migrationBuilder.UpdateData(
                table: "Specs",
                keyColumn: "Id",
                keyValue: 7,
                column: "DoctorsOrder",
                value: "[5]");

            migrationBuilder.UpdateData(
                table: "Specs",
                keyColumn: "Id",
                keyValue: 8,
                column: "DoctorsOrder",
                value: "[6]");

            migrationBuilder.UpdateData(
                table: "Specs",
                keyColumn: "Id",
                keyValue: 9,
                column: "DoctorsOrder",
                value: "[8]");

            migrationBuilder.UpdateData(
                table: "Specs",
                keyColumn: "Id",
                keyValue: 10,
                column: "DoctorsOrder",
                value: "[2,10]");

            migrationBuilder.UpdateData(
                table: "Specs",
                keyColumn: "Id",
                keyValue: 11,
                column: "DoctorsOrder",
                value: "[11,3]");

            migrationBuilder.UpdateData(
                table: "Specs",
                keyColumn: "Id",
                keyValue: 12,
                column: "DoctorsOrder",
                value: "[1,2,10]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorsOrder",
                table: "Specs");
        }
    }
}
