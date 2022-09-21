using MedicusApp.Models.Control;

namespace MedicusApp.Models.Dto.Desc
{
    public class PriceDto : Sort
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }

        public int SpecId { get; set; }
    }
}
