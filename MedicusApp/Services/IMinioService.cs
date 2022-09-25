namespace MedicusApp.Services
{
    public interface IMinioService
    {
        public IEnumerable<string>GetFiles();
        public Task<string> UploadFile(IFormFile file);
    }
}
