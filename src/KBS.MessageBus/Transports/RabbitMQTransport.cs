using System;
using KBS.Data.Constants;
using MassTransit;

namespace KBS.MessageBus.Transports
{
    internal class RabbitMqTransport : ITransport
    {
        /// <summary>
        /// Creates a MassTransit instance using the RabbitMQ transport
        /// </summary>
        /// <param name="baseBusFactoryConfigurator">
        /// </param>
        /// <returns>
        /// </returns>
        public IBusControl GetBusControl(Action<IBusFactoryConfigurator> baseBusFactoryConfigurator)
        {
            return Bus.Factory.CreateUsingRabbitMq(busFactoryConfigurator =>
            {
                busFactoryConfigurator.Host(
                    new Uri(Environment.GetEnvironmentVariable(EnvironmentVariables.RabbitMqHost)),
                    host =>
                    {
                        host.Username(Environment.GetEnvironmentVariable(EnvironmentVariables.RabbitMqUsername));
                        host.Password(Environment.GetEnvironmentVariable(EnvironmentVariables.RabbitMqPassword));
                    }
                );

                baseBusFactoryConfigurator(busFactoryConfigurator);
            });
        }
    }
}
