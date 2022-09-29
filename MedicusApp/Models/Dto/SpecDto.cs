using MedicusApp.Models.Control;
using MedicusApp.Models.Dto.Desc;
using MedicusApp.Models.Dto.Person;
using MedicusApp.Models.Dto.UI;

namespace MedicusApp.Models.Dto
{
    public class SpecDto : Delete
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public StyleDto? Style { get; set; }
        public LinkDto? Link { get; set; }
        public IEnumerable<DoctorDto>? Doctors { get; set; }
        public IEnumerable<WorkingHoursDto>? WorkingHours { get; set; }
        public IEnumerable<DescriptionDto>? Descriptions { get; set; }
        public IEnumerable<PriceDto>? Prices { get; set; }
    }
}
