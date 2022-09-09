namespace MedicusApp.Models
{
    public class Spec
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Href { get; set; }
        public string ClassName { get; set; }
        public int Order { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<WorkingHours> WorkingHours { get; set; }
    }
}
