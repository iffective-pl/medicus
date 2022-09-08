using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;

namespace MedicusApp.Models
{
    public class DatabaseContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(Configuration.GetConnectionString("MedicusDatabase"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Spec>()
                .HasIndex(p => new { p.Name })
                .IsUnique(true);

            modelBuilder.Entity<Spec>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Doctor>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<WorkingHours>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            WorkingHours workingHours = new WorkingHours()
            {
                Id = 1,
                Tuesday = "15:30 - 17.00",
                Wednesday = "15:30 - 17.00",
                Thursday = "15:30 - 17.00",
                Friday = "15:30 - 17.00"
            };

            Doctor doctor = new Doctor() {
                Id = 1,
                Title = "Dr n. med.",
                FirstName = "Wiesław",
                LastName = "Nowakowski",
                City = "Włocławek",
                Specializations = new List<Spec>()
            };

            Spec spec = new Spec()
            {
                Id = 1,
                Name = "Kardiologia",
                Href = "cardio",
                Doctors = new List<Doctor>() { doctor }
            };

            doctor.Specializations.Add(spec);

            workingHours.Doctor = doctor;
            workingHours.Specialization = spec;

            modelBuilder.Entity<Spec>().HasData(spec);
            modelBuilder.Entity<Doctor>().HasData(doctor);
            modelBuilder.Entity<WorkingHours>().HasData(workingHours);
        }

        public void AddCascadingObject(object rootEntity)
        {
            ChangeTracker.TrackGraph(
                rootEntity,
                node =>
                    node.Entry.State = !node.Entry.IsKeySet ? EntityState.Added : EntityState.Unchanged
            );
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<WorkingHours> WorkHours { get; set; }
        public DbSet<Spec> Specializations { get; set; }
    }
}
