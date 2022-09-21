using MedicusApp.Models;
using MedicusApp.Models.Data.Person;
using MedicusApp.Models.Dto;
using MedicusApp.Models.Dto.Person;
using Microsoft.EntityFrameworkCore;

namespace MedicusApp.Repositories.Impl
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DatabaseContext context;

        public DoctorRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public bool AddDoctor(DoctorDto doctor)
        {
            try
            {
                var doc = new Doctor()
                {
                    Title = doctor.Title,
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    SpecTitle = doctor.SpecTitle,
                    Description = doctor.Description
                };
                context.Doctors.Add(doc);
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public bool AddSpec(int doctorId, int specId)
        {
            try
            {
                var doctor = context.Doctors.Where(q => q.Id == doctorId).Include(d => d.Specs).Include(d => d.WorkingHours).Single();
                if (doctor.Specs.Any(q => q.Id == specId))
                {
                    return false;
                }
                var spec = context.Specs.Where(q => q.Id == specId).Single();
                var workingHours = new WorkingHours()
                {
                    Specialization = spec
                };
                doctor.WorkingHours.Add(workingHours);
                doctor.Specs.Add(spec);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteDoctor(int doctorId)
        {
            try
            {
                var doc = context.Doctors.Where(d => d.Id == doctorId).Single();
                doc.Deleted = DateTime.UtcNow;
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteSpec(int doctorId, int specId)
        {
            try
            {
                var doctor = context.Doctors.Where(q => q.Id == doctorId).Include(d => d.Specs).Include(d => d.WorkingHours).Single();
                if(!doctor.Specs.Any(q => q.Id == specId))
                {
                    return false;
                }
                var spec = context.Specs.Where(q => q.Id == specId).Single();
                var workingHours = doctor.WorkingHours.Where(q => q.Specialization.Id == spec.Id).Single();
                doctor.WorkingHours.Remove(workingHours);
                doctor.Specs.Remove(spec);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<SpecDto> GetAvailableSpecs(int doctorId)
        {
            try
            {
                var doctor = context.Doctors.Where(d => d.Id == doctorId).Include(d => d.Specs).Single();
                var specs = doctor.Specs.Select(s => s.Id);
                return context.Specs.Where(s => !specs.Contains(s.Id)).Select(s => new SpecDto()
                {
                    Id = s.Id,
                    Name = s.Name
                });
            } catch (Exception)
            {
                return new List<SpecDto>();
            }
        }

        public DoctorDto GetDoctor(int doctorId)
        {
            return context.Doctors.Where(d => d.Id == doctorId).Select(d => new DoctorDto()
            {
                Id = d.Id,
                Title = d.Title,
                FirstName = d.FirstName,
                LastName = d.LastName,
                SpecTitle = d.SpecTitle,
                Description = d.Description,
                Image = d.Image,
                Created = d.Created,
                Deleted = d.Deleted,
                Order = d.Order,
                Specializations = d.Specs.Select(s => new SpecDto()
                {
                    Id = s.Id,
                    Name = s.Name
                }),
                WorkingHours = d.WorkingHours.Select(wh => new WorkingHoursDto()
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
            }).Single();
        }

        public IEnumerable<int> GetDoctors()
        {
            return context.Doctors.Where(d => d.Deleted == null).OrderBy(d => d.LastName).ThenBy(d => d.FirstName).Select(d => d.Id);
        }

        public bool UpdateDoctor(DoctorDto doctor)
        {
            try
            {
                var doc = context.Doctors.Where(d => d.Id == doctor.Id).Single();
                doc.Id = doctor.Id;
                doc.Title = doctor.Title;
                doc.FirstName = doctor.FirstName;
                doc.LastName = doctor.LastName;
                doc.SpecTitle = doctor.SpecTitle;
                doc.Description = doctor.Description;
                doc.Image = doctor.Image;
                doc.Created = doctor.Created;
                doc.Deleted = doctor.Deleted;
                doc.Order = doctor.Order;
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false;
            }            
        }

        public bool UpdateWorkingHours(WorkingHoursDto workHours)
        {
            try
            {
                var workingHours = context.WorkingHours.Where(wh => wh.Doctor.Id == workHours.DoctorId && wh.Specialization.Id == workHours.SpecId).Single();
                workingHours.Monday = workHours.Monday;
                workingHours.Tuesday = workHours.Tuesday;
                workingHours.Wednesday = workHours.Wednesday;
                workingHours.Thursday = workHours.Thursday;
                workingHours.Friday = workHours.Friday;
                workingHours.Saturday = workHours.Saturday;
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }
    }
}
