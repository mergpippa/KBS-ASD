using System;
using KBS.MessageBus.Configurator;
using KBS.MessageBus.Data;
using MassTransit;

namespace KBS.MessageBus.Transports
{
    internal class RabbitMQTransport : ITransport
    {
        /// <summary>
        /// Creates a MassTransit instance using the RabbitMQ transport
        /// </summary>
        /// <param name="messageBusEndpointConfigurator">
        /// </param>
        /// <returns>
        /// </returns>
        public IBusControl GetBusControl(IMessageBusEndpointConfigurator messageBusEndpointConfigurator)
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

                // Configure endpoints for specific test case
                messageBusEndpointConfigurator.ConfigureEndpoints(busFactoryConfigurator);
            });
        }
    }
}
