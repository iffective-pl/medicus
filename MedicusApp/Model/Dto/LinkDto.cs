using MedicusApp.Model.Links;

namespace MedicusApp.Model.Dto
{
    public class LinkDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Href { get; set; }
        public bool IsIndex { get; set; }
        public IEnumerable<OptionDto> Options { get; set; }
    }
}
