using MedicusApp.Models;
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

        public List<Spec> GetSpecs()
        {
            return specRepository.GetSpecs();
        }
    }
}
