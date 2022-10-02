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

        public bool AddCarousel(CarouselDto carousel)
        {
            return repository.AddCarousel(carousel);
        }

        public bool UpdateCarousel(CarouselDto carousel)
        {
            return repository.UpdateCarousel(carousel);
        }

        public bool DeleteCarousel(int carouselId)
        {
            return repository.DeleteCarousel(carouselId);
        }

        public MainPageDto GetMainPage()
        {
            return repository.GetMainPage();
        }

        public bool AddService(ServiceDto service)
        {
            return repository.AddService(service);
        }

        public bool UpdateService(ServiceDto service)
        {
            return repository.UpdateService(service);
        }

        public bool DeleteService(int serviceId)
        {
            return repository.DeleteService(serviceId);
        }

        public bool UpdateAdvantage(AdvantageDto advantage)
        {
            return repository.UpdateAdvantage(advantage);
        }
    }
}
