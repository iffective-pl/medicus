using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicusApp.Migrations
{
    public partial class StaticSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DescriptionTexts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "");

            migrationBuilder.UpdateData(
                table: "Headers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Href",
                value: "static/1");

            migrationBuilder.InsertData(
                table: "Statics",
                columns: new[] { "Id", "Deleted", "HasMap", "Name" },
                values: new object[] { 1, null, true, "O nas" });

            migrationBuilder.UpdateData(
                table: "Descriptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Image", "SpecId", "StaticId" },
                values: new object[] { "medicus-static/about-1.jpg", null, 1 });

            migrationBuilder.InsertData(
                table: "Descriptions",
                columns: new[] { "Id", "Deleted", "Image", "Order", "SpecId", "StaticId" },
                values: new object[] { 2, null, "medicus-static/about-2.jpg", 2, null, 1 });

            migrationBuilder.InsertData(
                table: "DescriptionTexts",
                columns: new[] { "Id", "DescriptionId", "Text", "Title" },
                values: new object[] { 2, 2, "", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DescriptionTexts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Descriptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "DescriptionTexts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Fachowe konsultacje kardiologiczne");

            migrationBuilder.UpdateData(
                table: "Descriptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Image", "SpecId", "StaticId" },
                values: new object[] { "medicus/iStock-1395118113.jpg", 1, null });

            migrationBuilder.UpdateData(
                table: "Headers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Href",
                value: "about");
        }
    }
}
