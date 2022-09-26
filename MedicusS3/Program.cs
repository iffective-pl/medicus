using Microsoft.AspNetCore.StaticFiles;
using Minio;
using Minio.Exceptions;
using Serilog;
using Serilog.Core;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace MedicusS3
{
    public class Program
    {
        private readonly Logger logger;
        private readonly MinioClient minio;
        private readonly FileExtensionContentTypeProvider contentType;
        private static readonly string MedicusStatic = "medicus-static";

        static void Main()
        {
            _ = new Program();
        }

        public Program()
        {
            try
            {
                logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
                logger.Information("S3 Migration starting");
                contentType = new FileExtensionContentTypeProvider();
                using var stream = File.OpenRead("appsettings.json");
                var config = JsonSerializer.Deserialize<Config>(stream).Minio;
                MinioClient builder = new MinioClient()
                            .WithEndpoint(config.Url)
                            .WithCredentials(config.AccessKey, config.SecretKey);

                if (config.Ssl)
                {
                    builder.WithSSL();
                }

                minio = builder.Build();
                MakeBucketIfDoesntExist().GetAwaiter().GetResult();
                VerifyBucketSettings().GetAwaiter().GetResult();

                var images = Directory.GetFiles("images");
                foreach (var image in images)
                {
                    contentType.TryGetContentType(image, out string type);
                    var s = File.OpenRead(image);
                    UploadFile(image, type, s).GetAwaiter().GetResult();
                }
                logger.Information("S3 Migration finished");
            } catch (Exception e)
            {
                logger.Error(e, "Exception occured: {e}");
            }
        }

        public async Task UploadFile(string name, string type, FileStream file)
        {
            var args = new PutObjectArgs();
            var obj = Path.GetFileName(name);
            args.WithBucket(MedicusStatic)
                .WithObject(obj)
                .WithObjectSize(file.Length)
                .WithContentType(type)
                .WithStreamData(file);

            await minio.PutObjectAsync(args);
            logger.Information("Uploaded file {name}", obj);
        }

        private async Task MakeBucketIfDoesntExist()
        {
            var args = new BucketExistsArgs();
            args.WithBucket(MedicusStatic);
            logger.Information("Verifying if bucket {bucket} exists", MedicusStatic);
            var exists = await minio.BucketExistsAsync(args);
            if (!exists)
            {
                var bucket = new MakeBucketArgs();
                bucket.WithBucket(MedicusStatic);
                logger.Information("Bucket {bucket} does not exists. Creating a new one", MedicusStatic);
                await minio.MakeBucketAsync(bucket);
                logger.Information("Bucket {bucket} has been created", MedicusStatic);
            }
        }


        private async Task VerifyBucketSettings()
        {
            logger.Information("Verifying if bucket {bucket} has correct policies", MedicusStatic);
            var args = new GetVersioningArgs();
            args.WithBucket(MedicusStatic);
            var vc = await minio.GetVersioningAsync(args);
            if (vc.Status == "Off")
            {
                var setArgs = new SetVersioningArgs();
                setArgs.WithBucket(MedicusStatic)
                    .WithVersioningEnabled();
                await minio.SetVersioningAsync(setArgs);
            }

            var policyArgs = new GetPolicyArgs();
            policyArgs.WithBucket(MedicusStatic);
            try
            {
                await minio.GetPolicyAsync(policyArgs);
            }
            catch (UnexpectedMinioException)
            {
                var policy = new MinioPolicy()
                {
                    Version = "2012-10-17",
                    Statement = new List<MinioStatement>()
                    {
                        new MinioStatement()
                        {
                            Effect = "Allow",
                            Action = new List<string>()
                            {
                                "s3:GetObject"
                            },
                            Resource = MedicusStatic,
                            Sid = "Public",
                            Principal = new Dictionary<string, List<string>>() { { "AWS", new List<string>() { "*" } } }
                        }
                    }
                };

                var setPolictyArgs = new SetPolicyArgs();
                setPolictyArgs.WithBucket(MedicusStatic).WithPolicy(JsonSerializer.Serialize(policy));
                logger.Information("Applying new policies", MedicusStatic);
                await minio.SetPolicyAsync(setPolictyArgs);
                logger.Information("New policies has been applied", MedicusStatic);
            }
        }

        private class MinioPolicy
        {
            public string Version { get; set; }
            public List<MinioStatement> Statement { get; set; }
        }

        private class MinioStatement
        {
            private string resource;
            public List<string> Action { get; set; }
            public string Effect { get; set; }
            public string Resource
            {
                get { return resource; }
                set { resource = "arn:aws:s3:::" + value + "/*"; }
            }
            public string Sid { get; set; }
            public Dictionary<string, List<string>> Principal { get; set; }
        }
    }
}
