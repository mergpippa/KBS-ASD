using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KBS.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace KBS.Controller.Controllers
{
    [Route("api/results")]
    [Produces("application/json")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        // GET api/test
        [HttpGet]
        [ProducesResponseType(302)]
        public async Task<List<string>> GetAll()
        {
            var account = CloudStorageAccount.Parse(ControllerConfiguration.StorageAccountConnectionString);
            var serviceClient = account.CreateCloudBlobClient();

            var blobContainer = serviceClient.GetContainerReference(ControllerConfiguration.StorageAccountContainerName);

            var results = new List<string>();
            BlobContinuationToken continuationToken = null;

            do
            {
                var response = await blobContainer.ListBlobsSegmentedAsync(continuationToken);
                continuationToken = response.ContinuationToken;

                var blobNames = response.Results
                    .OfType<CloudBlockBlob>()
                    .Select(b => b.Name)
                    .ToList();

                results.AddRange(blobNames);
            }
            while (continuationToken != null);

            return results;
        }

        [HttpGet]
        [Route("{fileName}")]
        [ProducesResponseType(200)]
        public RedirectResult Get(string fileName)
        {
            /*if (fileName == string.Empty)
            {
                throw new NullReferenceException("fileName");
            }*/

            return new RedirectResult(
                $"https://{ControllerConfiguration.StorageAccountName}.blob.core.windows.net/{ControllerConfiguration.StorageAccountContainerName}/{fileName}"
            );
        }
    }
}
