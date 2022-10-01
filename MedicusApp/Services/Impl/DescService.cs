using MedicusApp.Models.Dto.Desc;
using MedicusApp.Repositories;

namespace MedicusApp.Services.Impl
{
    public class DescService : IDescService
    {
        private readonly IDescRepository repository;

        public DescService(IDescRepository repository)
        {
            this.repository = repository;
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
    }
}
