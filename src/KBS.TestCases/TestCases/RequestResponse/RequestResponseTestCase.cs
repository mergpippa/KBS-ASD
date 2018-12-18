using System;
using System.Threading.Tasks;
using KBS.MessageBus;
using KBS.TestCases.Contracts;
using KBS.TestCases.TestCases.RequestResponse.Consumers;
using KBS.Topics.RequestResponseCase;
using MassTransit;

namespace KBS.TestCases.TestCases.RequestResponse
{
    internal class RequestResponseTestCase : ITestCase
    {
        private readonly string _endpointQueueName = "request-response_queue";

        public void ConfigureEndpoints(IBusFactoryConfigurator busFactoryConfigurator)
        {
            busFactoryConfigurator.ReceiveEndpoint(_endpointQueueName, receiveEndpointConfigurator =>
            {
                receiveEndpointConfigurator.Consumer<RequestConsumer>();
                receiveEndpointConfigurator.Consumer<ResponseConsumer>();
            });
        }

        public async Task Run(BusControl busControl, TestCaseConfiguration testCaseConfiguration)
        {
            Console.WriteLine("Sending message");
            
            await busControl.Publish<IRequestMessage>(new { Count = 2 }).ConfigureAwait(false);

            await Task.Delay(testCaseConfiguration.Duration);
        }
    }
}
