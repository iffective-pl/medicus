namespace MedicusApp.Models.Dto
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Code { get; set; }
        public string City { get; set; }
        public IEnumerable<string> Emails { get; set; }
        public IEnumerable<string> Phones { get; set; }
        public IEnumerable<string> MobilePhones { get; set; }
        public IEnumerable<string> AllPhones { get; set; }
    }
}
