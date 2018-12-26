using KBS.MessageBus;
using KBS.MessageBus.Configurator;
using MassTransit;
using Xunit;

namespace KBS.MessageBusTests
{
    public class TransportFactoryTests
    {
        class ConcreteEndpointConfigurator : IMessageBusEndpointConfigurator
        {
            public void ConfigureEndpoints(IBusFactoryConfigurator busFactoryConfigurator)
            {
            }
        }

        [Fact]
        public void Should_CreateMessageBusWithInMemoryTransport()
        {
            var busControl = MessageBusTransportFactory.Create(
                TransportType.InMemory,
                new MessageBusConfigurator(new ConcreteEndpointConfigurator())
            );

            Assert.IsType<MassTransitBus>(busControl);
        }
    }
}
