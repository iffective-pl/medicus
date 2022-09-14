namespace MedicusApp.Models.Dto
{
    public class DescriptionDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int Order { get; set; }
        public IEnumerable<DescriptionTextDto> DescriptionTexts { get; set; }

        public int SpecId { get; set; }
    }
}