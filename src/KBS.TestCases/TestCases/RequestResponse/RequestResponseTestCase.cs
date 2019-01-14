using System;
using System.Threading.Tasks;
using KBS.MessageBus;
using KBS.TestCases.TestCases.RequestResponse.Consumers;
using KBS.Topics;
using KBS.Topics.RequestResponseCase;
using MassTransit;

namespace KBS.TestCases.TestCases.RequestResponse
{
    /// <summary>
    /// Test case for request and response
    /// </summary>
    public class RequestResponseTestCase : TestCase
    {
        /// <summary>
        /// Name of queue to use for test case
        /// </summary>
        private const string QueueName = "request-response_queue";

        /// <summary>
        /// Constructor that passes the TestCaseConfiguration to the AbstractTestCase
        /// </summary>
        /// <param name="messageCaptureContext">
        /// </param>
        public RequestResponseTestCase(MessageCaptureContext messageCaptureContext) : base(messageCaptureContext)
        { }

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

        /// <summary>
        /// Used to prepare messages that will be sent to the service bus.
        /// </summary>
        /// <param name="index">
        /// </param>
        /// <param name="filler">
        /// </param>
        protected override IMessageDiagnostics CreateMessage(int index, byte[] filler) =>
            new RequestMessage
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
            var hostUri = busControl.Instance.Address;

            var address = new Uri($"{hostUri.Scheme}://{hostUri.Host}/{QueueName}");
            var requestTimeout = TimeSpan.FromSeconds(30);

            var requestClient =
                new MessageRequestClient<IRequestMessage, IResponseMessage>(busControl.Instance, address, requestTimeout);

            await SendMessages(message =>
                requestClient.Request(message).ConfigureAwait(false)
            );
        }
    }

    /// <summary>
    /// Class used to create message instances
    /// </summary>
    internal class RequestMessage : IRequestMessage
    {
        public int Id { get; set; }

        public Type TestCase { get; set; }

        public byte[] Filler { get; set; }
    }
}
