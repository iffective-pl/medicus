using MedicusApp.Models.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Numerics;

namespace MedicusApp.Models
{
    public class DatabaseContext : DbContext
    {
        private readonly Seeds seeds;
        protected readonly IConfiguration configuration;

        public DatabaseContext(Seeds seeds, IConfiguration configuration)
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


            modelBuilder.Entity<Spec>().HasData(seeds.SpecSeeds);

            modelBuilder.Entity<Doctor>().HasData(seeds.DoctorSeeds);

            modelBuilder.Entity<WorkingHours>().HasData(seeds.WorkingHoursSeeds);
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<WorkingHours> WorkHours { get; set; }
        public DbSet<Spec> Specializations { get; set; }
    }
}
