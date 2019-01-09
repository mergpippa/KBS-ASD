using System;
using System.Threading.Tasks;
using KBS.MessageBus;
using KBS.TestCases.TestCases.Webshop.Consumers;
using KBS.Topics;
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

        /// <inheritdoc />
        ///        /// <summary>
        /// Constructor that passes the TestCaseConfiguration to the AbstractTestCase
        /// </summary>
        /// <param name="telemetryClient">
        /// </param>
        public WebshopTestCase(MessageCaptureContext telemetryClient) : base(telemetryClient)
        { }

        /// <inheritdoc />
        ///        /// <summary>
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
        protected override IMessageDiagnostics CreateMessage(int index, byte[] filler = null) =>
            new CatalogueRequest
            {
                Id = index,
                TestCase = GetType(),
                Filler = filler
            };

        /// <summary>
        /// Method to run the test case
        /// </summary>
        /// <param name="busControl">
        /// The bus for the test case to use
        /// </param>
        public override async Task Run(BusControl busControl)
        {
            await SendMessages(message =>
                busControl.Instance.Publish<ICatalogueRequest>(message).ConfigureAwait(false)
            );
        }
    }

    /// <inheritdoc />
    ///    /// <summary>
    /// Class used to create concrete message instances
    /// </summary>
    internal class CatalogueRequest : ICatalogueRequest
    {
        public int Id { get; set; }

        public Type TestCase { get; set; }

        public byte[] Filler { get; set; }
    }
}
