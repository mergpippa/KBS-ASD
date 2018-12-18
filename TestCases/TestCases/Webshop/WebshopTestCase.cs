using System.Threading.Tasks;
using KBS.MessageBus;
using KBS.TestCases.Contracts;
using KBS.TestCases.TestCases.Webshop.Consumers;
using KBS.Topics.WebshopCase;
using MassTransit;

namespace KBS.TestCases.TestCases.Webshop
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
                    receiveEndpointConfigurator.Consumer<Shop>();
                }
            );
        }

        public async Task Run(BusControl busControl, TestCaseConfiguration testCaseConfiguration)
        {
            await busControl.Publish<ICatalogueRequest>(new { }).ConfigureAwait(false);

            await Task.Delay(testCaseConfiguration.Duration);
        }
    }
}
