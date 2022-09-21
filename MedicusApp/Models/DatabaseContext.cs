using MedicusApp.Models.Data;
using MedicusApp.Models.Data.Desc;
using MedicusApp.Models.Data.Person;
using MedicusApp.Models.Data.UI;
using MedicusApp.Models.Links;
using MedicusApp.Models.Seeding;
using MedicusApp.Models.Subject;
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

            modelBuilder.Entity<Description>()
                .Property(p => p.Created)
                .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<Price>()
                .Property(p => p.Created)
                .HasDefaultValueSql("NOW()");
            
            modelBuilder.Entity<Header>()
                .Property(p => p.Created)
                .HasDefaultValueSql("NOW()");
            
            modelBuilder.Entity<Link>()
                .Property(p => p.Created)
                .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<Spec>()
                .Property(p => p.Created)
                .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<Spec>()
                .HasMany(s => s.Doctors)
                .WithMany(d => d.Specs)
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

            modelBuilder.Entity<Link>()
                .HasOne(l => l.Spec)
                .WithOne(s => s.Link)
                .HasForeignKey<Link>(l => l.SpecId);

            modelBuilder.Entity<Header>()
                .Property(s => s.Order)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Header>()
                .Property(h => h.IsIndex)
                .HasDefaultValue(false);
            modelBuilder.Entity<Header>()
                .Property(h => h.IsHidden)
                .HasDefaultValue(false);

            modelBuilder.Entity<Link>()
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

            modelBuilder.Entity<Header>().HasData(seeds.HeaderSeeds);
            modelBuilder.Entity<Link>().HasData(seeds.LinkSeeds);
            modelBuilder.Entity<Style>().HasData(seeds.StyleSeeds);
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Phone> Phones { get; set; }

        public DbSet<Spec> Specs { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<DescriptionText> DescriptionTexts { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<WorkingHours> WorkingHours { get; set; }

        public DbSet<Link> Links { get; set; }
        public DbSet<Header> Headers { get; set; }
        public DbSet<Style> Styles { get; set; }
    }
}
