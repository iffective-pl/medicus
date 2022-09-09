namespace MedicusApp.Models.Seeding
{
    public class WorkingHoursSeed
    {
        public int Id { get; set; }
        public string? Monday { get; set; }
        public string? Tuesday { get; set; }
        public string? Wednesday { get; set; }
        public string? Thursday { get; set; }
        public string? Friday { get; set; }

        public int DoctorId { get; set; }
        public int SpecializationId {get; set;}
    }
}
