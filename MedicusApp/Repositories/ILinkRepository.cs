using MedicusApp.Model.Dto;

namespace MedicusApp.Repositories
{
    public interface ILinkRepository
    {
        public IEnumerable<LinkDto> GetLinks();
    }
}
