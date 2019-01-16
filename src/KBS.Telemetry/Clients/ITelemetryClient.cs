using System;
using System.Threading.Tasks;
using KBS.Data.Enum;

namespace KBS.Telemetry.Clients
{
    public interface ITelemetryClient
    {
        Task Flush();

        void TrackEvent(TelemetryEventType telemetryEventType, Guid messageId, object value);
    }
}
