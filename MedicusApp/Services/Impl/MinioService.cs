using MedicusApp.Config;
using Minio;
using Minio.DataModel;
using Minio.Exceptions;
using System.Reactive.Linq;
using System.Text.Json;

namespace MedicusApp.Services.Impl
{
    public class MinioService : IMinioService
    {
        private MinioClient minio;
        private const string Medicus = "medicus";

        public MinioService(IConfiguration configuration)
        {
            var config = configuration.GetSection("Minio").Get<MinioConfiguration>();
            MinioClient builder = new MinioClient()
                .WithEndpoint(config.Url)
                .WithCredentials(config.AccessKey, config.SecretKey);  
            
            if(config.Ssl)
            {
                builder.WithSSL();
            }

            minio = builder.Build();

            MakeBucketIfDoesntExist();
            VerifyBucketSettings();
        }

        public IEnumerable<string> GetFiles()
        {
            try
            {
                var args = new ListObjectsArgs();
                args.WithBucket(Medicus);
                IObservable<Item> observable = minio.ListObjectsAsync(args);
                List<string> items = new List<string>();
                observable.Subscribe(item => items.Add(item.Key));
                observable.Wait();
                return items.Select(i => "medicus/" + i);
            } catch (Exception)
            {
                return new List<string>();
            }
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            try
            {
                using (var stream = file.OpenReadStream())
                {
                    var args = new PutObjectArgs();

                    args.WithBucket(Medicus)
                        .WithObject(Path.GetFileName(file.FileName))
                        .WithObjectSize(file.Length)
                        .WithContentType(file.ContentType)
                        .WithStreamData(stream);

                    await minio.PutObjectAsync(args);
                    return "medicus/" + file.FileName;
                }
            }
            catch (Exception)
            {
                return "false";
            }
        }

        private async void MakeBucketIfDoesntExist()
        {
            var args = new BucketExistsArgs();
            args.WithBucket(Medicus);
            var exists = await minio.BucketExistsAsync(args);
            if(!exists)
            {
                var bucket = new MakeBucketArgs();
                bucket.WithBucket(Medicus);
                await minio.MakeBucketAsync(bucket);
            }
        }

        private async void VerifyBucketSettings()
        {
            var args = new GetVersioningArgs();
            args.WithBucket(Medicus);
            var vc = await minio.GetVersioningAsync(args);
            if(vc.Status == "Off")
            {
                var setArgs = new SetVersioningArgs();
                setArgs.WithBucket(Medicus)
                    .WithVersioningEnabled();
                await minio.SetVersioningAsync(setArgs);
            }

            var policyArgs = new GetPolicyArgs();
            policyArgs.WithBucket(Medicus);
            try
            {
                await minio.GetPolicyAsync(policyArgs);
            } catch (UnexpectedMinioException)
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
                            Resource = Medicus,
                            Sid = "Public",
                            Principal = new Dictionary<string, List<string>>() { { "AWS", new List<string>() { "*" } } }
                        }
                    }
                };

                var setPolictyArgs = new SetPolicyArgs();
                setPolictyArgs.WithBucket(Medicus).WithPolicy(JsonSerializer.Serialize(policy));
                await minio.SetPolicyAsync(setPolictyArgs);
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
