using MedicusApp.Models;
using MedicusApp.Models.Dto;

namespace MedicusApp.Services
{
    public interface ISpecService
    {
        public IEnumerable<SpecDto> GetSpecs();
        public IEnumerable<SpecDto> GetFullSpecs();
    }
}
