namespace MedicusApp.Models.Dto
{
    public class SpecDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Href { get; set; }
        public string ClassName { get; set; }
        public int Order { get; set; }
        public bool IsHeader { get; set; }
        public IEnumerable<DoctorDto> Doctors { get; set; }
    }
}
