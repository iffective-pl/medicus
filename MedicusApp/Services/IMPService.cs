using MedicusApp.Models.Data.Main;
using MedicusApp.Models.Dto.Main;

namespace MedicusApp.Services
{
    public interface IMPService
    {
        public MainPageDto GetMainPage();
        public bool UpdateAdvantage(AdvantageDto advantage);
    }
}
