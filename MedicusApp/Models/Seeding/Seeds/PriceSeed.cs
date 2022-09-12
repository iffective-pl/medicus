namespace MedicusApp.Models.Seeding.Seeds
{
    public class PriceSeed
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Value { get; set; }

        public int SpecId { get; set; }
    }
}
