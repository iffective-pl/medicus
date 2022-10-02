using MedicusApp.Models.Control;

namespace MedicusApp.Models.Data.Main
{
    public class Service : Delete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Href { get; set; }
        public string Source { get; set; }
    }
}
