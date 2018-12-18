using System;
using System.Threading;
using System.Threading.Tasks;
using GreenPipes;
using KBS.MessageBus.Configurator;
using KBS.MessageBus.Data;
using KBS.Topics.RequestResponseCase;
using MassTransit;
using MassTransit.Topology;

namespace KBS.MessageBus
{
    public class BusControl : IDisposable
    {
        private static IBusControl _busControl;

        public Uri Address => _busControl.Address;

        public IBusTopology Topology => _busControl.Topology;

        public IRequestClient<IRequestMessage, IResponseMessage> RequestClient { get; }

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

            RequestClient = _busControl.CreateRequestClient<IRequestMessage, IResponseMessage>(
                Address,
                TimeSpan.FromSeconds(10));

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
