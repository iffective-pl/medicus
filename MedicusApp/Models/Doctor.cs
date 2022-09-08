using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicusApp.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

        public List<Spec> Specializations { get; set; }
        public List<WorkingHours> WorkingHours { get; set; }
    }
}
