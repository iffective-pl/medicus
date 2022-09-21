using MedicusApp.Models.Data;

namespace MedicusApp.Models.Data.Person
{
    public class WorkingHours
    {
        public int Id { get; set; }
        public string? Monday { get; set; }
        public string? Tuesday { get; set; }
        public string? Wednesday { get; set; }
        public string? Thursday { get; set; }
        public string? Friday { get; set; }
        public string? Saturday { get; set; }
        public Doctor Doctor { get; set; }
        public Spec Specialization { get; set; }
    }
}
