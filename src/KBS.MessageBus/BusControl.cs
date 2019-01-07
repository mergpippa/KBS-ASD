using System;
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
        /// Stops bus control when this class is being disposed
        /// </summary>
        public void Dispose()
        {
            Instance.Stop();
        }
    }
}
