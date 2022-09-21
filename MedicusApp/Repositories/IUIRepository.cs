using MedicusApp.Models.Dto.UI;

namespace MedicusApp.Repositories
{
    public interface IUIRepository
    {
        public IEnumerable<HeaderDto> GetHeaders();
        public IEnumerable<LinkDto> GetLinks();
    }
}
