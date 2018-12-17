using System.Threading.Tasks;
using KBS.FauxApplication.Model;
using KBS.FauxApplication.TestCases.RequestResponse.Consumers;
using KBS.MessageBus;
using KBS.Messages.RequestResponseCase;
using MassTransit;

namespace KBS.FauxApplication.TestCases.RequestResponse
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
            await busControl.Publish<IRequestMessage>(new { Count = 2 }).ConfigureAwait(false);

            await Task.Delay(testCaseConfiguration.Duration);
        }
    }
}
