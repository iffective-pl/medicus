using MedicusApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicusApp.Controllers
{
    public class SpecsController : Controller
    {
        private readonly ISpecService specService;

        public SpecsController(ISpecService specService)
        {
            this.specService = specService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
