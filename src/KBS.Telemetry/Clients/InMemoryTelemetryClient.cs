using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using KBS.Configuration;
using Newtonsoft.Json;

namespace KBS.Telemetry.Clients
{
    public class InMemoryTelemetryClient : ITelemetryClient
    {
        private readonly ConcurrentBag<object> _events = new ConcurrentBag<object>();

        public async Task Flush()
        {
            await Task.Yield();

            var data = new
            {
                configuration = new
                {
                    messagesCount = BenchmarkConfiguration.MessageCount,
                    fillerSize = BenchmarkConfiguration.FillerSize,
                    clientsCount = BenchmarkConfiguration.ClientCount,
                    testCaseType = TestCaseConfiguration.TestCaseType,
                    transportType = TestCaseConfiguration.TransportType,
                    useExpress = TransportConfiguration.UseExpress,
                },
                events = _events
            };

            // Save output to text file
            File.WriteAllText("./results.json", JsonConvert.SerializeObject(data));
        }

        public async void TrackEvent(string eventName, Dictionary<string, string> properties)
        {
            await Task.Yield();

            var newEvent = new { eventName, properties };

            _events.Add(newEvent);
        }
    }
}
