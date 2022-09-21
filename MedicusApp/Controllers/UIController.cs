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
        public IEnumerable<LinkDto> GetLinks()
        {
            return service.GetLinks();
        }

        [HttpGet]
        public IEnumerable<LinkDto> GetUnassignedLinks()
        {
            return service.GetUnassignedLinks();
        }
    }
}
