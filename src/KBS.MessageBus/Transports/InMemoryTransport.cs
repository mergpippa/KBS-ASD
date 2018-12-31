using System;
using MassTransit;

namespace KBS.MessageBus.Transports
{
    internal class InMemoryTransport : ITransport
    {
        /// <summary>
        /// Creates a MassTransit instance using the InMemory transport
        /// </summary>
        /// <param name="baseBusFactoryConfigurator">
        /// </param>
        /// <returns>
        /// </returns>
        public IBusControl GetBusControl(Action<IBusFactoryConfigurator> baseBusFactoryConfigurator)
        {
            return Bus.Factory.CreateUsingInMemory(baseBusFactoryConfigurator);
        }
    }
}
