using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KBS.Telemetry
{
    public class InMemoryTelemetryClient : ITelemetryClient
    {
        private readonly ConcurrentBag<object> _events = new ConcurrentBag<object>();

        public async Task Flush()
        {
            var json = JsonConvert.SerializeObject(_events);

            // Save output to text file
            File.WriteAllText("./results.json", $"[{json}]");
        }

        public async void TrackEvent(string eventName, Dictionary<string, string> properties)
        {
            await Task.Yield();

            var newEvent = new { eventName, properties };

            _events.Add(newEvent);
        }
    }
}
