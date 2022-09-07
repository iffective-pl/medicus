using System.ComponentModel.DataAnnotations;

namespace MedicusApp.Models
{
    public class Spec
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Href { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}
