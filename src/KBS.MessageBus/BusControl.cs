using System;
using System.Threading.Tasks;
using KBS.MessageBus.Configurator;
using KBS.MessageBus.Data;
using MassTransit;

namespace KBS.MessageBus
{
    public class BusControl : IDisposable
    {
        private static IBusControl _busControl;

        /// <summary>
        /// Creates a new bus control with given test case
        /// </summary>
        /// <param name="testCase">
        /// </param>
        public BusControl(IMessageBusEndpointConfigurator testCase)
        {
            // Get transport type from environment
            var transportType = (TransportType)Convert.ToInt32(
                Environment.GetEnvironmentVariable(EnvironmentVariable.TransportType)
            );

            _busControl = MessageBusTransportFactory.Create(transportType, testCase);

            // Starts bus (The bus must be started before sending any messages!)
            _busControl.Start();
        }

        /// <summary>
        /// Publishes command onto bus control
        /// </summary>
        /// <typeparam name="T">
        /// Should be an interface
        /// </typeparam>
        /// <param name="message">
        /// Must be an anonymous type; expl: "new { Val = 0 }"
        /// </param>
        /// <returns>
        /// </returns>
        public Task Publish<T>(object message) where T : class
        {
            return _busControl.Publish<T>(message);
        }

        /// <summary>
        /// Stops bus control when this class is being disposed
        /// </summary>
        public void Dispose()
        {
            _busControl.Stop();
        }
    }
}
