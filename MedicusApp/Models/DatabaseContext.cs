using MedicusApp.Models.Links;
using MedicusApp.Models.People;
using MedicusApp.Models.Seeding;
using MedicusApp.Models.Subject;
using MedicusApp.Models.Versioning;
using Microsoft.EntityFrameworkCore;

namespace MedicusApp.Models
{
    public class DatabaseContext : DbContext
    {
        private readonly Seeder seeds;
        protected readonly IConfiguration configuration;

        public DatabaseContext(Seeder seeds, IConfiguration configuration)
        {
            this.seeds = seeds;
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("MedicusDatabase"));
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .Property(c => c.Created)
                .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<Email>()
                .Property(e => e.Created)
                .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<Phone>()
                .Property(p => p.Created)
                .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<Doctor>()
                .Property(p => p.Created)
                .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<Spec>()
                .HasMany(s => s.Doctors)
                .WithMany(s => s.Specializations)
                .UsingEntity<Dictionary<int, int>>(
                    "DoctorSpec",
                    d => d.HasOne<Doctor>().WithMany().HasForeignKey("DoctorId"),
                    s => s.HasOne<Spec>().WithMany().HasForeignKey("SpecId"),
                    je =>
                    {
                        je.HasKey("DoctorId", "SpecId");
                        je.HasData(seeds.DoctorSpecSeeds);
                    }
                )
                .HasIndex(p => new { p.Name })
                .IsUnique(true);
            modelBuilder.Entity<Spec>()
                .Property(s => s.Order)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Link>()
                .Property(s => s.IsIndex)
                .HasDefaultValue(false);
            modelBuilder.Entity<Link>()
                .Property(s => s.Order)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Option>()
                .Property(s => s.Order)
                .ValueGeneratedOnAdd();


            modelBuilder.Entity<Company>().HasData(seeds.ComapnySeeds);
            modelBuilder.Entity<Email>().HasData(seeds.EmailSeeds);
            modelBuilder.Entity<Phone>().HasData(seeds.PhoneSeeds);

            modelBuilder.Entity<Spec>().HasData(seeds.SpecSeeds);
            modelBuilder.Entity<Price>().HasData(seeds.PriceSeeds);
            modelBuilder.Entity<Description>().HasData(seeds.DescriptionSeeds);
            modelBuilder.Entity<DescriptionText>().HasData(seeds.DescriptionTextSeeds);
            modelBuilder.Entity<Doctor>().HasData(seeds.DoctorSeeds);
            modelBuilder.Entity<WorkingHours>().HasData(seeds.WorkingHoursSeeds);

            modelBuilder.Entity<Link>().HasData(seeds.LinkSeeds);
            modelBuilder.Entity<Option>().HasData(seeds.OptionSeeds);
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Phone> Phones { get; set; }

        public DbSet<Spec> Specializations { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<DescriptionText> DescriptionTexts { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<WorkingHours> WorkHours { get; set; }

        public DbSet<Link> Links { get; set; }
        public DbSet<Option> Options { get; set; }
    }
}
