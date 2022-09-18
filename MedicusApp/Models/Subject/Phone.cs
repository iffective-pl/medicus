using MedicusApp.Models.Control;

namespace MedicusApp.Models.Subject
{
    public class Phone : Sort
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public bool IsMobile { get; set; }
    }
}
