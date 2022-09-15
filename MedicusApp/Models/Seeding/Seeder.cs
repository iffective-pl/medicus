using MedicusApp.Models.Seeding.Seeds;
using System.Text.Json;

namespace MedicusApp.Models.Seeding
{
    public class Seeder
    {
        public Seeder()
        {
            using (Stream reader = File.OpenRead("Data/companies.json"))
                this.ComapnySeeds = JsonSerializer.Deserialize<List<ComapnySeed>>(reader) ?? new List<ComapnySeed>();
            using (Stream reader = File.OpenRead("Data/emails.json"))
                this.EmailSeeds = JsonSerializer.Deserialize<List<EmailSeed>>(reader) ?? new List<EmailSeed>();
            using (Stream reader = File.OpenRead("Data/phones.json"))
                this.PhoneSeeds = JsonSerializer.Deserialize<List<PhoneSeed>>(reader) ?? new List<PhoneSeed>();
            using (Stream reader = File.OpenRead("Data/doctors.json"))
                this.DoctorSeeds = JsonSerializer.Deserialize<List<DoctorSeed>>(reader) ?? new List<DoctorSeed>();
            using (Stream reader = File.OpenRead("Data/specs.json"))
                this.SpecSeeds = JsonSerializer.Deserialize<List<SpecSeed>>(reader) ?? new List<SpecSeed>();
            using (Stream reader = File.OpenRead("Data/doctorspec.json"))
                this.DoctorSpecSeeds = JsonSerializer.Deserialize<List<DoctorSpecSeed>>(reader) ?? new List<DoctorSpecSeed>();
            using(Stream reader = File.OpenRead("Data/workinghours.json"))
                this.WorkingHoursSeeds = JsonSerializer.Deserialize<List<WorkingHoursSeed>>(reader) ?? new List<WorkingHoursSeed>();
            using (Stream reader = File.OpenRead("Data/links.json"))
                this.LinkSeeds = JsonSerializer.Deserialize<List<LinkSeed>>(reader) ?? new List<LinkSeed>();
            using(Stream reader = File.OpenRead("Data/options.json"))
                this.OptionSeeds = JsonSerializer.Deserialize<List<OptionSeed>>(reader) ?? new List<OptionSeed>();
            using (Stream reader = File.OpenRead("Data/prices.json"))
                this.PriceSeeds = JsonSerializer.Deserialize<List<PriceSeed>>(reader) ?? new List<PriceSeed>();
            using (Stream reader = File.OpenRead("Data/descriptions.json"))
                this.DescriptionSeeds = JsonSerializer.Deserialize<List<DescriptionSeed>>(reader) ?? new List<DescriptionSeed>();
            using (Stream reader = File.OpenRead("Data/descriptiontexts.json"))
                this.DescriptionTextSeeds = JsonSerializer.Deserialize<List<DescriptionTextSeed>>(reader) ?? new List<DescriptionTextSeed>();
        }

        public List<ComapnySeed> ComapnySeeds { get; private set; }
        public List<EmailSeed> EmailSeeds { get; private set; }
        public List<PhoneSeed> PhoneSeeds { get; private set; }
        public List<DoctorSeed> DoctorSeeds { get; private set; }
        public List<SpecSeed> SpecSeeds { get; private set; }
        public List<DoctorSpecSeed> DoctorSpecSeeds { get; private set; }
        public List<WorkingHoursSeed> WorkingHoursSeeds { get; private set; }
        public List<LinkSeed> LinkSeeds { get; private set; }
        public List<OptionSeed> OptionSeeds { get; private set; }
        public List<PriceSeed> PriceSeeds { get; private set; }
        public List<DescriptionSeed> DescriptionSeeds { get; private set; }
        public List<DescriptionTextSeed> DescriptionTextSeeds { get; private set; }
    }
}
