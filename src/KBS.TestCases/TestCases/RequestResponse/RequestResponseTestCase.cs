using System;
using System.Threading.Tasks;
using KBS.MessageBus;
using KBS.TestCases.Contracts;
using KBS.TestCases.TestCases.RequestResponse.Consumers;
using KBS.Topics.RequestResponseCase;
using MassTransit;

namespace KBS.TestCases.TestCases.RequestResponse
{
    /// <summary>
    /// Test case for request and response
    /// </summary>
    internal class RequestResponseTestCase : ITestCase
    {
        /// <summary>
        /// Name of queue to use for test case
        /// </summary>
        private readonly string _queueName = "request-response_queue";

        /// <summary>
        /// Method used to configure the available endpoints for a test case
        /// </summary>
        /// <param name="busFactoryConfigurator">
        /// </param>
        public void ConfigureEndpoints(IBusFactoryConfigurator busFactoryConfigurator)
        {
            busFactoryConfigurator.ReceiveEndpoint(_queueName, endpointConfigurator =>
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

            var requestClient = busControl
                .Instance
                .CreateRequestClient<IRequestMessage, IResponseMessage>(
                    new Uri("sb://kbs-asd.servicebus.windows.net/request-response_queue"),
                    TimeSpan.FromSeconds(10)
                );

            Console.WriteLine("Starting benchmark");

            for (int i = 3; i > 0; i--)
            {
                var response = await requestClient.Request(new
                {
                    Count = i,
                    Filler = new byte[testCaseConfiguration.FillerSize]
                }).ConfigureAwait(false);

                Console.WriteLine($"Response received {response.Filler.Length} bytes");
            }

            await Task.Delay(testCaseConfiguration.Duration);
        }
    }
}
