using FluentEmail.Core;
using FluentEmail.Liquid;
using MedicusApp.Config;
using MedicusApp.Models.Dto;

namespace MedicusApp.Services.Impl
{
    public class EmailService : IEmailService
    {
        private readonly IFluentEmail Email;

        public EmailService(IFluentEmail email)
        {
            this.Email = email;
        }

        public bool Send(EmailDto email)
        {
            try
            {
                var template = @"
                {{ FirstName }} {{ LastName }} nawiązał kontakt
                Adres mailowy: {{ Email }}
                Numer telefonu: {{ Number }}
                Wiadomość: {{ Message }}";

                Email
                    .To("mateusz.lapies@iffective.pl")
                    .UsingTemplate(template, email)
                    .Send();

                return true;
            } catch (Exception)
            {
                return false;
            }
        }
    }
}
