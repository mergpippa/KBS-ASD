using System;
using KBS.MessageBus.Configurator;
using KBS.MessageBus.Transports;
using MassTransit;

namespace KBS.MessageBus
{
    public enum TransportType
    {
        InMemory = 0,

        RabbitMq = 1,

        AzureServiceBus = 2,
    }

    /// <summary>
    /// Factory to create bus controler
    /// </summary>
    public static class MessageBusTransportFactory
    {
        /// <summary>
        /// Create the bus controler of a specified transport type with the given configurator
        /// </summary>
        /// <param name="transportType">Transport type (RabbitMQ, Azure Service Bus or in memory)</param>
        /// <param name="testCase">Configuration of test case</param>
        /// <returns></returns>
        public static IBusControl Create(TransportType transportType, IMessageBusEndpointConfigurator testCase)
        {
            switch (transportType)
            {
                case TransportType.InMemory:
                    return new InMemoryTransport().GetBusControl(testCase);

                case TransportType.RabbitMq:
                    return new RabbitMqTransport().GetBusControl(testCase);

                case TransportType.AzureServiceBus:
                    return new AzureServiceBusTransport().GetBusControl(testCase);

                default:
                    throw new ArgumentOutOfRangeException(nameof(transportType), transportType, null);
            }
        }
    }
}
