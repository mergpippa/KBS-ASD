using KBS.MessageBus.Configuration;
using KBS.MessageBus.Data;
using KBS.MessageBus.Transports;
using MassTransit;
using System;

namespace KBS.MessageBus
{
    public class MessageBus
    {
        private static IBusControl _busControl;

        public MessageBus(MessageBusConfigurator messageBusConfigurator)
        {
            var transportType = (TransportType) Convert.ToInt32(
                Environment.GetEnvironmentVariable(EnvironmentVariable.TransportType)
            );

            switch (transportType)
            {
                case TransportType.InMemory:
                    _busControl = new InMemoryTransport().GetInstance(messageBusConfigurator);
                    break;

                case TransportType.RabbitMQ:
                    _busControl = new RabbitMQTransport().GetInstance(messageBusConfigurator);
                    break;

                case TransportType.AzureServiceBus:
                    _busControl = new AzureServiceBusTransport().GetInstance(messageBusConfigurator);
                    break;

                default:
                    throw new InvalidEnvironmentVariableException("TRANSPORT_TYPE");
            }
        }
    }

    class InvalidEnvironmentVariableException : Exception
    {
        public InvalidEnvironmentVariableException(string environmentVariableName) : 
            base($"Environment variable `{environmentVariableName}` invalid or missing")
        { }

        public InvalidEnvironmentVariableException() : base()
        { }

        public InvalidEnvironmentVariableException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
