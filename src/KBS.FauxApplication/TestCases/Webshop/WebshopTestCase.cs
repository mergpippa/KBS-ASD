using KBS.FauxApplication.TestCases.Webshop.Consumers;
using KBS.MessageBus.Configurator;
using MassTransit;

namespace KBS.FauxApplication.TestCases.Webshop
{
    internal class WebshopTestCase : ITestCase
    {
        private readonly string _endpointQueueName = "webshop_queue";

        /// <summary>
        /// Method used to configure the available endpoints for a test case
        /// </summary>
        /// <param name="busFactoryConfigurator">
        /// </param>
        public void ConfigureEndpoints(IBusFactoryConfigurator busFactoryConfigurator)
        {
            busFactoryConfigurator.ReceiveEndpoint(
                _endpointQueueName,
                receiveEndpointConfigurator =>
                {
                    receiveEndpointConfigurator.Consumer<Buyer>();
                    receiveEndpointConfigurator.Consumer<Bank>();
                    receiveEndpointConfigurator.Consumer<Transaction>();
                }
            );
        }
    }
}
