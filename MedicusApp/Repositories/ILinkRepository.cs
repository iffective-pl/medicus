using MedicusApp.Models.Dto;

namespace MedicusApp.Repositories
{
    public interface ILinkRepository
    {
        public IEnumerable<LinkDto> GetLinks();
    }
}
