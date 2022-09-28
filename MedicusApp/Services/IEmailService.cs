using MedicusApp.Models.Dto;

namespace MedicusApp.Services
{
    public interface IEmailService
    {
        public bool Send(EmailDto email);
    }
}
