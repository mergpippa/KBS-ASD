using System.Collections.Generic;
using System.Threading.Tasks;

namespace KBS.Telemetry
{
    public class FileTelemetryClient : ITelemetryClient
    {
        public Task Flush()
        {
            throw new System.NotImplementedException();
        }

        public void TrackEvent(string eventName, Dictionary<string, string> properties)
        {
            throw new System.NotImplementedException();
        }
    }
}
