namespace MedicusApp.Models.Seeding.Seeds
{
    public class PriceSeed
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }

        public int SpecializationId { get; set; }
    }
}
