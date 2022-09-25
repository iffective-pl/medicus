namespace MedicusApp.Config
{
    public class MinioConfiguration
    {
        public string Url { get; set; }
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public bool Ssl { get; set; }
    }
}