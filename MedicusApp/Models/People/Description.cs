using MedicusApp.Models.Control;

namespace MedicusApp.Models.People
{
    public class Description : Sort
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public List<DescriptionText> DescriptionTexts { get; set; }
    }
}
