namespace MedicusApp.Models.Seeding.Seeds
{
    public class SpecSeed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StyleId { get; set; }
        public List<int>? DoctorsOrder { get; set; }
        public int Order { get; set; }
    }
}
