using System;
using KBS.MessageBus.Configurator;
using KBS.MessageBus.Data;
using MassTransit;
using MassTransit.Azure.ServiceBus.Core;
using Microsoft.Azure.ServiceBus.Primitives;

namespace KBS.MessageBus.Transports
{
    internal class AzureServiceBusTransport : ITransport
    {
        /// <summary>
        /// URI to Azure Service Bus
        /// </summary>
        private readonly Uri _uri = new Uri(Environment.GetEnvironmentVariable(EnvironmentVariable.AzureServiceBusHost));

        /// <summary>
        /// Private token that is used to authenticate this MassTransit client
        /// </summary>
        private readonly ITokenProvider _tokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(
            TokenProviderKeyName.RootManageSharedAccessKey,
            Environment.GetEnvironmentVariable(EnvironmentVariable.AzureServiceBusToken)
        );

        /// <summary>
        /// Creates a MassTransit instance using the Azure Service Bus transport
        /// </summary>
        /// <param name="messageBusEndpointConfigurator">
        /// </param>
        /// <returns>
        /// </returns>
        public IBusControl GetBusControl(IMessageBusEndpointConfigurator messageBusEndpointConfigurator)
        {
            return Bus.Factory.CreateUsingAzureServiceBus(busFactoryConfigurator =>
            {
                busFactoryConfigurator.Host(_uri, host =>
                {
                    host.OperationTimeout = TimeSpan.FromSeconds(Convert.ToDouble(
                        Environment.GetEnvironmentVariable(EnvironmentVariable.OperationTimeout)
                    ));

                    host.TokenProvider = _tokenProvider;
                });

                // Create receive endpoints for test case
                messageBusEndpointConfigurator.ConfigureEndpoints(busFactoryConfigurator);
            });
        }
    }
}
