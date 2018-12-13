using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KBS.MessageBus.Model;
using KBS.Messages.WebshopCase;
using MassTransit;

namespace KBS.MessageBus.Configuration
{
    public class MessageBusConfigurator
    {
        public List<ReceiveEndpoint> ReceiveEndpoints;

        /// <summary>
        /// Method used to apply configuration to message bus configuration
        /// </summary>
        /// <param name="busConfigurator"></param>
        public void ApplyConfiguration(IBusFactoryConfigurator busConfigurator)
        {
            ReceiveEndpoints.ForEach(CreateReceiveEndpointCreator(busConfigurator));
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
                    //receiveEndpointConfigurator.Consumer<MyConsumer>();
                    receiveEndpoint.Consumers.ForEach((consumer) =>
                    {
                        receiveEndpointConfigurator.Consumer(() => consumer);
                    });
                });
        }
    }

    internal class MyConsumer : IConsumer<ICatalogueRequest>, IConsumer<ICatalogueReply>
    {
        public async Task Consume(ConsumeContext<ICatalogueRequest> context)
        {
            await Console.Out.WriteLineAsync("Requested");
            await context.Publish<ICatalogueReply>(new { Text = "Test" });
        }

        public Task Consume(ConsumeContext<ICatalogueReply> context)
        {
            return Console.Out.WriteLineAsync(context.Message.Text);
        }
    }
}
