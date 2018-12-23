using System;
using System.Threading.Tasks;
using KBS.MessageBus.Configurator;
using KBS.MessageBus.Data;
using MassTransit;

namespace KBS.MessageBus
{
    public class BusControl : IDisposable
    {
        public readonly IBusControl Instance;

        /// <summary>
        /// Creates a new bus control with given test case
        /// </summary>
        /// <param name="testCaseConfigurator">
        /// </param>
        public BusControl(IMessageBusEndpointConfigurator testCaseConfigurator)
        {
            // Get transport type from environment
            var transportType = (TransportType)Convert.ToInt32(
                Environment.GetEnvironmentVariable(EnvironmentVariable.TransportType)
            );

            Instance = MessageBusTransportFactory.Create(
                transportType, 
                new MessageBusConfigurator(testCaseConfigurator)
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
//            TelemetryClient.TrackEvent(
//                "bus_published",
//                new Dictionary<string, string>
//                {
//                    { "startedAt", DateTime.Now }
//                }
//            );

            return task;
        }

        /// <inheritdoc />
        /// <summary>
        /// Stops bus control when this class is being disposed
        /// </summary>
        public void Dispose()
        {
            Instance.Stop();
        }
    }
}
