using MedicusApp.Models.Control;
using MedicusApp.Models.Data;
using MedicusApp.Models.Data.UI;

namespace MedicusApp.Models.Links
{
    public class Link : Sort
    {
        public int Id { get; set; }
        public string? Href { get; set; }
        public Spec Spec { get; set; }
        public Header? Header { get; set; }

        public int SpecId { get; set; }
    }
}
