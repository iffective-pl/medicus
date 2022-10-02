using MedicusApp.Models.Dto;
using MedicusApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicusApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService emailService;

        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpPost]
        public bool Send(EmailDto email)
        {
            if (string.IsNullOrWhiteSpace(email.Email) && string.IsNullOrWhiteSpace(email.Number))
            {
                return false;
            }

            return emailService.Send(email);
        }
    }
}
