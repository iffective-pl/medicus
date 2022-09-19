using MedicusApp.Models.Dto;
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

        public bool AddSpec(int doctorId, int specId)
        {
            return repository.AddSpec(doctorId, specId);
        }

        public bool DeleteDoctor(int id)
        {
            return repository.DeleteDoctor(id);
        }

        public bool DeleteSpec(int doctorId, int specId)
        {
            return repository.DeleteSpec(doctorId, specId);
        }

        public IEnumerable<SpecDto> GetAvailableSpecs(int doctorId)
        {
            return repository.GetAvailableSpecs(doctorId);
        }

        public DoctorDto GetDoctor(int id)
        {
            return repository.GetDoctor(id);
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
