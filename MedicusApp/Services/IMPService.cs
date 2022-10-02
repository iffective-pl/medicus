using MedicusApp.Models.Data.Main;
using MedicusApp.Models.Dto.Main;

namespace MedicusApp.Services
{
    public interface IMPService
    {
        public MainPageDto GetMainPage();
        public bool AddCarousel(CarouselDto carousel);
        public bool UpdateCarousel(CarouselDto carousel);
        public bool DeleteCarousel(int carouselId);
        public bool AddService(ServiceDto service);
        public bool UpdateService(ServiceDto service);
        public bool DeleteService(int serviceId);
        public bool UpdateAdvantage(AdvantageDto advantage);
    }
}
