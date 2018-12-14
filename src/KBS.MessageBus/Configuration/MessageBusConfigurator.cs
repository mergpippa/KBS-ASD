using System;
using System.Collections.Generic;
using KBS.MessageBus.Model;
using MassTransit;

namespace KBS.MessageBus.Configuration
{
    public class MessageBusConfigurator
    {
        private List<ReceiveEndpoint> _receiveEndpoints;

        public MessageBusConfigurator(List<ReceiveEndpoint> receiveEndpoints)
        {
            _receiveEndpoints = receiveEndpoints;
        }

        /// <summary>
        /// Method used to apply configuration to message bus configuration
        /// </summary>
        /// <param name="busConfigurator"></param>
        public void ApplyConfiguration(IBusFactoryConfigurator busConfigurator)
        {
            _receiveEndpoints.ForEach(CreateReceiveEndpointCreator(busConfigurator));
        }

        /// <summary>
        /// Method used to create receive endpoints on given bus configurator
        /// </summary>
        /// <param name="busConfigurator"></param>
        /// <returns></returns>
        private Action<ReceiveEndpoint> CreateReceiveEndpointCreator(IBusFactoryConfigurator busConfigurator)
        {
            return (ReceiveEndpoint receiveEndpoint) =>
                busConfigurator.ReceiveEndpoint(receiveEndpoint.QueueName, receiveEndpointConfigurator =>
                {
                    receiveEndpoint.Consumers.ForEach((consumer) =>
                    {
                        //receiveEndpointConfigurator.Instance(consumer);
                        receiveEndpointConfigurator.Consumer(() => consumer);
                        //receiveEndpointConfigurator.Consumer(() => (IConsumer)Activator.CreateInstance(consumer.GetType()));
                    });
                });
        }
    }
}
