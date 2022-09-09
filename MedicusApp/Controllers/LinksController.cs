using MedicusApp.Model.Dto;
using MedicusApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicusApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinksController : ControllerBase
    {
        private readonly ILinkService service;

        public LinksController(ILinkService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<LinkDto> GetLinks()
        {
            return service.GetLinks();
        }
    }
}
