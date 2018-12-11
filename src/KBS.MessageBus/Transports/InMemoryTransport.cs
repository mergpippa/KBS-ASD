using System;
using KBS.MessageBus.Configuration;
using MassTransit;

namespace KBS.MessageBus.Transports
{
    internal class InMemoryTransport : ITransport
    {
        /// <summary>
        /// Creates a MassTransit instance using the InMemory transport
        /// </summary>
        /// <param name="messageBusConfigurator"></param>
        /// <returns></returns>
        public IBusControl GetInstance(MessageBusConfigurator messageBusConfigurator) =>
            Bus.Factory.CreateUsingInMemory(messageBusConfigurator.ApplyConfiguration);
    }
}
