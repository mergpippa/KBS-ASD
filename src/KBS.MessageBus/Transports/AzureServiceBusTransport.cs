using System;
using KBS.MessageBus.Configuration;
using KBS.MessageBus.Data;
using MassTransit;
using MassTransit.Azure.ServiceBus.Core;
using Microsoft.Azure.ServiceBus.Primitives;

namespace KBS.MessageBus.Transports
{
    internal class AzureServiceBusTransport : ITransport
    {
        /// <summary>
        /// Creates a MassTransit instance using the Azure Service Bus transport
        /// </summary>
        /// <param name="messageBusConfigurator"></param>
        /// <returns></returns>
        public IBusControl GetInstance(MessageBusConfigurator messageBusConfigurator)
        {
            return Bus.Factory.CreateUsingAzureServiceBus(busFactoryConfigurator =>
            {
                busFactoryConfigurator.Host(new Uri("sb://localhost"), host =>
                {
                    var operationTimeout = TimeSpan.FromSeconds(Convert.ToDouble(
                        Environment.GetEnvironmentVariable(EnvironmentVariable.OperationTimeout)
                    ));

                    var tokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(
                        TokenProviderKeyName.RootManageSharedAccessKey,
                        Environment.GetEnvironmentVariable(EnvironmentVariable.AzureServiceBusToken)
                    );

                    host.OperationTimeout = operationTimeout;
                    host.TokenProvider = tokenProvider;
                });

                // Create receive endpoints
                messageBusConfigurator.ApplyConfiguration(busFactoryConfigurator);
            });
        }
    }
}
