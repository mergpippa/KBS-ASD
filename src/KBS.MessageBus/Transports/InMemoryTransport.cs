using KBS.MessageBus.Configurator;
using MassTransit;

namespace KBS.MessageBus.Transports
{
    internal class InMemoryTransport : ITransport
    {
        /// <summary>
        /// Creates a MassTransit instance using the InMemory transport
        /// </summary>
        /// <param name="messageBusEndpointConfigurator">
        /// </param>
        /// <returns>
        /// </returns>
        public IBusControl GetBusControl(IMessageBusEndpointConfigurator messageBusEndpointConfigurator)
        {
            return Bus.Factory.CreateUsingInMemory(messageBusEndpointConfigurator.ConfigureEndpoints);
        }
    }
}
