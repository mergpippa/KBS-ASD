using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KBS.Data.Constants;
using Microsoft.ApplicationInsights;

namespace KBS.Telemetry.Clients
{
    public class ApplicationInsightsTelemetryClient : ITelemetryClient
    {
        /// <summary>
        /// Azure Application insights telemetryClient client
        /// </summary>
        private readonly TelemetryClient _telemetryClient = new TelemetryClient();

        public ApplicationInsightsTelemetryClient()
        {
            // Check if app insight instrumentation key is set
            Environment.GetEnvironmentVariable(EnvironmentVariables.AppInsightsInstrumentationKey);
        }

        /// <summary>
        /// Used to flush any data that is still in memory to an external service
        /// </summary>
        /// <returns>
        /// </returns>
        public async Task Flush()
        {
            Console.WriteLine($"Flushing telemetry client");

            _telemetryClient.Flush();

            // Timeout to give the client some time to flush
            await Task.Delay(TimeSpan.FromSeconds(5000)).ConfigureAwait(false);
        }

        /// <summary>
        /// Used to track an event
        /// </summary>
        /// <param name="eventName">
        /// </param>
        /// <param name="properties">
        /// </param>
        public async void TrackEvent(string eventName, Dictionary<string, string> properties)
        {
            // Force this method to be async
            await Task.Yield();

            _telemetryClient.TrackEvent(eventName, properties);
        }
    }
}
