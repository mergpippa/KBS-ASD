using System;
using KBS.Data.Enum;
using KBS.MessageBus.Transports;
using MassTransit;

namespace KBS.MessageBus
{
    /// <summary>
    /// Factory to create bus controller
    /// </summary>
    public static class TransportFactory
    {
        /// <summary>
        /// Create the bus controller of a specified transport type with the given configurator
        /// </summary>
        /// <param name="transportType">
        /// Transport type (RabbitMQ, Azure Service Bus or in memory)
        /// </param>
        /// <param name="busFactoryConfigurator">
        /// </param>
        public static IBusControl Create(TransportType transportType, Action<IBusFactoryConfigurator> busFactoryConfigurator)
        {
            switch (transportType)
            {
                case TransportType.InMemory:
                    return new InMemoryTransport().GetBusControl(busFactoryConfigurator);

                case TransportType.RabbitMq:
                    return new RabbitMqTransport().GetBusControl(busFactoryConfigurator);

                case TransportType.AzureServiceBus:
                    return new AzureServiceBusTransport().GetBusControl(busFactoryConfigurator);

                default:
                    throw new ArgumentOutOfRangeException(nameof(transportType), transportType, null);
            }
        }
    }
}
