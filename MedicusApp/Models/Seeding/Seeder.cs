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
            using (Stream reader = File.OpenRead("Data/prices.json"))
                this.PriceSeeds = JsonSerializer.Deserialize<List<PriceSeed>>(reader) ?? new List<PriceSeed>();
            using (Stream reader = File.OpenRead("Data/descriptions.json"))
                this.DescriptionSeeds = JsonSerializer.Deserialize<List<DescriptionSeed>>(reader) ?? new List<DescriptionSeed>();
            using (Stream reader = File.OpenRead("Data/descriptiontexts.json"))
                this.DescriptionTextSeeds = JsonSerializer.Deserialize<List<DescriptionTextSeed>>(reader) ?? new List<DescriptionTextSeed>();
            using (Stream reader = File.OpenRead("Data/styles.json"))
                this.StyleSeeds = JsonSerializer.Deserialize<List<StyleSeed>>(reader) ?? new List<StyleSeed>();
            using (Stream reader = File.OpenRead("Data/links.json"))
                this.LinkSeeds = JsonSerializer.Deserialize<List<LinkSeed>>(reader) ?? new List<LinkSeed>();
            using (Stream reader = File.OpenRead("Data/headers.json"))
                this.HeaderSeeds = JsonSerializer.Deserialize<List<HeaderSeed>>(reader) ?? new List<HeaderSeed>();
            using (Stream reader = File.OpenRead("Data/statics.json"))
                this.StaticSeeds = JsonSerializer.Deserialize<List<StaticSeed>>(reader) ?? new List<StaticSeed>();
            using (Stream reader = File.OpenRead("Data/mainpages.json"))
                this.MainPageSeeds = JsonSerializer.Deserialize<List<MainPageSeed>>(reader) ?? new List<MainPageSeed>();
            using (Stream reader = File.OpenRead("Data/carousels.json"))
                this.CarouselSeeds = JsonSerializer.Deserialize<List<CarouselSeed>>(reader) ?? new List<CarouselSeed>();
            using (Stream reader = File.OpenRead("Data/advantages.json"))
                this.AdvantageSeeds = JsonSerializer.Deserialize<List<AdvantageSeed>>(reader) ?? new List<AdvantageSeed>();
            using (Stream reader = File.OpenRead("Data/services.json"))
                this.ServiceSeeds = JsonSerializer.Deserialize<List<ServiceSeed>>(reader) ?? new List<ServiceSeed>();
        }

        public List<ComapnySeed> ComapnySeeds { get; private set; }
        public List<EmailSeed> EmailSeeds { get; private set; }
        public List<PhoneSeed> PhoneSeeds { get; private set; }
        public List<DoctorSeed> DoctorSeeds { get; private set; }
        public List<SpecSeed> SpecSeeds { get; private set; }
        public List<DoctorSpecSeed> DoctorSpecSeeds { get; private set; }
        public List<WorkingHoursSeed> WorkingHoursSeeds { get; private set; }
        public List<HeaderSeed> HeaderSeeds { get; private set; }
        public List<LinkSeed> LinkSeeds { get; private set; }
        public List<PriceSeed> PriceSeeds { get; private set; }
        public List<DescriptionSeed> DescriptionSeeds { get; private set; }
        public List<DescriptionTextSeed> DescriptionTextSeeds { get; private set; }
        public List<StyleSeed> StyleSeeds { get; private set; }
        public List<StaticSeed> StaticSeeds { get; private set; }
        public List<MainPageSeed> MainPageSeeds { get; private set; }
        public List<CarouselSeed> CarouselSeeds { get; private set; }
        public List<AdvantageSeed> AdvantageSeeds { get; private set; }
        public List<ServiceSeed> ServiceSeeds { get; private set; }
    }
}
