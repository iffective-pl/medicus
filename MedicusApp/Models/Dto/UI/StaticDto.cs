using MedicusApp.Models.Control;
using MedicusApp.Models.Dto.Desc;

namespace MedicusApp.Models.Dto.UI
{
    public class StaticDto : Delete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasMap { get; set; }
        public IEnumerable<DescriptionDto>? Descriptions { get; set; }
    }
}
