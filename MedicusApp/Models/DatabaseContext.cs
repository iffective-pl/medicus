using Microsoft.EntityFrameworkCore;

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

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<WorkingHours> WorkHours { get; set; }
        public DbSet<Spec> Specializations { get; set; }
    }
}
