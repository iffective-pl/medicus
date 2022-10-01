using MedicusApp.Models.Dto.Main;
using MedicusApp.Repositories;

namespace MedicusApp.Services.Impl
{
    public class MPService : IMPService
    {
        private readonly IMPRepository repository;

        public MPService(IMPRepository repository)
        {
            this.repository = repository;
        }

        public MainPageDto GetMainPage()
        {
            return repository.GetMainPage();
        }

        public bool UpdateAdvantage(AdvantageDto advantage)
        {
            return repository.UpdateAdvantage(advantage);
        }
    }
}
