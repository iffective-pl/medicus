using MedicusApp.Models.Data.Main;
using MedicusApp.Models.Dto.Main;

namespace MedicusApp.Repositories
{
    public interface IMPRepository
    {
        public MainPage GetMainPage();
        public bool UpdateAdvantage(AdvantageDto advantage);
    }
}
