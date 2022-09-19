using MedicusApp.Models;
using MedicusApp.Models.Dto;
using MedicusApp.Repositories;

namespace MedicusApp.Services.Impl
{
    public class SpecService : ISpecService
    {
        private readonly ISpecRepository repository;

        public SpecService(ISpecRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<SpecDto> GetSpecs()
        {
            return repository.GetSpecs();
        }

        public SpecDto? GetFullSpec(string type)
        {
            return repository.GetFullSpec(type);
        }

        public IEnumerable<int> GetSpecIds()
        {
            return repository.GetSpecIds();
        }

        public SpecDto GetSpec(int specId)
        {
            return repository.GetSpec(specId);
        }

        public bool UpdateSpec(SpecDto spec)
        {
            return repository.UpdateSpec(spec);
        }

        public bool AddDesc(int specId, DescriptionDto description)
        {
            return repository.AddDesc(specId, description);
        }

        public bool UpdateDesc(DescriptionDto description)
        {
            return repository.UpdateDesc(description);
        }

        public bool DeleteDesc(int descId)
        {
            return repository.DeleteDesc(descId);
        }
    }
}
