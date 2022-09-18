using MedicusApp.Models.Control;
using MedicusApp.Models.Versioning;

namespace MedicusApp.Models.Subject
{
    public class Email : Sort
    {
        public int Id { get; set; }
        public string Address { get; set; }
    }
}
