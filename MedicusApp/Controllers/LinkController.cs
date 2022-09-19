using MedicusApp.Models.Dto;
using MedicusApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicusApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly ILinkService service;

        public LinkController(ILinkService service)
        {
            this.service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<LinkDto> GetLinks()
        {
            return service.GetLinks();
        }
    }
}
