using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicusApp.Migrations
{
    public partial class PricesModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Specializations_SpecId",
                table: "Prices");

            migrationBuilder.DropIndex(
                name: "IX_Prices_SpecId",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "SpecId",
                table: "Prices");

            migrationBuilder.AddColumn<int>(
                name: "SpecializationId",
                table: "Prices",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Descriptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "medicus/iStock-1395118113.jpg");

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 1,
                column: "SpecializationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 2,
                column: "SpecializationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 3,
                column: "SpecializationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 4,
                column: "SpecializationId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Prices_SpecializationId",
                table: "Prices",
                column: "SpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Specializations_SpecializationId",
                table: "Prices",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Specializations_SpecializationId",
                table: "Prices");

            migrationBuilder.DropIndex(
                name: "IX_Prices_SpecializationId",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "SpecializationId",
                table: "Prices");

            migrationBuilder.AddColumn<int>(
                name: "SpecId",
                table: "Prices",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Descriptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "images/new/iStock-1395118113.jpg");

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 1,
                column: "SpecId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 2,
                column: "SpecId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 3,
                column: "SpecId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 4,
                column: "SpecId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Prices_SpecId",
                table: "Prices",
                column: "SpecId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Specializations_SpecId",
                table: "Prices",
                column: "SpecId",
                principalTable: "Specializations",
                principalColumn: "Id");
        }
    }
}
