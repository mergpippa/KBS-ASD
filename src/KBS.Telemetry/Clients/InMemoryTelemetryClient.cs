using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using KBS.Configuration;
using KBS.Data.Enum;
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
        private readonly Dictionary<TelemetryEventType, ConcurrentBag<object>> _events =
            new Dictionary<TelemetryEventType, ConcurrentBag<object>>
            {
                { TelemetryEventType.PrePublish, new ConcurrentBag<object>() },
                { TelemetryEventType.PostPublish, new ConcurrentBag<object>() },
                { TelemetryEventType.PublishFault, new ConcurrentBag<object>() },
                { TelemetryEventType.PreReceive, new ConcurrentBag<object>() },
                { TelemetryEventType.PostConsume, new ConcurrentBag<object>() },
                { TelemetryEventType.PostReceive, new ConcurrentBag<object>() },
                { TelemetryEventType.ReceiveFault, new ConcurrentBag<object>() },
                { TelemetryEventType.ConsumeFault, new ConcurrentBag<object>() }
            };

        /// <summary>
        /// Saves tracking data to a file or in the azure storage container
        /// </summary>
        public async Task Flush()
        {
            var storageClient = StorageClientFactory.Create(ControllerConfiguration.StorageClientType);

            await storageClient.WriteText(
                JsonConvert.SerializeObject(_events),
                $"{BenchmarkConfiguration.Name}.json"
            );
        }

        /// <summary>
        /// Saves event to _events bag
        /// </summary>
        /// <param name="telemetryEventType">
        /// </param>
        /// <param name="value">
        /// </param>
        public void TrackEvent(TelemetryEventType telemetryEventType, object value)
        {
            var eventBag = _events.GetValueOrDefault(telemetryEventType);

            eventBag.Add(value);
        }
    }
}
