using MedicusApp.Models.Dto;
using MedicusApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicusApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecController : ControllerBase
    {
        private readonly ISpecService specServices;

        public SpecController(ISpecService specServices)
        {
            this.specServices = specServices;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<SpecDto> GetSpecs()
        {
            return specServices.GetSpecs();
        }

        [HttpGet("{type}")]
        [AllowAnonymous]
        public SpecDto? GetFullSpecs(string type)
        {
            return specServices.GetFullSpec(type);
        }
    }
}
