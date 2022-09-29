using MedicusApp.Models.Subject.Dto;

namespace MedicusApp.Repositories
{
    public interface ICompanyRepository
    {
        public CompanyDto GetCompany();
        public CompanyDto GetFullCompany();
        public bool UpdateCompany(CompanyDto company);
        public bool AddNumber(PhoneDto number);
        public IEnumerable<PhoneDto> GetPhones();
        public IEnumerable<PhoneDto> GetMobilePhones();
        public bool UpdateNumber(PhoneDto number);
        public bool DeleteNumber(int id);
        public bool AddEmail(EmailDto email);
        public IEnumerable<EmailDto> GetEmails();
        public bool UpdateEmail(EmailDto email);
        public bool DeleteEmail(int id);
    }
}
