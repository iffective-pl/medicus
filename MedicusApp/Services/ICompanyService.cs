using MedicusApp.Models.Subject.Dto;
using System.Runtime.CompilerServices;

namespace MedicusApp.Services
{
    public interface ICompanyService
    {
        public CompanyDto GetCompany();
        public CompanyDto GetFullCompany();
        public bool UpdateCompany(CompanyDto company);
        public IEnumerable<PhoneDto> GetPhones();
        public IEnumerable<PhoneDto> GetMobilePhones();
        public bool UpdateNumber(PhoneDto number);
        public bool DeleteNumber(int id);
        public IEnumerable<EmailDto> GetEmails();
        public bool UpdateEmail(EmailDto email);
        public bool DeleteEmail(int id);
    }
}
