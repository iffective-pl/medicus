using MedicusApp.Models.Dto.UI;

namespace MedicusApp.Services
{
    public interface IStaticService
    {
        public IEnumerable<int> GetStaticIds();
        public IEnumerable<StaticDto> GetStaticDropdown();
        public StaticDto GetStatic(int staticId);
        public bool AddStatic(StaticDto staticDto);
        public bool UpdateStatic(StaticDto staticDto);
        public bool DeleteStatic(int staticId);
    }
}
