namespace MedicusApp.Models.Subject.Dto
{
    public class EmailDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int Order { get; set; }
        public DateTime? Deleted { get; set; }
        public DateTime Created { get; set; }
    }
}
