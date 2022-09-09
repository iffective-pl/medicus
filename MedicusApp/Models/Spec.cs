using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicusApp.Models
{
    public class Spec
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Href { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<WorkingHours> WorkingHours { get; set; }
    }
}
