using MedicusApp.Models.Control;

namespace MedicusApp.Models.Subject.Dto
{
    public class PhoneDto : Sort
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public bool IsMobile { get; set; }
    }
}
