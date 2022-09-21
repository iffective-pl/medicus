using MedicusApp.Models;
using MedicusApp.Models.Data.Desc;
using MedicusApp.Models.Dto;
using MedicusApp.Models.Dto.Desc;
using MedicusApp.Models.Dto.Person;
using MedicusApp.Models.Dto.UI;
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
            return context.Specs.Select(s => new SpecDto()
            {
                Id = s.Id,
                Name = s.Name,
                Style = new StyleDto() {
                   Id = s.Style.Id,
                   ClassName = s.Style.ClassName,
                   Color = s.Style.Color
                },
                Link = new LinkDto()
                {
                    Id = s.Link.Id,
                    Href = s.Link.Href
                }
            });
        }

        public SpecDto? GetFullSpec(string type)
        {
            return context.Specs.Where(q => q.Link.Href.EndsWith(type)).Select(s => new SpecDto()
            {
                Id = s.Id,
                Name = s.Name,
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
                Prices = s.Prices.Where(p => p.Deleted == null).Select(p => new PriceDto()
                {
                    Id = p.Id,
                    SpecId = s.Id,
                    Title = p.Title,
                    Value = p.Value
                }),
                Descriptions = s.Descriptions.Where(d => d.Deleted == null).Select(d => new DescriptionDto()
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
            return context.Specs.Select(s => s.Id);
        }

        public SpecDto GetSpec(int specId)
        {
            return context.Specs.Where(s => s.Id == specId).Select(s => new SpecDto()
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
                Prices = s.Prices.Where(p => p.Deleted == null).Select(p => new PriceDto()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Value = p.Value,
                    Created = p.Created,
                    Deleted= p.Deleted,
                    Order= p.Order
                })
            }).Single();
        }

        public bool UpdateSpec(SpecDto spec)
        {
            try
            {
                var sp = context.Specs.Where(s => s.Id == spec.Id).Single();
                sp.Name = spec.Name;
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public bool AddDesc(DescriptionDto description)
        {
            try
            {
                var sp = context.Specs.Where(s => s.Id == description.SpecId).Include(s => s.Descriptions).Single();
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

        public IEnumerable<int> GetPrices(int specId)
        {
            return context.Specs.Where(s => s.Id == specId).Include(s => s.Prices).Single().Prices.Where(p => p.Deleted == null).Select(p => p.Id);
        }

        public PriceDto GetPrice(int priceId)
        {
            return context.Prices.Where(p => p.Id == priceId).Include(p => p.Specialization).Select(p => new PriceDto()
            {
                Id = p.Id,
                Title = p.Title,
                Value = p.Value,
                Created = p.Created,
                Deleted = p.Deleted,
                Order = p.Order,
                SpecId = p.Specialization.Id
            }).Single();
        }

        public bool AddPrice(PriceDto price)
        {
            try
            {
                var spec = context.Specs.Where(s => s.Id == price.SpecId).Include(s => s.Prices).Single();
                var p = new Price()
                {
                    Title = price.Title,
                    Value = price.Value
                };
                spec.Prices.Add(p);
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public bool UpdatePrice(PriceDto price)
        {
            try
            {
                var pr = context.Prices.Where(p => p.Id == price.Id).Single();
                pr.Title = price.Title;
                pr.Value = price.Value;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePrice(int priceId)
        {
            try
            {
                var pr = context.Prices.Where(p => p.Id == priceId).Single();
                pr.Deleted = DateTime.UtcNow;
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
