namespace MedicusApp.Models.Dto.Person
{
    public class WorkingHoursDto
    {
        public int Id { get; set; }
        public string? Monday { get; set; }
        public string? Tuesday { get; set; }
        public string? Wednesday { get; set; }
        public string? Thursday { get; set; }
        public string? Friday { get; set; }
        public string? Saturday { get; set; }

        public int SpecId { get; set; }
        public int DoctorId { get; set; }
    }
}
