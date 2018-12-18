using System.Threading.Tasks;
using KBS.MessageBus;
using KBS.MessageBus.Configurator;
using KBS.TestCases;
using KBS.TestCases.Contracts;
using MassTransit;
using Xunit;

namespace KBS.MessageBusTests
{
    internal class TestCase : ITestCase
    {
        public void ConfigureEndpoints(IBusFactoryConfigurator busFactoryConfigurator)
        { }

        public Task Run(BusControl busControl, TestCaseConfiguration testCaseConfiguration)
        {
            throw new System.NotImplementedException();
        }
    }

    public class TransportFactoryTests
    {
        [Fact]
        public void Should_CreateMessageBusWithInMemoryTransport()
        {
            var busControl = MessageBusTransportFactory.Create(
                TransportType.InMemory, 
                new MessageBusConfigurator(new TestCase())
            );

            Assert.IsType<MassTransitBus>(busControl);
        }
    }
}
