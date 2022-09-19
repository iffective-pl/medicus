using MedicusApp.Models.Dto;

namespace MedicusApp.Repositories
{
    public interface IDoctorRepository
    {
        public IEnumerable<int> GetDoctors();
        public DoctorDto GetDoctor(int id);
        public bool UpdateDoctor(DoctorDto doctor);
        public bool DeleteDoctor(int id);
        public bool UpdateWorkingHours(WorkingHoursDto workHours);
        public bool AddSpec(int doctorId, int specId);
        public IEnumerable<SpecDto> GetAvailableSpecs(int doctorId);
        public bool DeleteSpec(int doctorId, int specId);
    }
}
