using System;
using System.Threading.Tasks;
using KBS.MessageBus;
using KBS.TestCases.Configuration;
using KBS.TestCases.TestCases.RequestResponse.Consumers;
using KBS.Topics;
using KBS.Topics.RequestResponseCase;
using MassTransit;

namespace KBS.TestCases.TestCases.RequestResponse
{
    /// <summary>
    /// Test case for request and response
    /// </summary>
    internal class RequestResponseTestCase : TestCase
    {
        /// <summary>
        /// Name of queue to use for test case
        /// </summary>
        private const string QueueName = "request-response_queue";

        /// <summary>
        /// Constructor that passes the TestCaseConfiguration to the AbstractTestCase
        /// </summary>
        /// <param name="testCaseConfiguration">
        /// </param>
        public RequestResponseTestCase(TestCaseConfiguration testCaseConfiguration, MessageCaptureContext messageCaptureContext)
            : base(testCaseConfiguration, messageCaptureContext)
        {
        }

        /// <summary>
        /// Method used to configure the available endpoints for a test case
        /// </summary>
        /// <param name="busFactoryConfigurator">
        /// </param>
        public override void ConfigureEndpoints(IBusFactoryConfigurator busFactoryConfigurator)
        {
            busFactoryConfigurator.ReceiveEndpoint(QueueName, endpointConfigurator =>
                endpointConfigurator.Consumer<RequestConsumer>()
            );
        }

        protected override IMessageDiagnostics CreateMessage(int index) =>
            new RequestMessage { Id = index };

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
            var hostUri = busControl.Instance.Address;

            var requestClient = busControl
                .Instance
                .CreateRequestClient<IRequestMessage, IResponseMessage>(
                    new Uri($"{hostUri.Scheme}://{hostUri.Host}/{QueueName}"),
                    TimeSpan.FromSeconds(10)
                );

            await SendMessages(async message =>
                await requestClient.Request(message)
            );
        }
    }

    internal class RequestMessage : IRequestMessage
    {
        public int Id { get; set; }

        public byte[] Filler { get; set; }
    }
}
