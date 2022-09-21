namespace MedicusApp.Models.Subject.Dto
{
    public class PhoneDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public bool IsMobile { get; set; }
        public int Order { get; set; }
        public DateTime? Deleted { get; set; }
        public DateTime Created { get; set; }
    }
}
