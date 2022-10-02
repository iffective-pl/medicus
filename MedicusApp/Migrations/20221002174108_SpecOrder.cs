using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicusApp.Migrations
{
    public partial class SpecOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Specs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Specs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Specs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Specs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Order",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Specs",
                keyColumn: "Id",
                keyValue: 4,
                column: "Order",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Specs",
                keyColumn: "Id",
                keyValue: 5,
                column: "Order",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Specs",
                keyColumn: "Id",
                keyValue: 6,
                column: "Order",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Specs",
                keyColumn: "Id",
                keyValue: 7,
                column: "Order",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Specs",
                keyColumn: "Id",
                keyValue: 8,
                column: "Order",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Specs",
                keyColumn: "Id",
                keyValue: 9,
                column: "Order",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Specs",
                keyColumn: "Id",
                keyValue: 10,
                column: "Order",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Specs",
                keyColumn: "Id",
                keyValue: 11,
                column: "Order",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Specs",
                keyColumn: "Id",
                keyValue: 12,
                column: "Order",
                value: 12);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Specs");
        }
    }
}
