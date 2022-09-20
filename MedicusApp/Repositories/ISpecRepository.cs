using MedicusApp.Models.Dto;

namespace MedicusApp.Repositories
{
    public interface ISpecRepository
    {
        public IEnumerable<int> GetSpecIds();
        public SpecDto GetSpec(int specId);
        public IEnumerable<SpecDto> GetSpecs();
        public SpecDto? GetFullSpec(string type);
        public bool UpdateSpec(SpecDto spec);
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
