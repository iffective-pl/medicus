using MedicusApp.Models;
using MedicusApp.Models.Dto;
using MedicusApp.Models.Dto.Desc;

namespace MedicusApp.Services
{
    public interface ISpecService
    {
        public IEnumerable<int> GetSpecIds();
        public SpecDto GetSpec(int specId);
        public IEnumerable<SpecDto> GetSpecs();
        public SpecDto? GetFullSpec(int id);
        public bool AddSpec(SpecDto spec);
        public bool UpdateSpec(SpecDto spec);
        public bool RemoveSpec(int specId);
        public IEnumerable<int> GetPrices(int specId);
        public PriceDto GetPrice(int priceId);
        public bool AddPrice(PriceDto price);
        public bool UpdatePrice(PriceDto price);
        public bool DeletePrice(int priceId);
        public bool OrderDoctor(int doctorId, DestinationDto destination);

        public bool OrderSpec(int specId, DestinationDto destination);
    }
}
