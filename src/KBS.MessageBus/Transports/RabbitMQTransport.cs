using System;
using KBS.Configuration;
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
                    new Uri(TransportConfiguration.RabbitMqHost),
                    host =>
                    {
                        host.Username(TransportConfiguration.RabbitMqUsername);
                        host.Password(TransportConfiguration.RabbitMqPassword);
                    }
                );

                baseBusFactoryConfigurator(busFactoryConfigurator);
            });
        }
    }
}
