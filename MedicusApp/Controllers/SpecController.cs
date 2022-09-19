using MedicusApp.Models.Dto;
using MedicusApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicusApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SpecController : ControllerBase
    {
        private readonly ISpecService service;

        public SpecController(ISpecService service)
        {
            this.service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<SpecDto> GetSpecs()
        {
            return service.GetSpecs();
        }

        [HttpGet("{type}")]
        [AllowAnonymous]
        public SpecDto? GetFullSpecs(string type)
        {
            return service.GetFullSpec(type);
        }

        [HttpGet]
        public IEnumerable<int> GetSpecIds()
        {
            return service.GetSpecIds();
        }

        [HttpGet]
        public SpecDto GetSpec(int specId)
        {
            return service.GetSpec(specId);
        }

        [HttpPost]
        public bool UpdateSpec(SpecDto spec)
        {
            return service.UpdateSpec(spec);
        }

        [HttpPut]
        public bool AddDesc(int specId, DescriptionDto description)
        {
            return service.AddDesc(specId, description);
        }

        [HttpPost]
        public bool UpdateDesc(DescriptionDto description)
        {
            return service.UpdateDesc(description);
        }

        [HttpDelete]
        public bool DeleteDesc(int descId)
        {
            return service.DeleteDesc(descId);
        }
    }
}
