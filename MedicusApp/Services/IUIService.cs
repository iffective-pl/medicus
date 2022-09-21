using MedicusApp.Models.Dto.UI;

namespace MedicusApp.Services
{
    public interface IUIService
    {
        public IEnumerable<HeaderDto> GetHeaders();
        public IEnumerable<LinkDto> GetLinks();
        public IEnumerable<LinkDto> GetUnassignedLinks();
    }
}
