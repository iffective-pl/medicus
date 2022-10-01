using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedicusApp.Migrations
{
    public partial class StaticPages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Href",
                table: "Links",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "StaticId",
                table: "Descriptions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Statics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    Deleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statics", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_StaticId",
                table: "Descriptions",
                column: "StaticId");

            migrationBuilder.AddForeignKey(
                name: "FK_Descriptions_Statics_StaticId",
                table: "Descriptions",
                column: "StaticId",
                principalTable: "Statics",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Descriptions_Statics_StaticId",
                table: "Descriptions");

            migrationBuilder.DropTable(
                name: "Statics");

            migrationBuilder.DropIndex(
                name: "IX_Descriptions_StaticId",
                table: "Descriptions");

            migrationBuilder.DropColumn(
                name: "StaticId",
                table: "Descriptions");

            migrationBuilder.AlterColumn<string>(
                name: "Href",
                table: "Links",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
