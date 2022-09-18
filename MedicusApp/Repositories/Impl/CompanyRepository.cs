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

        public bool DeleteEmail(int id)
        {
            try
            {
                var email = context.Emails.Where(e => e.Id == id).Single();
                email.Deleted = DateTime.Now;
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteNumber(int id)
        {
            try
            {
                var number = context.Phones.Where(e => e.Id == id).Single();
                number.Deleted = DateTime.Now;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public CompanyDto GetCompany()
        {
            return context.Companies.Select(c => new CompanyDto()
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
                Code = c.Code,
                City = c.City
            }).Single();
        }

        public IEnumerable<EmailDto> GetEmails()
        {
            return context.Emails.Where(e => e.Deleted == null).Select(e => new EmailDto()
            {
                Id = e.Id,
                Address = e.Address,
                Created = e.Created,
                Deleted = e.Deleted,
                Order = e.Order
            });
        }

        public CompanyDto GetFullCompany()
        {
            return context.Companies.Select(c => new CompanyDto()
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
                Code = c.Code,
                City = c.City,
                Emails = c.Emails.Select(e => new EmailDto()
                {
                    Id = e.Id,
                    Address = e.Address,
                    Created = e.Created,
                    Deleted = e.Deleted,
                    Order = e.Order
                }),
                Phones = c.Phones.Where(q => !q.IsMobile).Select(p => new PhoneDto()
                {
                    Id = p.Id,
                    Number = p.Number,
                    IsMobile = p.IsMobile,
                    Created = p.Created,
                    Deleted = p.Deleted,
                    Order = p.Order
                }),
                MobilePhones = c.Phones.Where(q => q.IsMobile).Select(p => new PhoneDto()
                {
                    Id = p.Id,
                    Number = p.Number,
                    IsMobile = p.IsMobile,
                    Created = p.Created,
                    Deleted = p.Deleted,
                    Order = p.Order
                }),
                AllPhones = c.Phones.Select(p => new PhoneDto()
                {
                    Id = p.Id,
                    Number = p.Number,
                    IsMobile = p.IsMobile,
                    Created = p.Created,
                    Deleted = p.Deleted,
                    Order = p.Order
                })
            }).Single();
        }

        public IEnumerable<PhoneDto> GetMobilePhones()
        {
            return context.Phones.Where(p => p.IsMobile && p.Deleted == null).Select(p => new PhoneDto()
            {
                Id = p.Id,
                Number = p.Number,
                IsMobile = p.IsMobile,
                Created = p.Created,
                Deleted = p.Deleted,
                Order = p.Order
            });
        }

        public IEnumerable<PhoneDto> GetPhones()
        {
            return context.Phones.Where(p => !p.IsMobile && p.Deleted == null).Select(p => new PhoneDto()
            {
                Id = p.Id,
                Number = p.Number,
                IsMobile = p.IsMobile,
                Created = p.Created,
                Deleted = p.Deleted,
                Order = p.Order
            });
        }

        public bool UpdateCompany(CompanyDto company)
        {
            try
            {
                var comp = context.Companies.Where(c => c.Id == company.Id).Single();
                comp.Name = company.Name;
                comp.Address = company.Address;
                comp.Code = company.Code;
                comp.City = company.City;
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateEmail(EmailDto email)
        {
            try
            {
                var mail = context.Emails.Where(e => e.Id == email.Id).Single();
                mail.Address = email.Address;
                mail.Order = email.Order;
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateNumber(PhoneDto number)
        {
            try
            {
                var num = context.Phones.Where(p => p.Id == number.Id).Single();
                num.Number = number.Number;
                num.Order = number.Order;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
