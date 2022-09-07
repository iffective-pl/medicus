using MedicusApp.Model;
using MedicusApp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Entities;

namespace MedicusApp.Services.Impl
{
    public class SpecService : ISpecService
    {
        private readonly DBContext db;

        public SpecService(IOptions<MedicusDatabaseSettings> options)
        {
            this.db = new DBContext(options.Value.DatabaseName, options.Value.ConnectionString);
        }

        public Task<List<Spec>> GetSpecs()
        {
            return db.Find<Spec>().ExecuteAsync();
        }
    }
}
