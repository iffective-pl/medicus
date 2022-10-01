using MedicusApp.Models.Control;
using MedicusApp.Models.Links;

namespace MedicusApp.Models.Data.UI
{
    public class Header : Sort
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Href { get; set; }
        public bool IsIndex { get; set; }
        public bool IsHidden { get; set; }
        public bool IsDropdown { get; set; }
        public bool IsPredefined { get; set; }
        public List<Link> Links { get; set; }
    }
}
