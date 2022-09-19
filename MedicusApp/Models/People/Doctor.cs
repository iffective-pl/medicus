using MedicusApp.Models.Control;

namespace MedicusApp.Models.People
{
    public class Doctor : Sort
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? SpecTitle { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }

        public List<Spec> Specializations { get; set; }
        public List<WorkingHours> WorkingHours { get; set; }
    }
}
