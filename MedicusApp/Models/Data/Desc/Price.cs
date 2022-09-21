using MedicusApp.Models.Control;
using MedicusApp.Models.Data;

namespace MedicusApp.Models.Data.Desc
{
    public class Price : Sort
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Value { get; set; }
        public Spec Specialization { get; set; }
    }
}
