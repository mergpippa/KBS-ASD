using System;
using System.Threading.Tasks;
using KBS.MessageBus;
using KBS.TestCases.Configuration;
using KBS.TestCases.TestCases.Webshop.Consumers;
using KBS.Topics.WebshopCase;
using MassTransit;

namespace KBS.TestCases.TestCases.Webshop
{
    internal class WebshopTestCase : TestCase
    {
        /// <summary>
        /// Name of queue to use for test case
        /// </summary>
        private const string QueueName = "webshop_queue";

        /// <summary>
        /// Constructor that passes the TestCaseConfiguration to the AbstractTestCase
        /// </summary>
        /// <param name="testCaseConfiguration">
        /// </param>
        public WebshopTestCase(TestCaseConfiguration testCaseConfiguration, MessageCaptureContext telemetryClient)
            : base(testCaseConfiguration, telemetryClient)
        {
            if (testCaseConfiguration.MessagesCount > 500)
                throw new ArgumentOutOfRangeException("The Webshop test case should only be used for presentational purposes");
        }

        /// <summary>
        /// Method used to configure the available endpoints for a test case
        /// </summary>
        /// <param name="busFactoryConfigurator">
        /// </param>
        public override void ConfigureEndpoints(IBusFactoryConfigurator busFactoryConfigurator)
        {
            busFactoryConfigurator.ReceiveEndpoint(
                QueueName,
                endpointConfigurator =>
                {
                    endpointConfigurator.Consumer<Buyer>();
                    endpointConfigurator.Consumer<Bank>();
                    endpointConfigurator.Consumer<Shop>();
                }
            );
        }

        /// <summary>
        /// Creates a message object for given index
        /// </summary>
        /// <returns>
        /// </returns>
        protected override object CreateMessage(int index) =>
            new { Id = index, CreatedAt = DateTime.UtcNow };

        /// <summary>
        /// Method to run the test case
        /// </summary>
        /// <param name="busControl">
        /// The bus for the test case to use
        /// </param>
        /// <returns>
        /// </returns>
        public override async Task Run(BusControl busControl)
        {
            await SendMessages(message =>
                busControl.Instance.Publish<ICatalogueRequest>(message).ConfigureAwait(false)
            );
        }
    }
}
