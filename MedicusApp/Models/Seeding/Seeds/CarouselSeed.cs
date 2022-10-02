namespace MedicusApp.Models.Seeding.Seeds
{
    public class CarouselSeed
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public string? MainTitle { get; set; }
        public string? SubTitle { get; set; }
        public string? Text { get; set; }
        public string? ButtonHref { get; set; }
        public string? ButtonText { get; set; }

        public int MainPageId { get; set; }
    }
}
