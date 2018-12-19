using KBS.MessageBus.Middleware;
using MassTransit;
using Microsoft.ApplicationInsights;

namespace KBS.MessageBus.Configurator
{
    /// <summary>
    /// Class used to configure the message bus for testing purposes
    /// </summary>
    public class MessageBusConfigurator
    {
        private readonly IMessageBusEndpointConfigurator _messageBusEndpointConfigurator;

        /// <summary>
        /// Constructor with endpoint configurator as the first argument
        /// </summary>
        /// <param name="messageBusEndpointConfigurator">
        /// </param>
        public MessageBusConfigurator(IMessageBusEndpointConfigurator messageBusEndpointConfigurator)
        {
            _messageBusEndpointConfigurator = messageBusEndpointConfigurator;
        }

        /// <summary>
        /// Apply all configurations to bus factory configurator
        /// </summary>
        /// <param name="busFactoryConfigurator">
        /// </param>
        public void ApplyConfiguration(IBusFactoryConfigurator busFactoryConfigurator)
        {
            var telemetryClient = new TelemetryClient();

            // Add middleware
            busFactoryConfigurator.UseMessagePerformanceDiagnostics(telemetryClient);

            // Apply endpoint configuration
            _messageBusEndpointConfigurator.ConfigureEndpoints(busFactoryConfigurator);
        }
    }
}
