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
        public IBusControl GetBusControl(MessageBusConfigurator messageBusConfigurator)
        {
            return Bus.Factory.CreateUsingInMemory(messageBusConfigurator.ApplyConfiguration);
        }
    }
}
