using MedicusApp.Models.Dto;
using MedicusApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicusApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService service;

        public CompanyController(ICompanyService service)
        {
            this.service = service;
        }

        [HttpGet]
        public CompanyDto GetCompany()
        {
            return service.GetCompany();
        }
    }
}
