namespace MedicusApp.Models.Dto
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Code { get; set; }
        public string City { get; set; }
        public IEnumerable<EmailDto>? Emails { get; set; }
        public IEnumerable<PhoneDto>? Phones { get; set; }
        public IEnumerable<PhoneDto>? MobilePhones { get; set; }
        public IEnumerable<PhoneDto>? AllPhones { get; set; }
    }
}
