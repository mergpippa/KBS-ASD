using System.Threading.Tasks;
using KBS.MessageBus;
using KBS.Messages.WebshopCase;
using KBS.TestCases.Contracts;
using KBS.TestCases.TestCases.Webshop.Consumers;
using MassTransit;

namespace KBS.TestCases.TestCases.Webshop
{
    internal class WebshopTestCase : ITestCase
    {
        /// <summary>
        /// Name of queue to use for test case
        /// </summary>
        private readonly string _queueName = "webshop_queue";

        /// <summary>
        /// Method used to configure the available endpoints for a test case
        /// </summary>
        /// <param name="busFactoryConfigurator">
        /// </param>
        public void ConfigureEndpoints(IBusFactoryConfigurator busFactoryConfigurator)
        {
            busFactoryConfigurator.ReceiveEndpoint(
                _queueName,
                endpointConfigurator =>
                {
                    endpointConfigurator.Consumer<Buyer>();
                    endpointConfigurator.Consumer<Bank>();
                    endpointConfigurator.Consumer<Shop>();
                }
            );
        }

        /// <summary>
        /// Methode to run the test case
        /// </summary>
        /// <param name="busControl">The bus for the test case to use</param>
        /// <param name="testCaseConfiguration">The configuration for this test case</param>
        /// <returns></returns>
        public async Task Run(BusControl busControl, TestCaseConfiguration testCaseConfiguration)
        {
            await busControl.Publish<ICatalogueRequest>(new { }).ConfigureAwait(false);

            await Task.Delay(testCaseConfiguration.Duration);
        }
    }
}
