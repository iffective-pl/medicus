using MedicusApp.Models.Dto;
using MedicusApp.Models.Dto.Person;
using MedicusApp.Repositories;

namespace MedicusApp.Services.Impl
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository repository;

        public DoctorService(IDoctorRepository repository)
        {
            this.repository = repository;
        }

        public bool AddDoctor(DoctorDto doctor)
        {
            return repository.AddDoctor(doctor);
        }

        public bool AddSpec(int doctorId, int specId)
        {
            return repository.AddSpec(doctorId, specId);
        }

        public bool DeleteDoctor(int doctorId)
        {
            return repository.DeleteDoctor(doctorId);
        }

        public bool DeleteSpec(int doctorId, int specId)
        {
            return repository.DeleteSpec(doctorId, specId);
        }

        public IEnumerable<SpecDto> GetAvailableSpecs(int doctorId)
        {
            return repository.GetAvailableSpecs(doctorId);
        }

        public DoctorDto GetDoctor(int doctorId)
        {
            return repository.GetDoctor(doctorId);
        }

        public IEnumerable<int> GetDoctors()
        {
            return repository.GetDoctors();
        }

        public bool UpdateDoctor(DoctorDto doctor)
        {
            return repository.UpdateDoctor(doctor);
        }

        public bool UpdateWorkingHours(WorkingHoursDto workHours)
        {
            return repository.UpdateWorkingHours(workHours);
        }
    }
}
