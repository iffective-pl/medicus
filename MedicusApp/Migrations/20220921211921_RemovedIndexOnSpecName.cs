using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicusApp.Migrations
{
    public partial class RemovedIndexOnSpecName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Specs_Name",
                table: "Specs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Specs_Name",
                table: "Specs",
                column: "Name",
                unique: true);
        }
    }
}
