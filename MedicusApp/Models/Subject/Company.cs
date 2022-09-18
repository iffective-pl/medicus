using MedicusApp.Models.Versioning;

namespace MedicusApp.Models.Subject
{
    public class Company : Create
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Code { get; set; }
        public string City { get; set; }
        public List<Email> Emails { get; set; }
        public List<Phone> Phones { get; set; }
    }
}
