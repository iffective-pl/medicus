namespace MedicusApp.Model.Links
{
    public class Link
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Href { get; set; }
        public int Order { get; set; }
        public bool IsIndex { get; set; }
        public List<Option> Options { get; set; }
    }
}
