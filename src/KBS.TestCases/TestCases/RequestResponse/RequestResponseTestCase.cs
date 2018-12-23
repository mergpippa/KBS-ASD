using System;
using System.Threading.Tasks;
using KBS.MessageBus;
using KBS.TestCases.Contracts;
using KBS.TestCases.TestCases.RequestResponse.Consumers;
using KBS.Topics.RequestResponseCase;
using MassTransit;

namespace KBS.TestCases.TestCases.RequestResponse
{
    /// <inheritdoc cref="AbstractTestCase" />
    ///    /// <summary>
    /// Test case for request and response
    /// </summary>
    internal class RequestResponseTestCase : AbstractTestCase, ITestCase
    {
        /// <summary>
        /// Name of queue to use for test case
        /// </summary>
        private const string QueueName = "request-response_queue";

        /// <inheritdoc />
        ///        /// <summary>
        /// Constructor that passes the TestCaseConfiguration to the AbstractTestCase
        /// </summary>
        /// <param name="testCaseConfiguration">
        /// </param>
        public RequestResponseTestCase(TestCaseConfiguration testCaseConfiguration) : base(testCaseConfiguration)
        {
        }

        /// <inheritdoc />
        ///        /// <summary>
        /// Method used to configure the available endpoints for a test case
        /// </summary>
        /// <param name="busFactoryConfigurator">
        /// </param>
        public void ConfigureEndpoints(IBusFactoryConfigurator busFactoryConfigurator)
        {
            busFactoryConfigurator.ReceiveEndpoint(QueueName, endpointConfigurator =>
                endpointConfigurator.Consumer<RequestConsumer>()
            );
        }

        /// <summary>
        /// Methode to run the test case
        /// </summary>
        /// <param name="busControl">
        /// The bus for the test case to use
        /// </param>
        /// <param name="testCaseConfiguration">
        /// The configuration for this test case
        /// </param>
        /// <returns>
        /// </returns>
        public async Task Run(BusControl busControl, TestCaseConfiguration testCaseConfiguration)
        {
            Console.WriteLine("Initializing request/response test case");

            var hostUri = busControl.Instance.Address;

            var requestClient = busControl
                .Instance
                .CreateRequestClient<IRequestMessage, IResponseMessage>(
                    new Uri($"{hostUri.Scheme}://{hostUri.Host}/{QueueName}"),
                    TimeSpan.FromSeconds(10)
                );

            await Benchmark(async index =>
            {
                var response = await requestClient.Request(new
                {
                    Id = index,
                    Filler = new byte[testCaseConfiguration.FillerSize]
                });

                await Console.Out.WriteLineAsync($"Response received {response.Id} - {response.Filler.Length} bytes");
            });
        }
    }
}
