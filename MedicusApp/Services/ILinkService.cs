using MedicusApp.Models.Dto;

namespace MedicusApp.Services
{
    public interface ILinkService
    {
        public IEnumerable<LinkDto> GetLinks();
    }
}
