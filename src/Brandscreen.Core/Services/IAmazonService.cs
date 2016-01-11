using System.Collections.Specialized;
using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Brandscreen.Core.Settings;
using Brandscreen.Framework;
using Brandscreen.Framework.Services;
using Castle.Core.Logging;

namespace Brandscreen.Core.Services
{
    public interface IAmazonService : IDependency
    {
        Task<PutObjectResponse> PutObject(byte[] obj, string bucketName, string key, string contentType, NameValueCollection headers);
    }

    public class AmazonService : IAmazonService
    {
        private readonly IAmazonSettings _amazonSettings;
        private readonly IClock _clock;

        private static readonly AmazonS3Config S3Config = new AmazonS3Config
        {
            ServiceURL = "s3.amazonaws.com",
            RegionEndpoint = RegionEndpoint.USEast1
        };

        public AmazonService(IAmazonSettings amazonSettings, IClock clock)
        {
            _amazonSettings = amazonSettings;
            _clock = clock;

            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        private IAmazonS3 CreateAmazonS3Client()
        {
            return new AmazonS3Client(_amazonSettings.AccessKey, _amazonSettings.SecretKey, S3Config);
        }

        public async Task<PutObjectResponse> PutObject(byte[] obj, string bucketName, string key, string contentType, NameValueCollection headers)
        {
            using (var client = CreateAmazonS3Client())
            using (var ms = new MemoryStream(obj))
            {
                var request = new PutObjectRequest
                {
                    CannedACL = S3CannedACL.PublicRead,
                    BucketName = bucketName,
                    Key = key,
                    ContentType = contentType,
                    InputStream = ms
                };

                // headers
                if (headers == null)
                {
                    headers = new NameValueCollection // default headers
                    {
                        ["Cache-Control"] = "max-age=94608000",
                        ["Expires"] = _clock.UtcNow.AddYears(3).ToString("r"),
                    };
                }
                foreach (string headerKey in headers)
                {
                    request.Headers[headerKey] = headers[headerKey];
                }

                Logger.InfoFormat("put object is starting in bucket {0} for {1} with size {2}", bucketName, key, obj.Length);
                var response = await client.PutObjectAsync(request);
                Logger.InfoFormat("put object completed in bucket {0} for {1} with etag {2}", bucketName, key, response.ETag);
                return response;
            }
        }
    }
}