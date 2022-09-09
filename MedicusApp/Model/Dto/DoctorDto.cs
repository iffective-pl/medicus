namespace MedicusApp.Models.Dto
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public IEnumerable<WorkingHoursDto> WorkingHours { get; set; }
    }
}
