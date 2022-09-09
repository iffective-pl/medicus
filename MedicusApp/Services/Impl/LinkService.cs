using MedicusApp.Model.Dto;
using MedicusApp.Model.Links;
using MedicusApp.Repositories;

namespace MedicusApp.Services.Impl
{
    public class LinkService : ILinkService
    {
        private readonly ILinkRepository repository;

        public LinkService(ILinkRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<LinkDto> GetLinks()
        {
            return repository.GetLinks();
        }
    }
}
