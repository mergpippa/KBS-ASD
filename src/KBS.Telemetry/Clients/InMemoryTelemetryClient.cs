using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using KBS.Configuration;
using Microsoft.WindowsAzure.Storage;
using Newtonsoft.Json;

namespace KBS.Telemetry.Clients
{
    public class InMemoryTelemetryClient : ITelemetryClient
    {
        /// <summary>
        /// </summary>
        private readonly ConcurrentBag<object> _events = new ConcurrentBag<object>();

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public async Task Flush()
        {
            await Task.Yield();

            var data = new
            {
                configuration = new
                {
                    name = BenchmarkConfiguration.Name,
                    messagesCount = BenchmarkConfiguration.MessageCount,
                    fillerSize = BenchmarkConfiguration.FillerSize,
                    clientsCount = BenchmarkConfiguration.ClientCount,
                    testCaseType = TestCaseConfiguration.TestCaseType,
                    transportType = TestCaseConfiguration.TransportType,
                    useExpress = TransportConfiguration.UseExpress,
                },
                events = _events
            };

            var jsonString = JsonConvert.SerializeObject(data);

            if (ControllerConfiguration.StorageAccountConnectionString != null)
            {
                await UploadToStorageAccount(jsonString);

                // No need to save to file because the results are saved in storage account
                return;
            }

            // Save output to text file if StorageConnectionString is not defined
            File.WriteAllText($"./{BenchmarkConfiguration.Name}.json", jsonString);
        }

        /// <summary>
        /// </summary>
        /// <param name="eventName">
        /// </param>
        /// <param name="properties">
        /// </param>
        public async void TrackEvent(string eventName, Dictionary<string, string> properties)
        {
            await Task.Yield();

            var newEvent = new { eventName, properties };

            _events.Add(newEvent);
        }

        /// <summary>
        /// Upload given jsonString to new file on storage container
        /// </summary>
        /// <param name="jsonString">
        /// </param>
        /// <returns>
        /// </returns>
        private async Task UploadToStorageAccount(string jsonString)
        {
            var account = CloudStorageAccount.Parse(ControllerConfiguration.StorageAccountConnectionString);
            var serviceClient = account.CreateCloudBlobClient();

            // Create container. Name must be lower case.
            Console.WriteLine("Creating container...");
            var blobContainer = serviceClient.GetContainerReference("benchmarkresults");

            //
            await blobContainer.CreateIfNotExistsAsync();

            // This also does not make a service call, it only creates a local object.
            var blob = blobContainer.GetBlockBlobReference($"{BenchmarkConfiguration.Name}.json");

            // This transfers data in the file to the blob on the service.
            await blob.UploadTextAsync(jsonString);
        }
    }
}
