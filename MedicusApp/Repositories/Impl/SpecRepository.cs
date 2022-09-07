using MedicusApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MedicusApp.Repositories.Impl
{
    public class SpecRepository : ISpecRepository
    {
        private readonly DatabaseContext context;

        public SpecRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public List<Spec> GetSpecs()
        {
            return context.Specializations
                .Include(i => i.Doctors)
                .ThenInclude(i => i.WorkingHours)
                .ToList();
        }
    }
}
