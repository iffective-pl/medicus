namespace MedicusApp.Models.Seeding.Seeds
{
    public class ServiceSeed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Href { get; set; }
        public string Source { get; set; }

        public int MainPageId { get; set; }
    }
}
