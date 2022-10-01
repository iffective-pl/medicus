using MedicusApp.Models.Dto.Desc;

namespace MedicusApp.Repositories
{
    public interface IDescRepository
    {
        public bool AddDesc(DescriptionDto description);
        public bool UpdateDesc(DescriptionDto description);
        public bool DeleteDesc(int descId);
    }
}
