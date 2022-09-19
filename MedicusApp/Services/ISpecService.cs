using MedicusApp.Models;
using MedicusApp.Models.Dto;

namespace MedicusApp.Services
{
    public interface ISpecService
    {
        public IEnumerable<int> GetSpecIds();
        public SpecDto GetSpec(int specId);
        public IEnumerable<SpecDto> GetSpecs();
        public SpecDto? GetFullSpec(string type);
        public bool UpdateSpec(SpecDto spec);
        public bool AddDesc(int specId, DescriptionDto description);
        public bool UpdateDesc(DescriptionDto description);
        public bool DeleteDesc(int descId);
    }
}
