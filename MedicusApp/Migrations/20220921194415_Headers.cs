using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedicusApp.Migrations
{
    public partial class Headers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Descriptions_Specializations_SpecId",
                table: "Descriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpec_Specializations_SpecId",
                table: "DoctorSpec");

            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Specializations_SpecializationId",
                table: "Prices");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "WorkHours");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropColumn(
                name: "IsIndex",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Links");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Links",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "Links",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HeaderId",
                table: "Links",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecId",
                table: "Links",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Headers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Href = table.Column<string>(type: "text", nullable: false),
                    IsIndex = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    Deleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClassName = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StyleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specs_Styles_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Styles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkingHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Monday = table.Column<string>(type: "text", nullable: true),
                    Tuesday = table.Column<string>(type: "text", nullable: true),
                    Wednesday = table.Column<string>(type: "text", nullable: true),
                    Thursday = table.Column<string>(type: "text", nullable: true),
                    Friday = table.Column<string>(type: "text", nullable: true),
                    Saturday = table.Column<string>(type: "text", nullable: true),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    SpecializationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingHours_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkingHours_Specs_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Headers",
                columns: new[] { "Id", "Deleted", "Href", "IsIndex", "Name", "Order" },
                values: new object[,]
                {
                    { 1, null, "/", true, "Strona główna", 1 },
                    { 2, null, "about", false, "O nas", 2 },
                    { 3, null, "register", false, "Rejestracja", 3 },
                    { 4, null, "docs", false, "Nasi specjaliści", 4 },
                    { 5, null, "", false, "USG", 5 },
                    { 6, null, "", false, "ECHO Serca", 6 },
                    { 7, null, "", false, "Holter", 7 },
                    { 8, null, "contact", false, "Kontakt", 8 }
                });

            migrationBuilder.InsertData(
                table: "Styles",
                columns: new[] { "Id", "ClassName", "Color" },
                values: new object[,]
                {
                    { 1, "heart", "" },
                    { 2, "kidneys", "" },
                    { 3, "leg", "" },
                    { 4, "pregnant", "" },
                    { 5, "coughing", "" },
                    { 6, "lactation", "" },
                    { 7, "stethoscope", "" },
                    { 8, "neurology", "" },
                    { 9, "allergies", "" },
                    { 10, "echo", "" },
                    { 11, "xray", "" },
                    { 12, "blood_pressure", "" }
                });

            migrationBuilder.InsertData(
                table: "Specs",
                columns: new[] { "Id", "Name", "StyleId" },
                values: new object[,]
                {
                    { 1, "Kardiologia", 1 },
                    { 2, "Urologia", 2 },
                    { 3, "Ortopedia", 3 },
                    { 4, "Ginekologia", 4 },
                    { 5, "Internista", 5 },
                    { 6, "Pediatria", 6 },
                    { 7, "Endokrynologia", 7 },
                    { 8, "Neurologia", 8 },
                    { 9, "Dermatologia", 9 },
                    { 10, "ECHO Serca", 10 },
                    { 11, "USG", 11 },
                    { 12, "Holter", 12 }
                });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Href", "SpecId" },
                values: new object[] { "/cardiology", 1 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Href", "SpecId" },
                values: new object[] { "/urology", 2 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Href", "SpecId" },
                values: new object[] { "/orthopedy", 3 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Href", "SpecId" },
                values: new object[] { "/ginecology", 4 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Href", "SpecId" },
                values: new object[] { "/internist", 5 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Href", "SpecId" },
                values: new object[] { "/pediatrics", 6 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Href", "SpecId" },
                values: new object[] { "/endokrynology", 7 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Href", "Order", "SpecId" },
                values: new object[] { "/echokids", 1, 8 });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "Deleted", "HeaderId", "Href", "Order", "SpecId" },
                values: new object[,]
                {
                    { 9, null, null, "/echoadults", 2, 9 },
                    { 10, null, null, "/echopregnancy", 3, 10 },
                    { 11, null, null, "/usgkids", 1, 11 },
                    { 12, null, null, "/usgadults", 2, 12 }
                });

            migrationBuilder.InsertData(
                table: "WorkingHours",
                columns: new[] { "Id", "DoctorId", "Friday", "Monday", "Saturday", "SpecializationId", "Thursday", "Tuesday", "Wednesday" },
                values: new object[,]
                {
                    { 1, 1, "15:30 - 17.00", null, null, 1, "15:30 - 17.00", "15:30 - 17.00", "15:30 - 17.00" },
                    { 2, 2, null, "15:00 - 17.00", null, 1, "15:00 - 17.00", "15:00 - 17.00", "15:00 - 17.00" },
                    { 3, 2, null, "15:00 - 17.00", null, 6, "15:00 - 17.00", "15:00 - 17.00", "15:00 - 17.00" },
                    { 4, 3, "15:00 - 17.00", null, "15:00 - 17.00", 4, null, null, null },
                    { 5, 4, null, null, null, 4, "14:00 - 17.00", "14:00 - 17.00", "14:00 - 17.00" },
                    { 6, 5, null, null, "od 9:00 (raz w miesiącu)", 7, null, null, null },
                    { 7, 6, null, null, "od 9:00 (raz w miesiącu)", 8, null, null, null },
                    { 8, 7, null, null, "od 11:00 (raz w miesiącu)", 2, null, null, null },
                    { 9, 8, null, null, null, 9, "15:30 - 17.00", "15:30 - 17.00", "15:30 - 17.00" },
                    { 10, 9, "16:00 - 17:00", null, null, 3, "15:30 - 17.00", "15:30 - 17.00", "15:30 - 17.00" },
                    { 12, 2, null, null, null, 10, null, null, "15:00 - 17.00" },
                    { 13, 10, null, null, null, 10, null, "14:00 - 16.00", null },
                    { 14, 11, null, null, null, 11, "15:00 - 16.30", null, null },
                    { 15, 3, "12:00 - 18.00", null, "12:00 - 18.00", 11, null, null, null },
                    { 16, 1, "15:30 - 17.00", null, null, 12, "15:30 - 17.00", "15:30 - 17.00", "15:30 - 17.00" },
                    { 17, 2, null, "15:00 - 17.00", null, 12, "15:00 - 17.00", "15:00 - 17.00", "15:00 - 17.00" },
                    { 18, 10, null, null, null, 12, null, "14:00 - 16.00", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_HeaderId",
                table: "Links",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_SpecId",
                table: "Links",
                column: "SpecId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specs_Name",
                table: "Specs",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specs_StyleId",
                table: "Specs",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingHours_DoctorId",
                table: "WorkingHours",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingHours_SpecializationId",
                table: "WorkingHours",
                column: "SpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Descriptions_Specs_SpecId",
                table: "Descriptions",
                column: "SpecId",
                principalTable: "Specs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpec_Specs_SpecId",
                table: "DoctorSpec",
                column: "SpecId",
                principalTable: "Specs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Headers_HeaderId",
                table: "Links",
                column: "HeaderId",
                principalTable: "Headers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Specs_SpecId",
                table: "Links",
                column: "SpecId",
                principalTable: "Specs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Specs_SpecializationId",
                table: "Prices",
                column: "SpecializationId",
                principalTable: "Specs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Descriptions_Specs_SpecId",
                table: "Descriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpec_Specs_SpecId",
                table: "DoctorSpec");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Headers_HeaderId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Specs_SpecId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Specs_SpecializationId",
                table: "Prices");

            migrationBuilder.DropTable(
                name: "Headers");

            migrationBuilder.DropTable(
                name: "WorkingHours");

            migrationBuilder.DropTable(
                name: "Specs");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropIndex(
                name: "IX_Links_HeaderId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_SpecId",
                table: "Links");

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "HeaderId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "SpecId",
                table: "Links");

            migrationBuilder.AddColumn<bool>(
                name: "IsIndex",
                table: "Links",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Links",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Href = table.Column<string>(type: "text", nullable: false),
                    LinkId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Links_LinkId",
                        column: x => x.LinkId,
                        principalTable: "Links",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClassName = table.Column<string>(type: "text", nullable: false),
                    Href = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    SpecializationId = table.Column<int>(type: "integer", nullable: false),
                    Friday = table.Column<string>(type: "text", nullable: true),
                    Monday = table.Column<string>(type: "text", nullable: true),
                    Saturday = table.Column<string>(type: "text", nullable: true),
                    Thursday = table.Column<string>(type: "text", nullable: true),
                    Tuesday = table.Column<string>(type: "text", nullable: true),
                    Wednesday = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkHours_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkHours_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Href", "IsIndex", "Name" },
                values: new object[] { "/", true, "Strona główna" });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Href", "Name" },
                values: new object[] { "about", "O nas" });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Href", "Name" },
                values: new object[] { "register", "Rejestracja" });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Href", "Name" },
                values: new object[] { "docs", "Nasi specjaliści" });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Href", "Name" },
                values: new object[] { "docs/usg", "USG" });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Href", "Name" },
                values: new object[] { "docs/echo", "ECHO Serca" });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Href", "Name" },
                values: new object[] { "docs/holter", "Holter" });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Href", "Name", "Order" },
                values: new object[] { "contact", "Kontakt", 8 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "Href", "LinkId", "Name", "Order" },
                values: new object[,]
                {
                    { 1, "/cardiology", 4, "Kardiologia", 1 },
                    { 2, "/urology", 4, "Urologia", 2 },
                    { 3, "/orthopedy", 4, "Ortopedia", 3 },
                    { 4, "/ginecology", 4, "Ginekologia", 4 },
                    { 5, "/ginecology", 4, "Internista", 5 },
                    { 6, "/pediatrics", 4, "Pediatria", 6 },
                    { 7, "/endokrynology", 4, "Endokrynologia", 7 },
                    { 8, "#kids", 5, "USG Dzieci", 1 },
                    { 9, "#adults", 5, "USG Dorosłych", 2 },
                    { 10, "#pregnancy", 5, "USG Ciąży", 3 },
                    { 11, "#kids", 6, "ECHO Dzieci", 1 },
                    { 12, "#adults", 6, "ECHO Dorosłych", 2 }
                });

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "Id", "ClassName", "Href", "Name", "Order" },
                values: new object[,]
                {
                    { 1, "heart", "cardiology", "Kardiologia", 1 },
                    { 2, "kidneys", "urology", "Urologia", 2 },
                    { 3, "leg", "orthopedy", "Ortopedia", 3 },
                    { 4, "pregnant", "ginecology", "Ginekologia", 4 },
                    { 5, "coughing", "internist", "Internista", 5 },
                    { 6, "lactation", "pediatrics", "Pediatria", 6 },
                    { 7, "stethoscope", "endocrinology", "Endokrynologia", 7 },
                    { 8, "neurology", "neurology", "Neurologia", 8 },
                    { 9, "allergies", "dermatology", "Dermatologia", 9 },
                    { 10, "echo", "echo", "ECHO Serca", 10 },
                    { 11, "xray", "usg", "USG", 11 },
                    { 12, "blood_pressure", "holter", "Holter", 12 }
                });

            migrationBuilder.InsertData(
                table: "WorkHours",
                columns: new[] { "Id", "DoctorId", "Friday", "Monday", "Saturday", "SpecializationId", "Thursday", "Tuesday", "Wednesday" },
                values: new object[,]
                {
                    { 1, 1, "15:30 - 17.00", null, null, 1, "15:30 - 17.00", "15:30 - 17.00", "15:30 - 17.00" },
                    { 2, 2, null, "15:00 - 17.00", null, 1, "15:00 - 17.00", "15:00 - 17.00", "15:00 - 17.00" },
                    { 3, 2, null, "15:00 - 17.00", null, 6, "15:00 - 17.00", "15:00 - 17.00", "15:00 - 17.00" },
                    { 4, 3, "15:00 - 17.00", null, "15:00 - 17.00", 4, null, null, null },
                    { 5, 4, null, null, null, 4, "14:00 - 17.00", "14:00 - 17.00", "14:00 - 17.00" },
                    { 6, 5, null, null, "od 9:00 (raz w miesiącu)", 7, null, null, null },
                    { 7, 6, null, null, "od 9:00 (raz w miesiącu)", 8, null, null, null },
                    { 8, 7, null, null, "od 11:00 (raz w miesiącu)", 2, null, null, null },
                    { 9, 8, null, null, null, 9, "15:30 - 17.00", "15:30 - 17.00", "15:30 - 17.00" },
                    { 10, 9, "16:00 - 17:00", null, null, 3, "15:30 - 17.00", "15:30 - 17.00", "15:30 - 17.00" },
                    { 12, 2, null, null, null, 10, null, null, "15:00 - 17.00" },
                    { 13, 10, null, null, null, 10, null, "14:00 - 16.00", null },
                    { 14, 11, null, null, null, 11, "15:00 - 16.30", null, null },
                    { 15, 3, "12:00 - 18.00", null, "12:00 - 18.00", 11, null, null, null },
                    { 16, 1, "15:30 - 17.00", null, null, 12, "15:30 - 17.00", "15:30 - 17.00", "15:30 - 17.00" },
                    { 17, 2, null, "15:00 - 17.00", null, 12, "15:00 - 17.00", "15:00 - 17.00", "15:00 - 17.00" },
                    { 18, 10, null, null, null, 12, null, "14:00 - 16.00", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Options_LinkId",
                table: "Options",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_Name",
                table: "Specializations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkHours_DoctorId",
                table: "WorkHours",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkHours_SpecializationId",
                table: "WorkHours",
                column: "SpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Descriptions_Specializations_SpecId",
                table: "Descriptions",
                column: "SpecId",
                principalTable: "Specializations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpec_Specializations_SpecId",
                table: "DoctorSpec",
                column: "SpecId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Specializations_SpecializationId",
                table: "Prices",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
