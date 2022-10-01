using MedicusApp.Models.Dto.Desc;

namespace MedicusApp.Services
{
    public interface IDescService
    {
        public bool AddDesc(DescriptionDto description);
        public bool UpdateDesc(DescriptionDto description);
        public bool DeleteDesc(int descId);
    }
}
