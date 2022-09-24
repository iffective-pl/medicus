using MedicusApp.Models.Control;

namespace MedicusApp.Models.Subject.Dto
{
    public class EmailDto : Sort
    {
        public int Id { get; set; }
        public string Address { get; set; }
    }
}
