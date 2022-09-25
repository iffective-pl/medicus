using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicusApp.Migrations
{
    public partial class TextFormatting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DescriptionTexts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Text",
                value: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DescriptionTexts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Text",
                value: "Zachęcamy do skorzystania z konsultacji kardiologicznych. Otaczamy specjalistyczną opieką pacjentów ze schorzeniami układu krążenia. Naszym zadaniem jest trafna diagnoza oraz zaproponowanie skutecznych metod leczenia. Pomagamy w takich schorzeniach jak: nadciśnienie tętnicze, choroba niedokrwienna serca (choroba wieńcowa), z jej ostrymi powikłaniami np. zawałem serca. Wykonujemy specjalistyczne badania kardiologiczne. Wczesne wykrycie nieprawidłowości pozwala na wdrożenie odpowiedniego leczenia. Konsultacje kardiologiczne zalecamy w szczególności pacjentom, którzy przebyli operacje serca, mają wrodzone wady serca, zmagają się z nadciśnieniem tętniczym, zaburzeniami lipidowymi i zaburzeniami rytmu serca.");
        }
    }
}
