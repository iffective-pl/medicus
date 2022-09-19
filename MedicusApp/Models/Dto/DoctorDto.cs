using MedicusApp.Models.Control;

namespace MedicusApp.Models.Dto
{
    public class DoctorDto : Sort
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SpecTitle { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public IEnumerable<WorkingHoursDto>? WorkingHours { get; set; }
        public IEnumerable<SpecDto>? Specializations { get; set; }
    }
}
