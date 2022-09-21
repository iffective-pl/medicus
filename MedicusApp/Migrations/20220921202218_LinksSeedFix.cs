using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicusApp.Migrations
{
    public partial class LinksSeedFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsIndex",
                table: "Headers",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Headers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 1,
                column: "Href",
                value: "cardiology");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 2,
                column: "Href",
                value: "urology");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 3,
                column: "Href",
                value: "orthopedy");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 4,
                column: "Href",
                value: "ginecology");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 5,
                column: "Href",
                value: "internist");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 6,
                column: "Href",
                value: "pediatrics");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 7,
                column: "Href",
                value: "endokrynology");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 8,
                column: "Href",
                value: "echokids");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 9,
                column: "Href",
                value: "echoadults");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 10,
                column: "Href",
                value: "echopregnancy");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 11,
                column: "Href",
                value: "usgkids");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 12,
                column: "Href",
                value: "usgadults");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Headers");

            migrationBuilder.AlterColumn<bool>(
                name: "IsIndex",
                table: "Headers",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 1,
                column: "Href",
                value: "/cardiology");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 2,
                column: "Href",
                value: "/urology");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 3,
                column: "Href",
                value: "/orthopedy");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 4,
                column: "Href",
                value: "/ginecology");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 5,
                column: "Href",
                value: "/internist");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 6,
                column: "Href",
                value: "/pediatrics");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 7,
                column: "Href",
                value: "/endokrynology");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 8,
                column: "Href",
                value: "/echokids");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 9,
                column: "Href",
                value: "/echoadults");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 10,
                column: "Href",
                value: "/echopregnancy");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 11,
                column: "Href",
                value: "/usgkids");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 12,
                column: "Href",
                value: "/usgadults");
        }
    }
}
