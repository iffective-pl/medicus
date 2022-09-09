using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicusApp.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpec_Doctors_DoctorsId",
                table: "DoctorSpec");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpec_Specializations_SpecializationsId",
                table: "DoctorSpec");

            migrationBuilder.RenameColumn(
                name: "SpecializationsId",
                table: "DoctorSpec",
                newName: "SpecId");

            migrationBuilder.RenameColumn(
                name: "DoctorsId",
                table: "DoctorSpec",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorSpec_SpecializationsId",
                table: "DoctorSpec",
                newName: "IX_DoctorSpec_SpecId");

            migrationBuilder.AddColumn<string>(
                name: "Saturday",
                table: "WorkHours",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sunday",
                table: "WorkHours",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "Specializations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "City", "FirstName", "LastName", "Title" },
                values: new object[,]
                {
                    { 1, "Włocławek", "Wiesław", "Nowakowski", "Dr n. med." },
                    { 2, "Włocławek", "Irena", "Nowakowska", "Dr n. med." },
                    { 3, "Łódź", "Dorota", "Nowakowska", "Prof. dr hab. med." },
                    { 4, "Włocławek", "Zbigniew", "Placek", "Lek. med." },
                    { 5, "Łódź", "Ewa", "Sewerynek", "Prof. dr hab. med." },
                    { 6, "Warszawa", "Tomasz", "Kmieć", "Dr n. med." },
                    { 7, "Łódź", "Marek", "Wrona", "Dr n. med." },
                    { 8, "Włocławek", "Janina", "Wielicka", "Lek. med." },
                    { 9, "Włocławek", "Bogdan", "Wojtecki", "Lek. med." },
                    { 10, "Włocławek", "Leszek", "Dura", "Lek. med." },
                    { 11, "Włocławek", "Zbyszek", "Ruszkowski", "Lek. med." }
                });

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "Id", "ClassName", "Href", "Name" },
                values: new object[,]
                {
                    { 1, "heart", "cardiology", "Kardiologia" },
                    { 2, "kidneys", "urology", "Urologia" },
                    { 3, "leg", "ortopedy", "Ortopedia" },
                    { 4, "pregnant", "ginecology", "Ginekologia" },
                    { 5, "coughing", "internist", "Internista" },
                    { 6, "lactation", "pediatrics", "Pediatria" },
                    { 7, "stethoscope", "endocrinology", "Endokrynologia" },
                    { 8, "neurology", "neurology", "Neurologia" },
                    { 9, "allergies", "dermatology", "Dermatologia" },
                    { 10, "echo", "echo", "ECHO Serca" },
                    { 11, "xray", "usg", "USG" },
                    { 12, "blood_pressure", "holter", "Holter" }
                });

            migrationBuilder.InsertData(
                table: "DoctorSpec",
                columns: new[] { "DoctorId", "SpecId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 12 },
                    { 2, 1 },
                    { 2, 6 },
                    { 2, 10 },
                    { 2, 12 },
                    { 3, 4 },
                    { 3, 11 },
                    { 4, 4 },
                    { 5, 7 },
                    { 6, 8 },
                    { 7, 2 },
                    { 8, 9 },
                    { 9, 3 },
                    { 10, 10 },
                    { 10, 12 },
                    { 11, 11 }
                });

            migrationBuilder.InsertData(
                table: "WorkHours",
                columns: new[] { "Id", "DoctorId", "Friday", "Monday", "Saturday", "SpecializationId", "Sunday", "Thursday", "Tuesday", "Wednesday" },
                values: new object[,]
                {
                    { 1, 1, "15:30 - 17.00", null, null, 1, null, "15:30 - 17.00", "15:30 - 17.00", "15:30 - 17.00" },
                    { 2, 2, null, "15:00 - 17.00", null, 1, null, "15:00 - 17.00", "15:00 - 17.00", "15:00 - 17.00" },
                    { 3, 2, null, "15:00 - 17.00", null, 6, null, "15:00 - 17.00", "15:00 - 17.00", "15:00 - 17.00" },
                    { 4, 3, "15:00 - 17.00", null, "15:00 - 17.00", 4, null, null, null, null },
                    { 5, 4, null, null, null, 4, null, "14:00 - 17.00", "14:00 - 17.00", "14:00 - 17.00" },
                    { 6, 5, null, null, "od 9:00 (raz w miesiącu)", 7, null, null, null, null },
                    { 7, 6, null, null, "od 9:00 (raz w miesiącu)", 8, null, null, null, null },
                    { 8, 7, null, null, "od 11:00 (raz w miesiącu)", 2, null, null, null, null },
                    { 9, 8, null, null, null, 9, null, "15:30 - 17.00", "15:30 - 17.00", "15:30 - 17.00" },
                    { 10, 9, "16:00 - 17:00", null, null, 3, null, "15:30 - 17.00", "15:30 - 17.00", "15:30 - 17.00" },
                    { 12, 2, null, null, null, 10, null, null, null, "15:00 - 17.00" },
                    { 13, 10, null, null, null, 10, null, null, "14:00 - 16.00", null },
                    { 14, 11, null, null, null, 11, null, "15:00 - 16.30", null, null },
                    { 15, 3, "12:00 - 18.00", null, "12:00 - 18.00", 11, null, null, null, null },
                    { 16, 1, "15:30 - 17.00", null, null, 12, null, "15:30 - 17.00", "15:30 - 17.00", "15:30 - 17.00" },
                    { 17, 2, null, "15:00 - 17.00", null, 12, null, "15:00 - 17.00", "15:00 - 17.00", "15:00 - 17.00" },
                    { 18, 10, null, null, null, 12, null, null, "14:00 - 16.00", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_Name",
                table: "Specializations",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpec_Doctors_DoctorId",
                table: "DoctorSpec",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpec_Specializations_SpecId",
                table: "DoctorSpec",
                column: "SpecId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpec_Doctors_DoctorId",
                table: "DoctorSpec");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpec_Specializations_SpecId",
                table: "DoctorSpec");

            migrationBuilder.DropIndex(
                name: "IX_Specializations_Name",
                table: "Specializations");

            migrationBuilder.DeleteData(
                table: "DoctorSpec",
                keyColumns: new[] { "DoctorId", "SpecId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DoctorSpec",
                keyColumns: new[] { "DoctorId", "SpecId" },
                keyValues: new object[] { 1, 12 });

            migrationBuilder.DeleteData(
                table: "DoctorSpec",
                keyColumns: new[] { "DoctorId", "SpecId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "DoctorSpec",
                keyColumns: new[] { "DoctorId", "SpecId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "DoctorSpec",
                keyColumns: new[] { "DoctorId", "SpecId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "DoctorSpec",
                keyColumns: new[] { "DoctorId", "SpecId" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "DoctorSpec",
                keyColumns: new[] { "DoctorId", "SpecId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "DoctorSpec",
                keyColumns: new[] { "DoctorId", "SpecId" },
                keyValues: new object[] { 3, 11 });

            migrationBuilder.DeleteData(
                table: "DoctorSpec",
                keyColumns: new[] { "DoctorId", "SpecId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "DoctorSpec",
                keyColumns: new[] { "DoctorId", "SpecId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "DoctorSpec",
                keyColumns: new[] { "DoctorId", "SpecId" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "DoctorSpec",
                keyColumns: new[] { "DoctorId", "SpecId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "DoctorSpec",
                keyColumns: new[] { "DoctorId", "SpecId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "DoctorSpec",
                keyColumns: new[] { "DoctorId", "SpecId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "DoctorSpec",
                keyColumns: new[] { "DoctorId", "SpecId" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DeleteData(
                table: "DoctorSpec",
                keyColumns: new[] { "DoctorId", "SpecId" },
                keyValues: new object[] { 10, 12 });

            migrationBuilder.DeleteData(
                table: "DoctorSpec",
                keyColumns: new[] { "DoctorId", "SpecId" },
                keyValues: new object[] { 11, 11 });

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WorkHours",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkHours",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkHours",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorkHours",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WorkHours",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WorkHours",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "WorkHours",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "WorkHours",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "WorkHours",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "WorkHours",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "WorkHours",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "WorkHours",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "WorkHours",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "WorkHours",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "WorkHours",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "WorkHours",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "WorkHours",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "Saturday",
                table: "WorkHours");

            migrationBuilder.DropColumn(
                name: "Sunday",
                table: "WorkHours");

            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "Specializations");

            migrationBuilder.RenameColumn(
                name: "SpecId",
                table: "DoctorSpec",
                newName: "SpecializationsId");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "DoctorSpec",
                newName: "DoctorsId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorSpec_SpecId",
                table: "DoctorSpec",
                newName: "IX_DoctorSpec_SpecializationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpec_Doctors_DoctorsId",
                table: "DoctorSpec",
                column: "DoctorsId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpec_Specializations_SpecializationsId",
                table: "DoctorSpec",
                column: "SpecializationsId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
