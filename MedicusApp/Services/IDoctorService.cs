using MedicusApp.Models.Dto;

namespace MedicusApp.Services
{
    public interface IDoctorService
    {
        public IEnumerable<int> GetDoctors();
        public DoctorDto GetDoctor(int id);
        public bool UpdateDoctor(DoctorDto doctor);
        public bool DeleteDoctor(int id);
        public bool UpdateWorkingHours(WorkingHoursDto workHours);
        public bool AddSpec(int doctorId, int specId);
        public bool DeleteSpec(int doctorId, int specId);
        public IEnumerable<SpecDto> GetAvailableSpecs(int doctorId);
    }
}
