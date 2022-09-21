using MedicusApp.Models.Dto;
using MedicusApp.Models.Dto.Person;

namespace MedicusApp.Services
{
    public interface IDoctorService
    {
        public IEnumerable<int> GetDoctors();
        public DoctorDto GetDoctor(int doctorId);
        public bool AddDoctor(DoctorDto doctor);
        public bool UpdateDoctor(DoctorDto doctor);
        public bool DeleteDoctor(int doctorId);
        public bool UpdateWorkingHours(WorkingHoursDto workHours);
        public bool AddSpec(int doctorId, int specId);
        public bool DeleteSpec(int doctorId, int specId);
        public IEnumerable<SpecDto> GetAvailableSpecs(int doctorId);
    }
}
