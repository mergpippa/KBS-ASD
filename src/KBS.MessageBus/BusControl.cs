using System;
using System.Threading.Tasks;
using KBS.MessageBus.Configuration;
using KBS.MessageBus.Data;
using KBS.MessageBus.Transports;
using MassTransit;

namespace KBS.MessageBus
{
    public class BusControl
    {
        private static IBusControl _busControl;

        public BusControl(MessageBusConfigurator messageBusConfigurator)
        {
            var transportType = (TransportType)Convert.ToInt32(
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
                    throw new InvalidEnvironmentVariableException(EnvironmentVariable.TransportType);
            }

            _busControl.Start();
        }

        public void Stop()
        {
            _busControl.Stop();
        }

        /// <summary>
        /// Publishes command onto bus control
        /// </summary>
        /// <typeparam name="T">Should be an interface</typeparam>
        /// <param name="message">Must be an anonymous type; expl: "new { Val = 0 }"</param>
        /// <returns></returns>
        public Task Publish<T>(object message) where T : class => _busControl.Publish<T>(message);
    }

    internal class InvalidEnvironmentVariableException : Exception
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
