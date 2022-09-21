using MedicusApp.Models.Subject.Dto;
using MedicusApp.Repositories;

namespace MedicusApp.Services.Impl
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository repository;

        public CompanyService(ICompanyRepository repository) {
            this.repository = repository;
        }

        public bool DeleteEmail(int id)
        {
            return repository.DeleteEmail(id);
        }

        public bool DeleteNumber(int id)
        {
            return repository.DeleteNumber(id);
        }

        public CompanyDto GetCompany()
        {
            return repository.GetCompany();
        }

        public IEnumerable<EmailDto> GetEmails()
        {
            return repository.GetEmails();
        }

        public CompanyDto GetFullCompany()
        {
            CompanyDto company = repository.GetFullCompany();
            company.AllPhones = company.AllPhones.OrderBy(s => s.Order);
            return company;
        }

        public IEnumerable<PhoneDto> GetMobilePhones()
        {
            return repository.GetMobilePhones();
        }

        public IEnumerable<PhoneDto> GetPhones()
        {
            return repository.GetPhones();
        }

        public bool UpdateCompany(CompanyDto company)
        {
            return repository.UpdateCompany(company);
        }

        public bool UpdateEmail(EmailDto email)
        {
            return repository.UpdateEmail(email);
        }

        public bool UpdateNumber(PhoneDto number)
        {
            return repository.UpdateNumber(number);
        }
    }
}
