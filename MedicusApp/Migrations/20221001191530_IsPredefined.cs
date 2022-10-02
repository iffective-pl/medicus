using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicusApp.Migrations
{
    public partial class IsPredefined : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasMap",
                table: "Statics",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPredefined",
                table: "Headers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Headers",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsPredefined",
                value: true);

            migrationBuilder.UpdateData(
                table: "Headers",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsPredefined",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasMap",
                table: "Statics");

            migrationBuilder.DropColumn(
                name: "IsPredefined",
                table: "Headers");
        }
    }
}
