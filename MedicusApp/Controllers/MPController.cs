using MedicusApp.Models.Dto.Main;
using MedicusApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicusApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class MPController : ControllerBase
    {
        private readonly IMPService service;

        public MPController(IMPService service)
        {
            this.service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public MainPageDto GetMainPage()
        {
            return service.GetMainPage();
        }

        [HttpPut]
        public bool AddCarousel(CarouselDto carousel)
        {
            return service.AddCarousel(carousel);
        }

        [HttpPost]
        public bool UpdateCarousel(CarouselDto carousel)
        {
            return service.UpdateCarousel(carousel);
        }

        [HttpDelete]
        public bool DeleteCarousel(int carouselId)
        {
            return service.DeleteCarousel(carouselId);
        }

        [HttpPut]
        public bool AddService(ServiceDto s)
        {
            return service.AddService(s);
        }

        [HttpPost]
        public bool UpdateService(ServiceDto s)
        {
            return service.UpdateService(s);
        }

        [HttpDelete]
        public bool DeleteService(int serviceId)
        {
            return service.DeleteCarousel(serviceId);
        }

        [HttpPost]
        public bool UpdateAdvantage(AdvantageDto advantage)
        {
            return service.UpdateAdvantage(advantage);
        }
    }
}
