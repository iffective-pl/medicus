using MedicusApp.Models.Dto;
using MedicusApp.Models.Dto.Desc;
using MedicusApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicusApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
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
        public bool AddDesc(DescriptionDto description)
        {
            return service.AddDesc(description);
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

        [HttpGet]
        public IEnumerable<int> GetPrices(int specId)
        {
            return service.GetPrices(specId);
        }

        [HttpGet]
        public PriceDto GetPrice(int priceId)
        {
            return service.GetPrice(priceId);
        }

        [HttpPut]
        public bool AddPrice(PriceDto price)
        {
            return service.AddPrice(price);
        }

        [HttpPost]
        public bool UpdatePrice(PriceDto price)
        {
            return service.UpdatePrice(price);
        }

        [HttpDelete]
        public bool DeletePrice(int priceId)
        {
            return service.DeletePrice(priceId);
        }
    }
}
