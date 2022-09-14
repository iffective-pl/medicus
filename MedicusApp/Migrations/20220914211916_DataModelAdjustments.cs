using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedicusApp.Migrations
{
    public partial class DataModelAdjustments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sunday",
                table: "WorkHours");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Descriptions");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Descriptions");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Doctors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecTitle",
                table: "Doctors",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DescriptionTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    DescriptionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptionTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DescriptionTexts_Descriptions_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "Descriptions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Address = table.Column<string>(type: "text", nullable: false),
                    CompanyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emails_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "text", nullable: false),
                    IsMobile = table.Column<bool>(type: "boolean", nullable: false),
                    CompanyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "City", "Code", "Name" },
                values: new object[] { 1, "Plac Wolności 15", "Włocławek", "87-800", "Przychodnia Specjalistyczna MEDICUS" });

            migrationBuilder.InsertData(
                table: "DescriptionTexts",
                columns: new[] { "Id", "DescriptionId", "Text", "Title" },
                values: new object[] { 1, 1, "Zachęcamy do skorzystania z konsultacji kardiologicznych. Otaczamy specjalistyczną opieką pacjentów ze schorzeniami układu krążenia. Naszym zadaniem jest trafna diagnoza oraz zaproponowanie skutecznych metod leczenia. Pomagamy w takich schorzeniach jak: nadciśnienie tętnicze, choroba niedokrwienna serca (choroba wieńcowa), z jej ostrymi powikłaniami np. zawałem serca. Wykonujemy specjalistyczne badania kardiologiczne. Wczesne wykrycie nieprawidłowości pozwala na wdrożenie odpowiedniego leczenia. Konsultacje kardiologiczne zalecamy w szczególności pacjentom, którzy przebyli operacje serca, mają wrodzone wady serca, zmagają się z nadciśnieniem tętniczym, zaburzeniami lipidowymi i zaburzeniami rytmu serca.", "Fachowe konsultacje kardiologiczne" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "SpecTitle" },
                values: new object[] { "", "Specjalista w zakresie chorób wewnętrznych i kardiologii" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "SpecTitle" },
                values: new object[] { "", "Specjalista w zakresie pediatrii i kardiologii" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "SpecTitle" },
                values: new object[] { "", "Specjalista w zakresie położnictwa i ginekologii oraz perinatologii" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "SpecTitle" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "SpecTitle" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "SpecTitle" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "SpecTitle" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "SpecTitle" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "SpecTitle" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "SpecTitle" },
                values: new object[] { "", "" });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CompanyId" },
                values: new object[,]
                {
                    { 1, "biuro@medicus.włocławek.pl", 1 },
                    { 2, "rejestracja@medicus.włocławek.pl", 1 }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "CompanyId", "IsMobile", "Number" },
                values: new object[,]
                {
                    { 1, 1, false, "54 2313141" },
                    { 2, 1, false, "54 2313741" },
                    { 3, 1, true, "692 184 214" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionTexts_DescriptionId",
                table: "DescriptionTexts",
                column: "DescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_CompanyId",
                table: "Emails",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_CompanyId",
                table: "Phones",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DescriptionTexts");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "SpecTitle",
                table: "Doctors");

            migrationBuilder.AddColumn<string>(
                name: "Sunday",
                table: "WorkHours",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Doctors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Descriptions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Descriptions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Descriptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Text", "Title" },
                values: new object[] { "Zachęcamy do skorzystania z konsultacji kardiologicznych. Otaczamy specjalistyczną opieką pacjentów ze schorzeniami układu krążenia. Naszym zadaniem jest trafna diagnoza oraz zaproponowanie skutecznych metod leczenia. Pomagamy w takich schorzeniach jak: nadciśnienie tętnicze, choroba niedokrwienna serca (choroba wieńcowa), z jej ostrymi powikłaniami np. zawałem serca. Wykonujemy specjalistyczne badania kardiologiczne. Wczesne wykrycie nieprawidłowości pozwala na wdrożenie odpowiedniego leczenia. Konsultacje kardiologiczne zalecamy w szczególności pacjentom, którzy przebyli operacje serca, mają wrodzone wady serca, zmagają się z nadciśnieniem tętniczym, zaburzeniami lipidowymi i zaburzeniami rytmu serca.", "Fachowe konsultacje kardiologiczne" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "City",
                value: "Włocławek");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "City",
                value: "Włocławek");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "City",
                value: "Łódź");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "City",
                value: "Włocławek");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "City",
                value: "Łódź");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "City",
                value: "Warszawa");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "City",
                value: "Łódź");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "City",
                value: "Włocławek");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 9,
                column: "City",
                value: "Włocławek");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 10,
                column: "City",
                value: "Włocławek");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 11,
                column: "City",
                value: "Włocławek");
        }
    }
}
