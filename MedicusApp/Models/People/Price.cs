using MedicusApp.Models.Control;

namespace MedicusApp.Models.People
{
    public class Price : Sort
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Value { get; set; }
        public Spec Specialization { get; set; }
    }
}
