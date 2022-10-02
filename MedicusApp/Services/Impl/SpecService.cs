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

        public bool OrderDoctor(int doctorId, DestinationDto destination)
        {
            return repository.OrderDoctor(doctorId, destination);
        }

        public bool OrderSpec(int specId, DestinationDto destination)
        {
            return repository.OrderSpec(specId, destination);
        }
    }
}
