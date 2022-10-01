using MedicusApp.Models.Dto.Desc;
using MedicusApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicusApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescController : ControllerBase
    {
        private readonly IDescService service;

        public DescController(IDescService service)
        {
            this.service = service;
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
    }
}
