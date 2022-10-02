namespace MedicusApp.Models.Data.Main
{
    public class MainPage
    {
        public int Id { get; set; }
        public List<Carousel> Carousels { get; set; }
        public List<Service> Services { get; set; }
        public List<Advantage> Advantages { get; set; }
    }
}
