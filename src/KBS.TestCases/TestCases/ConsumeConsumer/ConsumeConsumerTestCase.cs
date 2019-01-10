using System;
using System.Threading.Tasks;
using KBS.MessageBus;
using KBS.Topics;
using KBS.Topics.ConsumerCase;
using MassTransit;

namespace KBS.TestCases.TestCases.ConsumeConsumer
{
    internal class ConsumeConsumerTestCase : TestCase
    {
        /// <summary>
        /// Name of queue to use for this test case
        /// </summary>
        private const string QueueName = "consume-consumer_queue";

        /// <summary>
        /// Constructor that passes the TestCaseConfiguration through to the AbstractTestCase
        /// </summary>
        /// <param name="telemetryClient">
        /// </param>
        public ConsumeConsumerTestCase(MessageCaptureContext telemetryClient) : base(telemetryClient)
        { }

        /// <summary>
        /// Method used to configure the available endpoints for a test case
        /// </summary>
        /// <param name="busFactoryConfigurator">
        /// </param>
        public override void ConfigureEndpoints(IBusFactoryConfigurator busFactoryConfigurator)
        {
            busFactoryConfigurator.ReceiveEndpoint(
                QueueName,
                endpointConfigurator => endpointConfigurator.Consumer<Consumers.ConsumeConsumer>()
            );
        }

        /// <summary>
        /// Creates a message object for given index
        /// </summary>
        /// <returns>
        /// </returns>
        protected override IMessageDiagnostics CreateMessage(int index, byte[] filler = null) =>
            new ConsumeMessage
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
        /// <returns>
        /// </returns>
        public override async Task Run(BusControl busControl)
        {
            await SendMessages(message =>
                busControl.Instance.Publish<IConsumeMessage>(message).ConfigureAwait(false)
            );
        }
    }

    /// <summary>
    /// Class used to create concrete message instances
    /// </summary>
    internal class ConsumeMessage : IConsumeMessage
    {
        public int Id { get; set; }

        public Type TestCase { get; set; }

        public byte[] Filler { get; set; }
    }
}
