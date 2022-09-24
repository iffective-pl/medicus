using MedicusApp.Models.Dto;
using MedicusApp.Models.Dto.UI;

namespace MedicusApp.Services
{
    public interface IUIService
    {
        public HeaderDto GetHeader(int headerId);
        public IEnumerable<HeaderDto> GetHeaders();
        public IEnumerable<HeaderDto> GetHeadersOrder();
        public IEnumerable<int> GetHeaderIds();
        public IEnumerable<LinkDto> GetLinks();
        public IEnumerable<LinkDto> GetUnassignedLinks();
        public bool OrderHeader(int headerId, DestinationDto destination);
        public bool MoveLink(int linkId, DestinationDto destination);
        public bool OrderLink(int linkId, DestinationDto destination);
        public bool AddHeader(HeaderDto header);
        public bool UpdateHeader(HeaderDto header);
        public bool DeleteHeader(int headerId);
    }
}
