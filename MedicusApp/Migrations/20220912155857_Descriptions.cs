using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedicusApp.Migrations
{
    public partial class Descriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Doctors",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    SpecId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Descriptions_Specializations_SpecId",
                        column: x => x.SpecId,
                        principalTable: "Specializations",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Descriptions",
                columns: new[] { "Id", "Image", "SpecId", "Text", "Title" },
                values: new object[] { 1, "images/new/iStock-1395118113.jpg", 1, "Zachęcamy do skorzystania z konsultacji kardiologicznych. Otaczamy specjalistyczną opieką pacjentów ze schorzeniami układu krążenia. Naszym zadaniem jest trafna diagnoza oraz zaproponowanie skutecznych metod leczenia. Pomagamy w takich schorzeniach jak: nadciśnienie tętnicze, choroba niedokrwienna serca (choroba wieńcowa), z jej ostrymi powikłaniami np. zawałem serca. Wykonujemy specjalistyczne badania kardiologiczne. Wczesne wykrycie nieprawidłowości pozwala na wdrożenie odpowiedniego leczenia. Konsultacje kardiologiczne zalecamy w szczególności pacjentom, którzy przebyli operacje serca, mają wrodzone wady serca, zmagają się z nadciśnieniem tętniczym, zaburzeniami lipidowymi i zaburzeniami rytmu serca.", "Fachowe konsultacje kardiologiczne" });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 5,
                column: "Href",
                value: "docs/usg");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 6,
                column: "Href",
                value: "docs/echo");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 7,
                column: "Href",
                value: "docs/holter");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 8,
                column: "Href",
                value: "#kids");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 9,
                column: "Href",
                value: "#adults");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 10,
                column: "Href",
                value: "#pregnancy");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 11,
                column: "Href",
                value: "#kids");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 12,
                column: "Href",
                value: "#adults");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_SpecId",
                table: "Descriptions",
                column: "SpecId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Descriptions");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Doctors");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 5,
                column: "Href",
                value: "usg");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 6,
                column: "Href",
                value: "echo");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 7,
                column: "Href",
                value: "holter");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 8,
                column: "Href",
                value: "/kids");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 9,
                column: "Href",
                value: "/adults");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 10,
                column: "Href",
                value: "/pregnancy");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 11,
                column: "Href",
                value: "/kids");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 12,
                column: "Href",
                value: "/adults");
        }
    }
}
