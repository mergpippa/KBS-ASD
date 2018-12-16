using KBS.MessageBus.Configurator;
using MassTransit;

namespace KBS.MessageBus.Transports
{
    internal class InMemoryTransport : ITransport
    {
        /// <summary>
        /// Creates a MassTransit instance using the InMemory transport
        /// </summary>
        /// <param name="messageBusConfigurator">
        /// </param>
        /// <returns>
        /// </returns>
        public IBusControl GetBusControl(IMessageBusEndpointConfigurator endpointConfigurator)
        {
            return Bus.Factory.CreateUsingInMemory(busFactoryConfigurator =>
            {
                // Configure endpoints for specific test case
                endpointConfigurator.ConfigureEndpoints(busFactoryConfigurator);
            });
        }
    }
}
