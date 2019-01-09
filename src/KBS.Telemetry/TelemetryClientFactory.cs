using System;
using KBS.Data.Enum;
using KBS.Telemetry.Clients;

namespace KBS.Telemetry
{
    public static class TelemetryClientFactory
    {
        public static ITelemetryClient Create(TelemetryClientType telemetryClientType)
        {
            switch (telemetryClientType)
            {
                case TelemetryClientType.InMemory:
                    return new InMemoryTelemetryClient();

                case TelemetryClientType.ApplicationInsights:
                    return new ApplicationInsightsTelemetryClient();

                default:
                    throw new ArgumentOutOfRangeException(nameof(telemetryClientType), telemetryClientType, null);
            }
        }
    }
}
