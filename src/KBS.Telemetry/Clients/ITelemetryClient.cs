using System.Collections.Generic;
using System.Threading.Tasks;

namespace KBS.Telemetry.Clients
{
    public interface ITelemetryClient
    {
        Task Flush();

        void TrackEvent(string eventName, Dictionary<string, string> properties);
    }
}
