using MedicusApp.Migrations;
using MedicusApp.Models;
using MedicusApp.Models.Control;
using MedicusApp.Models.Dto;
using MedicusApp.Models.People;
using Microsoft.EntityFrameworkCore;

namespace MedicusApp.Repositories.Impl
{
    public class SpecRepository : ISpecRepository
    {
        private readonly DatabaseContext context;

        public SpecRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public IEnumerable<SpecDto> GetSpecs()
        {
            return context.Specializations.Select(s => new SpecDto()
            {
                Id = s.Id,
                Name = s.Name,
                Href = s.Href,
                ClassName = s.ClassName,
                Order = s.Order
            });
        }

        public SpecDto? GetFullSpec(string type)
        {
            return context.Specializations.Where(q => q.Href == type).Select(s => new SpecDto()
            {
                Id = s.Id,
                Name = s.Name,
                Href = s.Href,
                ClassName = s.ClassName,
                Order = s.Order,
                Doctors = s.Doctors.Select(d => new DoctorDto()
                {
                    Id = d.Id,
                    Title = d.Title,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    SpecTitle = d.SpecTitle,
                    Description = d.Description,
                    WorkingHours = d.WorkingHours
                        .Where(q => q.Specialization.Id == s.Id)
                        .Select(wh => new WorkingHoursDto()
                        {
                            Id = wh.Id,
                            SpecId = wh.Specialization.Id,
                            Monday = wh.Monday,
                            Tuesday = wh.Tuesday,
                            Wednesday = wh.Wednesday,
                            Thursday = wh.Thursday,
                            Friday = wh.Friday,
                            Saturday = wh.Saturday
                        })
                }),
                Prices = s.Prices.Select(p => new PricesDto()
                {
                    Id = p.Id,
                    SpecId = s.Id,
                    Title = p.Title,
                    Value = p.Value
                }),
                Descriptions = s.Descriptions.Select(d => new DescriptionDto()
                {
                    Id = d.Id,
                    Image = d.Image,
                    DescriptionTexts = d.DescriptionTexts.Select(dt => new DescriptionTextDto()
                    {
                        Title = dt.Title,
                        Text = dt.Text
                    }),
                    SpecId = s.Id
                })
            }).SingleOrDefault();
        }

        public IEnumerable<int> GetSpecIds()
        {
            return context.Specializations.Select(s => s.Id);
        }

        public SpecDto GetSpec(int specId)
        {
            return context.Specializations.Where(s => s.Id == specId).Select(s => new SpecDto()
            {
                Id = s.Id,
                Name = s.Name,
                Descriptions = s.Descriptions.Where(d => d.Deleted == null).Select(d => new DescriptionDto()
                {
                    Id = d.Id,
                    Image = d.Image,
                    DescriptionTexts = d.DescriptionTexts.Select(dt => new DescriptionTextDto()
                    {
                        Id = dt.Id,
                        Title = dt.Title,
                        Text = dt.Text
                    }),
                    Created = d.Created,
                    Deleted = d.Deleted,
                    Order = d.Order
                }),
                Prices = s.Prices.Where(p => p.Deleted == null).Select(p => new PricesDto()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Value = p.Value,
                    Created = p.Created,
                    Deleted= p.Deleted,
                    Order= p.Order
                }),
                Order = s.Order
            }).Single();
        }

        public bool UpdateSpec(SpecDto spec)
        {
            try
            {
                var sp = context.Specializations.Where(s => s.Id == spec.Id).Single();
                sp.Name = spec.Name;
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public bool AddDesc(int specId, DescriptionDto description)
        {
            try
            {
                var sp = context.Specializations.Where(s => s.Id == specId).Single();
                var desc = new Description()
                {
                    Image = description.Image
                };
                sp.Descriptions.Add(desc);
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateDesc(DescriptionDto description)
        {
            try
            {
                var desc = context.Descriptions.Where(d => d.Id == description.Id).Include(d => d.DescriptionTexts).Single();
                desc.Image = description.Image;

                var toBeDeleted = desc.DescriptionTexts.Where(dt => !description.DescriptionTexts.Select(dt2 => dt2.Id).Contains(dt.Id)).Select(dt => dt.Id).ToList();

                foreach (var item in toBeDeleted)
                {
                    desc.DescriptionTexts.Remove(desc.DescriptionTexts.Where(dt => dt.Id == item).Single());
                }

                foreach(var item in description.DescriptionTexts.Where(dt => dt.Id != 0))
                {
                    var dt = desc.DescriptionTexts.Where(q => q.Id == item.Id).Single();
                    dt.Title = item.Title;
                    dt.Text = item.Text;
                }

                desc.DescriptionTexts.AddRange(description.DescriptionTexts
                    .Where(dt => dt.Id == 0)
                    .Select(dt => new DescriptionText()
                    {
                        Id = dt.Id,
                        Title = dt.Title,
                        Text = dt.Text
                    }));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteDesc(int descId)
        {
            try
            {
                var desc = context.Descriptions.Where(d => d.Id == descId).Single();
                desc.Deleted = DateTime.UtcNow;
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }
    }
}
