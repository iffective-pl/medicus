using MedicusApp.Models;
using MedicusApp.Models.Data;
using MedicusApp.Models.Data.Desc;
using MedicusApp.Models.Data.UI;
using MedicusApp.Models.Dto;
using MedicusApp.Models.Dto.Desc;
using MedicusApp.Models.Dto.Person;
using MedicusApp.Models.Dto.UI;
using MedicusApp.Models.Links;
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
            return context.Specs.Where(q => q.Deleted == null).OrderBy(s => s.Order).Select(s => new SpecDto()
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
                },
                Order = s.Order
            });
        }

        public SpecDto? GetFullSpec(int id)
        {
            return context.Specs.Where(q => q.Id == id && q.Deleted == null).Select(s => new SpecDto()
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
                DoctorsOrder = s.DoctorsOrder,
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
                }),
                Order = s.Order
            }).SingleOrDefault();
        }

        public IEnumerable<int> GetSpecIds()
        {
            return context.Specs.Where(s => s.Deleted == null).OrderBy(s => s.Order).Select(s => s.Id);
        }

        public SpecDto GetSpec(int specId)
        {
            return context.Specs.Where(s => s.Id == specId && s.Deleted == null).Select(s => new SpecDto()
            {
                Id = s.Id,
                Name = s.Name,
                Style = new StyleDto()
                {
                    Id = s.Style.Id,
                    ClassName = s.Style.ClassName,
                    Color = s.Style.Color
                },
                Doctors = s.Doctors.Select(d => new DoctorDto()
                {
                    Id = d.Id,
                    Title = d.Title,
                    FirstName = d.FirstName,
                    LastName = d.LastName
                }),
                DoctorsOrder = s.DoctorsOrder,
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
                }),
                Order = s.Order
            }).Single();
        }

        public bool UpdateSpec(SpecDto spec)
        {
            try
            {
                var sp = context.Specs.Where(s => s.Id == spec.Id).Include(s => s.Style).Single();
                sp.Name = spec.Name;
                sp.Style.ClassName = spec.Style.ClassName;
                sp.Style.Color = spec.Style.Color;
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

        public bool AddSpec(SpecDto spec)
        {
            try
            {
                int order = context.Links.Where(l => l.Deleted == null && l.Header == null).Count();
                var s = new Spec()
                {
                    Name = spec.Name,
                    DoctorsOrder = new List<int>(),
                    Style = new Style()
                    {
                        ClassName = spec.Style.ClassName,
                        Color = spec.Style.Color,
                    },
                    Order = order
                };
                context.Specs.Add(s);
                context.SaveChanges();
                Link l = new Link()
                {
                    Href = s.Id.ToString(),
                    Order = order
                };
                s.Link = l;
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveSpec(int specId)
        {
            try
            {
                var s = context.Specs.Where(s => s.Id == specId).Include(s => s.Link).Include(s => s.WorkingHours).Single();
                s.Deleted = DateTime.UtcNow;
                s.Link.Deleted = DateTime.UtcNow;
                var whs = s.WorkingHours.ToArray();
                foreach (var wh in whs)
                {
                    context.WorkingHours.Remove(wh);
                }
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public bool OrderDoctor(int doctorId, DestinationDto destination)
        {
            try
            {
                var spec = context.Specs.Where(s => s.Id == destination.DroppableId).Single();
                var currentIndex = spec.DoctorsOrder.IndexOf(doctorId);
                if (currentIndex == -1)
                {
                    return false;
                }
                spec.DoctorsOrder.Remove(doctorId);
                spec.DoctorsOrder.Insert(destination.Index.Value, doctorId);
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public bool OrderSpec(int specId, DestinationDto destination)
        {
            try
            {
                var spec = context.Specs.Single(s => s.Deleted == null && s.Id == specId);
                var list = context.Specs.Where(s => s.Deleted == null && s.Id != specId).ToList();
                list.Insert(destination.Index.Value, spec);
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Order = i;
                }
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }
    }
}
