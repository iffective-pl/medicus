using MedicusApp.Models;
using MedicusApp.Models.Dto;

namespace MedicusApp.Repositories.Impl
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DatabaseContext context;

        public CompanyRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public CompanyDto GetCompany()
        {
            return context.Companies.Select(c => new CompanyDto()
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
                Code = c.Code,
                City = c.City,
                Emails = c.Emails.Select(e => e.Address),
                Phones = c.Phones.Where(q => !q.IsMobile).Select(p => p.Number),
                MobilePhones = c.Phones.Where(q => q.IsMobile).Select(p => p.Number),
                AllPhones = c.Phones.Select(p => p.Number)
            }).Single();
        }
    }
}
