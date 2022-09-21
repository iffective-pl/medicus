using MedicusApp.Models.Control;

namespace MedicusApp.Models.Dto.UI
{
    public class LinkDto : Sort
    {
        public int Id { get; set; }
        public string Href { get; set; }
        public SpecDto? Spec { get; set; }
        public HeaderDto? Header { get; set; }
    }
}
