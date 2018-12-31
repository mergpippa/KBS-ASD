using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KBS.Data.Constants;
using KBS.Data.Enum;
using KBS.Telemetry;
using MassTransit;

namespace KBS.MessageBus
{
    public class BusControl : IDisposable
    {
        public readonly IBusControl Instance;

        private readonly ITelemetryClient _telemetryClient;

        /// <summary>
        /// Creates a new bus control with given test case
        /// </summary>
        /// <param name="testCaseConfigurator">
        /// </param>
        /// <param name="telemetryClient">
        /// </param>
        public BusControl(
            Action<IBusFactoryConfigurator> busFactoryConfigurator,
            ITelemetryClient telemetryClient
        )
        {
            _telemetryClient = telemetryClient;

            // Get transport type from environment
            var transportType = (TransportType)Convert.ToInt32(
                Environment.GetEnvironmentVariable(EnvironmentVariables.TransportType)
            );

            Instance = TransportFactory.Create(
                transportType,
                busFactoryConfigurator
            );

            // Starts bus (The bus must be started before sending any messages!)
            Instance.Start();
        }

        /// <summary>
        /// Publishes command onto bus control
        /// </summary>
        /// <typeparam name="T">
        /// Should be an interface
        /// </typeparam>
        /// <param name="message">
        /// Must be an anonymous type; explanation: "new { Val = 0 }"
        /// </param>
        /// <returns>
        /// </returns>
        public Task Publish<T>(object message) where T : class
        {
            var task = Instance.Publish<T>(message);

            // Track message publish
            _telemetryClient.TrackEvent(
                TelemetryEventNames.MessageSent,
                new Dictionary<string, string>
                {
                    {TelemetryEventPropertyNames.SentAt, DateTime.Now.ToString()}
                }
            );

            return task;
        }

        /// <summary>
        /// Stops bus control when this class is being disposed
        /// </summary>
        public void Dispose()
        {
            Instance.Stop();
        }
    }
}
