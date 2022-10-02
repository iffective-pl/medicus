namespace MedicusApp.Models.Dto.Main
{
    public class MainPageDto
    {
        public int Id { get; set; }
        public IEnumerable<CarouselDto> Carousels { get; set; }
        public IEnumerable<ServiceDto> Services { get; set; }
        public IEnumerable<AdvantageDto> Advantages { get; set; }
    }
}
