using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using KBS.Configuration;
using KBS.Storage;
using Newtonsoft.Json;

namespace KBS.Telemetry.Clients
{
    public class InMemoryTelemetryClient : ITelemetryClient
    {
        /// <summary>
        /// Used to store all events. Events are tracked asynchronously on multiple threads, this
        /// means that we have to use the ConcurrentBag type
        /// </summary>
        private readonly ConcurrentBag<object> _events = new ConcurrentBag<object>();

        /// <summary>
        /// Saves tracking data to a file or in the azure storage container
        /// </summary>
        public async Task Flush()
        {
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

            var storageClient = StorageClientFactory.Create(ControllerConfiguration.StorageClientType);

            await storageClient.WriteText(
                JsonConvert.SerializeObject(data),
                $"{BenchmarkConfiguration.Name}.json"
            );
        }

        /// <summary>
        /// Saves event to _events bag
        /// </summary>
        /// <param name="eventName">
        /// </param>
        /// <param name="properties">
        /// </param>
        public void TrackEvent(string eventName, Dictionary<string, string> properties)
        {
            var newEvent = new { eventName, properties };

            _events.Add(newEvent);
        }
    }
}
