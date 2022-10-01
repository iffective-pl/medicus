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

        [HttpPost]
        public bool UpdateAdvantage(AdvantageDto advantage)
        {
            return service.UpdateAdvantage(advantage);
        }
    }
}
