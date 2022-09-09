using MedicusApp.Model.Dto;

namespace MedicusApp.Services
{
    public interface ILinkService
    {
        public IEnumerable<LinkDto> GetLinks();
    }
}
