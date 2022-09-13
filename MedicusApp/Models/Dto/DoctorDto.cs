namespace MedicusApp.Models.Dto
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Image { get; set; }
        public WorkingHoursDto WorkingHours { get; set; }

        public int SpecId { get; set; }
    }
}
