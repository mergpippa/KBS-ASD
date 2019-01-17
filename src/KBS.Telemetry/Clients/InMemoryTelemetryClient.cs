using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using KBS.Configuration;
using KBS.Data.Enum;
using KBS.Data.Model;
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
        private readonly Dictionary<TelemetryEventType, ConcurrentDictionary<Guid, object>> _events =
            new Dictionary<TelemetryEventType, ConcurrentDictionary<Guid, object>>
            {
                { TelemetryEventType.PrePublish, new ConcurrentDictionary<Guid, object>() },
                { TelemetryEventType.PostPublish, new ConcurrentDictionary<Guid, object>() },
                { TelemetryEventType.PublishFault, new ConcurrentDictionary<Guid, object>() },
                { TelemetryEventType.PreReceive, new ConcurrentDictionary<Guid, object>() },
                { TelemetryEventType.PreConsume, new ConcurrentDictionary<Guid, object>() },
                { TelemetryEventType.PostConsume, new ConcurrentDictionary<Guid, object>() },
                { TelemetryEventType.PostReceive, new ConcurrentDictionary<Guid, object>() },
                { TelemetryEventType.ReceiveFault, new ConcurrentDictionary<Guid, object>() },
                { TelemetryEventType.ConsumeFault, new ConcurrentDictionary<Guid, object>() },
                { TelemetryEventType.PreSend, new ConcurrentDictionary<Guid, object>() },
                { TelemetryEventType.PostSend, new ConcurrentDictionary<Guid, object>() },
                { TelemetryEventType.SendFault, new ConcurrentDictionary<Guid, object>() },
            };

        /// <summary>
        /// Saves tracking data to a file or in the azure storage container
        /// </summary>
        public async Task Flush()
        {
            var storageClient = StorageClientFactory.Create(ControllerConfiguration.StorageClientType);

            await storageClient.WriteText(
                JsonConvert.SerializeObject(new
                {
                    configuration = new SimpleBenchmarkConfiguration
                    {
                        TestCaseType = TestCaseConfiguration.TestCaseType,
                        TransportType = TestCaseConfiguration.TransportType,
                        MessageCount = BenchmarkConfiguration.MessageCount,
                        FillerSize = BenchmarkConfiguration.FillerSize,
                        ClientCount = BenchmarkConfiguration.ClientCount,
                        Timeout = BenchmarkConfiguration.Timeout,
                        AzureServiceBusOperationTimeout = TransportConfiguration.AzureServiceBusOperationTimeout,
                        UseExpress = TransportConfiguration.UseExpress,
                    },
                    events = _events,
                }),
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
        public void TrackEvent(TelemetryEventType telemetryEventType, Guid messageId, object value)
        {
            var eventBag = _events.GetValueOrDefault(telemetryEventType);

            eventBag.TryAdd(messageId, value);
        }
    }
}
