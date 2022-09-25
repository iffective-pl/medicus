using MedicusApp.Models.Control;

namespace MedicusApp.Models.Dto.UI
{
    public class HeaderDto : Sort
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Href { get; set; }
        public bool? IsIndex { get; set; }
        public bool IsHidden { get; set; }
        public bool IsDropdown { get; set; }
        public IEnumerable<LinkDto>? Links { get; set; }
    }
}
