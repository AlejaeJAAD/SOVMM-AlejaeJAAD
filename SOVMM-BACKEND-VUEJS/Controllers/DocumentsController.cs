using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Hosting;
using sovmm_backend.Models;

namespace sovmm.Controllers
{
   //// [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DocumentsController : ControllerBase
    {
        
        private static readonly RegionEndpoint BucketRegion = RegionEndpoint.USEast2;
        private static string _bucketName;
        public static string AccessKey;
        public static string AwsSecret;

        public DocumentsController(IConnSettings connSettings)
        {
            _bucketName = connSettings.AwsBucket;
            AccessKey = connSettings.AwsAccessKeyId;
            AwsSecret = connSettings.AwsSecret;

        }
        [HttpPost()]
        public ActionResult<string> Create([FromForm] IFormCollection documents)
        {
            var docs = new List<string>();
            foreach (var document in documents.Files)
            {
                var filename = $"{Guid.NewGuid().ToString()}{Path.GetExtension(document.FileName)}";
                UploadFileAsync(document,filename).Wait();
                docs.Add($"https://sovmm-bucket-01.s3.us-east-2.amazonaws.com/documents/{filename}");
            }

            if (docs.Count == 0)
            {
                return Ok(new {error = ""});
            }
            return Ok(new {msg="Carga completada!",docs});
        }

        private static async Task UploadFileAsync(IFormFile file,string name)
        {
            
            try
            {
                using (var client = new AmazonS3Client(AccessKey,AwsSecret,BucketRegion))
                {
                    using (var newMemoryStream = new MemoryStream())
                    {
                        file.CopyTo(newMemoryStream);

                        var uploadRequest = new TransferUtilityUploadRequest
                        {
                            InputStream = newMemoryStream,
                            Key = $"documents/{name}",
                            BucketName = _bucketName,
                            CannedACL = S3CannedACL.PublicRead
                        };

                        var fileTransferUtility = new TransferUtility(client);
                        await fileTransferUtility.UploadAsync(uploadRequest);
                    }
                }
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }

        }
    }
}
