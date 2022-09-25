using MedicusApp.Models.Control;
using MedicusApp.Models.Data.Desc;
using MedicusApp.Models.Data.Person;
using MedicusApp.Models.Data.UI;
using MedicusApp.Models.Links;

namespace MedicusApp.Models.Data
{
    public class Spec : Delete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Style Style { get; set; }
        public Link Link { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<WorkingHours> WorkingHours { get; set; }
        public List<Description> Descriptions { get; set; }
        public List<Price> Prices { get; set; }
    }
}
