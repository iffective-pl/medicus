using MedicusApp.Models.Dto.UI;
using MedicusApp.Models.Links;
using MedicusApp.Repositories;

namespace MedicusApp.Services.Impl
{
    public class UIService : IUIService
    {
        private readonly IUIRepository repository;

        public UIService(IUIRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<HeaderDto> GetHeaders()
        {
            return repository.GetHeaders();
        }

        public IEnumerable<LinkDto> GetLinks()
        {
            return repository.GetLinks();
        }

        public IEnumerable<LinkDto> GetUnassignedLinks()
        {
            return repository.GetLinks().Where(l => l.Header == null);
        }
    }
}
