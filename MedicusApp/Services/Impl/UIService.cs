using MedicusApp.Models.Dto;
using MedicusApp.Models.Dto.UI;
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

        public bool AddHeader(HeaderDto header)
        {
            return repository.AddHeader(header);
        }

        public bool DeleteHeader(int headerId)
        {
            return repository.DeleteHeader(headerId);
        }

        public HeaderDto GetHeader(int headerId)
        {
            return repository.GetHeader(headerId);
        }

        public IEnumerable<int> GetHeaderIds()
        {
            return repository.GetHeaders().Where(q => q.IsDropdown).Select(e => e.Id);
        }

        public IEnumerable<HeaderDto> GetHeaders()
        {
            return repository.GetHeaders();
        }

        public IEnumerable<HeaderDto> GetHeaderDropdown()
        {
            return repository.GetHeaderDropdown();
        }

        public IEnumerable<HeaderDto> GetHeadersOrder()
        {
            return repository.GetHeaders().Where(q => !q.IsIndex.Value);
        }

        public IEnumerable<LinkDto> GetLinks()
        {
            return repository.GetLinks();
        }

        public IEnumerable<LinkDto> GetLinkDropdown()
        {
            return repository.GetLinkDropdown();
        }

        public IEnumerable<LinkDto> GetUnassignedLinks()
        {
            return repository.GetLinks().Where(l => l.Header == null).OrderBy(l => l.Order);
        }

        public bool MoveLink(int linkId, DestinationDto destination)
        {
            return repository.MoveLink(linkId, destination);
        }

        public bool OrderHeader(int headerId, DestinationDto destination)
        {
            return repository.OrderHeader(headerId, destination);
        }

        public bool OrderLink(int linkId, DestinationDto destination)
        {
            return repository.OrderLink(linkId, destination);
        }

        public bool UpdateHeader(HeaderDto header)
        {
            return repository.UpdateHeader(header);
        }
    }
}
