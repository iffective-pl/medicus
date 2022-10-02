using MedicusApp.Models.Control;

namespace MedicusApp.Models.Data.Main
{
    public class Carousel : Delete
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public string? MainTitle { get; set; }
        public string? SubTitle { get; set; }
        public string? Text { get; set; }
        public string? ButtonHref { get; set; }
        public string? ButtonText { get; set; }
    }
}
