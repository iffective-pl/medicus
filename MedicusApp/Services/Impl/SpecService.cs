using MedicusApp.Models;
using MedicusApp.Models.Dto;
using MedicusApp.Models.Dto.Desc;
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

        public SpecDto? GetFullSpec(int id)
        {
            return repository.GetFullSpec(id);
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

        public bool AddDesc(DescriptionDto description)
        {
            return repository.AddDesc(description);
        }

        public bool UpdateDesc(DescriptionDto description)
        {
            return repository.UpdateDesc(description);
        }

        public bool DeleteDesc(int descId)
        {
            return repository.DeleteDesc(descId);
        }

        public IEnumerable<int> GetPrices(int specId)
        {
            return repository.GetPrices(specId);
        }

        public PriceDto GetPrice(int priceId)
        {
            return repository.GetPrice(priceId);
        }

        public bool AddPrice(PriceDto price)
        {
            return repository.AddPrice(price);
        }

        public bool UpdatePrice(PriceDto price)
        {
            return repository.UpdatePrice(price);
        }

        public bool DeletePrice(int priceId)
        {
            return repository.DeletePrice(priceId);
        }

        public bool AddSpec(SpecDto spec)
        {
            return repository.AddSpec(spec);
        }

        public bool RemoveSpec(int specId)
        {
            return repository.RemoveSpec(specId);
        }
    }
}
