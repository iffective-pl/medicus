using MedicusS3;
using Microsoft.AspNetCore.StaticFiles;
using Minio;
using Minio.Exceptions;
using System.Text.Json;

namespace MedicusS3
{
    public class Program
    {
        private MinioClient minio;
        private FileExtensionContentTypeProvider contentType;
        private static string MedicusStatic = "medicus-static";

        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            contentType = new FileExtensionContentTypeProvider();
            using (var stream = File.OpenRead("appsettings.json"))
            {
                var config = JsonSerializer.Deserialize<Config>(stream).MinioConfiguration;
                MinioClient builder = new MinioClient()
                            .WithEndpoint(config.Url)
                            .WithCredentials(config.AccessKey, config.SecretKey);

                if (config.Ssl)
                {
                    builder.WithSSL();
                }

                var minio = builder.Build();
                MakeBucketIfDoesntExist();
                VerifyBucketSettings();

                var images = Directory.GetFiles("images");
                foreach (var image in images)
                {
                    string type;
                    contentType.TryGetContentType(image, out type);
                    using (var s = File.OpenRead(image))
                    {
                        UploadFile(image, type, s);
                    }
                }
            }
        }

        public async void UploadFile(string name, string type, FileStream file)
        {
            var args = new PutObjectArgs();

            args.WithBucket(MedicusStatic)
                .WithObject(Path.GetFileName(name))
                .WithObjectSize(file.Length)
                .WithContentType(type)
                .WithStreamData(file);

            await minio.PutObjectAsync(args);
        }

        private async void MakeBucketIfDoesntExist()
        {
            var args = new BucketExistsArgs();
            args.WithBucket(MedicusStatic);
            var exists = await minio.BucketExistsAsync(args);
            if (!exists)
            {
                var bucket = new MakeBucketArgs();
                bucket.WithBucket(MedicusStatic);
                await minio.MakeBucketAsync(bucket);
            }
        }


        private async void VerifyBucketSettings()
        {
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
