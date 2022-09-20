using MedicusApp.Models.Dto;
using MedicusApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicusApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
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

        [HttpGet]
        [AllowAnonymous]
        public CompanyDto GetFullCompany()
        {
            return service.GetFullCompany();
        }

        [HttpGet]
        public IEnumerable<EmailDto> GetEmails()
        {
            return service.GetEmails();
        }

        [HttpGet]
        public IEnumerable<PhoneDto> GetPhones()
        {
            return service.GetPhones();
        }

        [HttpGet]
        public IEnumerable<PhoneDto> GetMobilePhones()
        {
            return service.GetMobilePhones();
        }

        [HttpPost]
        public bool UpdateCompany(CompanyDto company)
        {
            return service.UpdateCompany(company);
        }

        [HttpPost]
        public bool UpdateNumber(PhoneDto number)
        {
            return service.UpdateNumber(number);
        }

        [HttpPost]
        public bool UpdateEmail(EmailDto email)
        {
            return service.UpdateEmail(email);
        }

        [HttpDelete]
        public bool DeleteNumber(int id)
        {
            return service.DeleteNumber(id);
        }

        [HttpDelete]
        public bool DeleteEmail(int id)
        {
            return service.DeleteEmail(id);
        }
    }
}
