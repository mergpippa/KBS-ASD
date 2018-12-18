using System;
using KBS.MessageBus.Configurator;
using KBS.MessageBus.Data;
using MassTransit;

namespace KBS.MessageBus.Transports
{
    internal class RabbitMqTransport : ITransport
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
                    new Uri(Environment.GetEnvironmentVariable(EnvironmentVariable.RabbitMqHost)),
                    host =>
                    {
                        host.Username(Environment.GetEnvironmentVariable(EnvironmentVariable.RabbitMqUsername));
                        host.Password(Environment.GetEnvironmentVariable(EnvironmentVariable.RabbitMqPassword));
                    }
                );

                // Configure endpoints for specific test case
                messageBusEndpointConfigurator.ConfigureEndpoints(busFactoryConfigurator);
            });
        }
    }
}
