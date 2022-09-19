using MedicusApp.Models.Control;

namespace MedicusApp.Models.Dto
{
    public class PricesDto : Sort
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Value { get; set; }

        public int SpecId { get; set; }
    }
}
