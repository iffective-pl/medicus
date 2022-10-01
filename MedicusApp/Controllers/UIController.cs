using MedicusApp.Models.Dto;
using MedicusApp.Models.Dto.UI;
using MedicusApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicusApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UIController : ControllerBase
    {
        private readonly IUIService service;

        public UIController(IUIService service)
        {
            this.service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<HeaderDto> GetHeaders()
        {
            return service.GetHeaders();
        }

        [HttpGet]
        public IEnumerable<HeaderDto> GetHeadersOrder()
        {
            return service.GetHeadersOrder();
        }

        [HttpGet]
        public IEnumerable<HeaderDto> GetHeaderDropdown()
        {
            return service.GetHeaderDropdown();
        }

        [HttpGet]
        public HeaderDto GetHeader(int headerId)
        {
            return service.GetHeader(headerId);
        }

        [HttpGet]
        public IEnumerable<int> GetHeaderIds()
        {
            return service.GetHeaderIds();
        }

        [HttpGet]
        public IEnumerable<LinkDto> GetLinks()
        {
            return service.GetLinks();
        }

        [HttpGet]
        public IEnumerable<LinkDto> GetUnassignedLinks()
        {
            return service.GetUnassignedLinks();
        }

        [HttpPost]
        public bool OrderHeader([FromQuery] int headerId, [FromBody] DestinationDto destination)
        {
            return service.OrderHeader(headerId, destination);
        }

        [HttpPost]
        public bool MoveLink([FromQuery] int linkId, [FromBody] DestinationDto destination)
        {
            return service.MoveLink(linkId, destination);
        }

        [HttpPost]
        public bool OrderLink([FromQuery] int linkId, [FromBody] DestinationDto destination)
        {
            return service.OrderLink(linkId, destination);
        }

        [HttpPost]
        public bool AddHeader(HeaderDto header)
        {
            return service.AddHeader(header);
        }
        
        [HttpPost]
        public bool UpdateHeader(HeaderDto header)
        {
            return service.UpdateHeader(header);
        }

        [HttpDelete]
        public bool DeleteHeader(int headerId)
        {
            return service.DeleteHeader(headerId);
        }
    }
}
