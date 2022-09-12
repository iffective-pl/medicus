namespace MedicusApp.Models.Seeding.Seeds
{
    public class DescriptionSeed
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public int Order { get; set; }

        public int SpecId { get; set; }
    }
}
