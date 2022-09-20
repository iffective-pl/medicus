using MedicusApp.Services.Impl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicusApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MinioController : ControllerBase
    {
        private readonly MinioService service;

        public MinioController(MinioService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<string> GetFiles()
        {
            return service.GetFiles();
        }

        [HttpPost]
        public string UploadFile(IFormFile file)
        {
            return service.UploadFile(file).GetAwaiter().GetResult();
        }
    }
}
