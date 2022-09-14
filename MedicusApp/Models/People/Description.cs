namespace MedicusApp.Models.People
{
    public class Description
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int Order { get; set; }
        public List<DescriptionText> DescriptionTexts { get; set; }
    }
}
