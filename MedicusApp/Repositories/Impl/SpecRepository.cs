using MedicusApp.Models;
using MedicusApp.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
                ClassName = s.ClassName,
                Doctors = s.Doctors.Select(d => new DoctorDto()
                {
                    Id = d.Id,
                    Title = d.Title,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    City = d.City,
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
                            Saturday = wh.Saturday,
                            Sunday = wh.Sunday
                        })
                })
            });
        }
    }
}
