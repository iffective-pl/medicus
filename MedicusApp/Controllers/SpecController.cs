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

        [HttpGet]
        [AllowAnonymous]
        public SpecDto? GetFullSpecs(int id)
        {
            return service.GetFullSpec(id);
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

        [HttpPut]
        public bool AddSpec(SpecDto spec)
        {
            return service.AddSpec(spec);
        }

        [HttpPost]
        public bool UpdateSpec(SpecDto spec)
        {
            return service.UpdateSpec(spec);
        }

        [HttpDelete]
        public bool DeleteSpec(int specId)
        {
            return service.RemoveSpec(specId);
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
