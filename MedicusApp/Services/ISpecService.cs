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
        public SpecDto? GetFullSpec(string type);
        public bool AddSpec(SpecDto spec);
        public bool UpdateSpec(SpecDto spec);
        public bool RemoveSpec(int specId);
        public bool AddDesc(DescriptionDto description);
        public bool UpdateDesc(DescriptionDto description);
        public bool DeleteDesc(int descId);
        public IEnumerable<int> GetPrices(int specId);
        public PriceDto GetPrice(int priceId);
        public bool AddPrice(PriceDto price);
        public bool UpdatePrice(PriceDto price);
        public bool DeletePrice(int priceId);
    }
}
