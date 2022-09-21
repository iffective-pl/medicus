using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicusApp.Migrations
{
    public partial class DeleteUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Specs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "Specs",
                type: "timestamp with time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Specs");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Specs");
        }
    }
}
