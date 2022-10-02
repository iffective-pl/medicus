using MedicusApp.Models.Control;
using MedicusApp.Models.Data.Desc;

namespace MedicusApp.Models.Data.UI
{
    public class Static : Delete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasMap { get; set; }
        public List<Description> Descriptions { get; set; }
    }
}
