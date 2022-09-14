using MedicusApp.Models.Dto;
using MedicusApp.Repositories;

namespace MedicusApp.Services.Impl
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository repository;

        public CompanyService(ICompanyRepository repository) {
            this.repository = repository;
        }

        public CompanyDto GetCompany()
        {
            CompanyDto company = repository.GetCompany();
            company.AllPhones = company.AllPhones.OrderBy(s => s);
            return company;
        }
    }
}
