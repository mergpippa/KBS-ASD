using System;
using KBS.MessageBus.Configuration;
using KBS.MessageBus.Data;
using MassTransit;

namespace KBS.MessageBus.Transports
{
    internal class RabbitMQTransport : ITransport
    {
        /// <summary>
        /// Creates a MassTransit instance using the RabbitMQ transport
        /// </summary>
        /// <param name="messageBusConfigurator"></param>
        /// <returns></returns>
        public IBusControl GetInstance(MessageBusConfigurator messageBusConfigurator)
        {
            return Bus.Factory.CreateUsingRabbitMq(busFactoryConfigurator =>
            {
                busFactoryConfigurator.Host(
                    new Uri(Environment.GetEnvironmentVariable(EnvironmentVariable.RabbitMQHost)),
                    host =>
                    {
                        host.Username(Environment.GetEnvironmentVariable(EnvironmentVariable.RabbitMQUsername));
                        host.Password(Environment.GetEnvironmentVariable(EnvironmentVariable.RabbitMQPassword));
                    }
                );

                messageBusConfigurator.ApplyConfiguration(busFactoryConfigurator);
            });
        }
    }
}
