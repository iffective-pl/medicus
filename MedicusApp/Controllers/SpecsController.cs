using MedicusApp.Models;
using MedicusApp.Services;
using MedicusApp.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicusApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecsController : ControllerBase
    {
        private readonly ISpecService specServices;

        public SpecsController(ISpecService specServices)
        {
            this.specServices = specServices;
        }

        [HttpGet]
        public List<Spec> GetSpecs()
        {
            return specServices.GetSpecs();
        }
    }
}
