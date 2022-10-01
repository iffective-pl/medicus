using MedicusApp.Models.Dto.UI;
using MedicusApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicusApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class StaticController : ControllerBase
    {
        private readonly IStaticService service;

        public StaticController(IStaticService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<int> GetStaticIds()
        {
            return service.GetStaticIds();
        }

        [HttpGet]
        public IEnumerable<StaticDto> GetStaticDropdown()
        {
            return service.GetStaticDropdown();
        }

        [HttpGet]
        [AllowAnonymous]
        public StaticDto GetStatic(int staticId)
        {
            return service.GetStatic(staticId);
        }

        [HttpPut]
        public bool AddStatic(StaticDto dto)
        {
            return service.AddStatic(dto);
        }

        [HttpPost]
        public bool UpdateStatic(StaticDto dto)
        {
            return service.UpdateStatic(dto);
        }

        [HttpDelete]
        public bool DeleteStatic(int staticId)
        {
            return service.DeleteStatic(staticId);
        }
    }
}
