namespace MedicusApp.Models.Dto.Main
{
    public class MainPageDto
    {
        public int Id { get; set; }
        public IEnumerable<AdvantageDto> Advantages { get; set; }
    }
}
