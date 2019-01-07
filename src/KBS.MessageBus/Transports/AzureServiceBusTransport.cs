using System;
using KBS.Data.Constants;
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
        private readonly Uri _uri = new Uri(Environment.GetEnvironmentVariable(EnvironmentVariables.AzureServiceBusHost));

        /// <summary>
        /// Private token that is used to authenticate this MassTransit client
        /// </summary>
        private readonly ITokenProvider _tokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(
            TokenProviderKeyNames.RootManageSharedAccessKey,
            Environment.GetEnvironmentVariable(EnvironmentVariables.AzureServiceBusToken)
        );

        /// <summary>
        /// Creates a MassTransit instance using the Azure Service Bus transport
        /// </summary>
        /// <param name="messageBusConfigurator">
        /// </param>
        /// <returns>
        /// </returns>
        public IBusControl GetBusControl(Action<IBusFactoryConfigurator> baseBusFactoryConfigurator)
        {
            return Bus.Factory.CreateUsingAzureServiceBus(busFactoryConfigurator =>
            {
                busFactoryConfigurator.Host(_uri, host =>
                {
                    host.OperationTimeout = TimeSpan.FromSeconds(Convert.ToDouble(
                        Environment.GetEnvironmentVariable(EnvironmentVariables.AzureServiceBusOperationTimeout)
                    ));

                    host.TokenProvider = _tokenProvider;
                });

                baseBusFactoryConfigurator(busFactoryConfigurator);
            });
        }
    }
}
