using KBS.MessageBus.Configurator;
using KBS.MessageBus.Data;
using KBS.MessageBus.Exceptions;
using KBS.MessageBus.Transports;
using MassTransit;

namespace KBS.MessageBus
{
    internal enum TransportType
    {
        InMemory = 0,

        RabbitMQ = 1,

        AzureServiceBus = 2,
    }

    internal static class MessageBusTransportFactory
    {
        public static IBusControl Create(TransportType transportType, IMessageBusEndpointConfigurator testCase)
        {
            switch (transportType)
            {
                case TransportType.InMemory:
                    return new InMemoryTransport().GetBusControl(testCase);

                case TransportType.RabbitMQ:
                    return new RabbitMQTransport().GetBusControl(testCase);

                case TransportType.AzureServiceBus:
                    return new AzureServiceBusTransport().GetBusControl(testCase);

                default:
                    throw new InvalidEnvironmentVariableException(EnvironmentVariable.TransportType);
            }
        }
    }
}
