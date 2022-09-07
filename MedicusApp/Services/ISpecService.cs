using MedicusApp.Model;

namespace MedicusApp.Services
{
    public interface ISpecService
    {
        Task<List<Spec>> GetSpecs();
    }
}
