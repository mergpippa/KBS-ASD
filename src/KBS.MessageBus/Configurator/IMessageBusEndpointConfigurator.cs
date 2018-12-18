using MassTransit;

namespace KBS.MessageBus.Configurator
{
    public interface IMessageBusEndpointConfigurator
    {
        /// <summary>
        /// Method used to configure the available endpoints for a test case
        /// </summary>
        /// <param name="busFactoryConfigurator">
        /// </param>
        void ConfigureEndpoints(IBusFactoryConfigurator busFactoryConfigurator);
    }
}
