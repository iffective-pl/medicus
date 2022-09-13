using MedicusApp.Models;
using MedicusApp.Models.Dto;
using MedicusApp.Repositories;

namespace MedicusApp.Services.Impl
{
    public class SpecService : ISpecService
    {
        private readonly ISpecRepository specRepository;

        public SpecService(ISpecRepository specRepository)
        {
            this.specRepository = specRepository;
        }

        public IEnumerable<SpecDto> GetSpecs()
        {
            return specRepository.GetSpecs();
        }

        public SpecDto? GetFullSpec(string type)
        {
            return specRepository.GetFullSpec(type);
        }
    }
}
