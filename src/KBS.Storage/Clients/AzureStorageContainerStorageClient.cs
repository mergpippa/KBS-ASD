using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KBS.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace KBS.Storage.Clients
{
    public class AzureStorageContainerStorageClient : IStorageClient
    {
        private readonly CloudBlobClient _cloudBlobClient;

        public AzureStorageContainerStorageClient()
        {
            var account = CloudStorageAccount.Parse(ControllerConfiguration.StorageAccountConnectionString);

            _cloudBlobClient = account.CreateCloudBlobClient();
        }

        /// <summary>
        /// Gets all files from storage container
        /// </summary>
        /// <returns>
        /// </returns>
        public async Task<List<string>> GetAll()
        {
            var blobContainer = _cloudBlobClient.GetContainerReference(ControllerConfiguration.StorageAccountContainerName);

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

        /// <summary>
        /// Creates a new file in the azure storage container with given text
        /// </summary>
        /// <param name="text">
        /// </param>
        /// <param name="fileName">
        /// </param>
        /// <returns>
        /// </returns>
        public async Task WriteText(string text, string fileName)
        {
            var blobContainer = _cloudBlobClient.GetContainerReference(ControllerConfiguration.StorageAccountContainerName);

            await blobContainer.CreateIfNotExistsAsync();

            await blobContainer
                .GetBlockBlobReference(fileName)
                .UploadTextAsync(text);
        }
    }
}
