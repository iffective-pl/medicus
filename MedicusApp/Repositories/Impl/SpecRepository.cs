using MedicusApp.Models;
using MedicusApp.Models.Dto;

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
                        }).Single()
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
    }
}
