using MedicusApp.Models.Dto.UI;
using MedicusApp.Repositories;

namespace MedicusApp.Services.Impl
{
    public class StaticService : IStaticService
    {
        private readonly IStaticRepository repository;

        public StaticService(IStaticRepository repository)
        {
            this.repository = repository;
        }

        public bool AddStatic(StaticDto staticDto)
        {
            return repository.AddStatic(staticDto);
        }

        public bool DeleteStatic(int staticId)
        {
            return repository.DeleteStatic(staticId);
        }

        public StaticDto GetStatic(int staticId)
        {
            return repository.GetStatic(staticId);
        }

        public IEnumerable<StaticDto> GetStaticDropdown()
        {
            return repository.GetStaticDropdown();
        }

        public IEnumerable<int> GetStaticIds()
        {
            return repository.GetStaticIds();
        }

        public bool UpdateStatic(StaticDto staticDto)
        {
            return repository.UpdateStatic(staticDto);
        }
    }
}
