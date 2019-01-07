using KBS.Data.Enum;
using KBS.MessageBus;
using MassTransit;
using Xunit;

namespace KBS.MessageBusTests
{
    public class TransportFactoryTests
    {
        [Fact]
        public void Should_CreateMessageBusWithInMemoryTransport()
        {
            var busControl = TransportFactory.Create(
                TransportType.InMemory,
                (_) => { }
            );

            Assert.IsType<MassTransitBus>(busControl);
        }

        [Fact]
        public void Should_CreateMessageBusWithAzureServiceBusTransport()
        {
            var busControl = TransportFactory.Create(
                TransportType.AzureServiceBus,
                (_) => { }
            );

            Assert.IsType<MassTransitBus>(busControl);
        }

        [Fact]
        public void Should_CreateMessageBusWithRabbitMqBusTransport()
        {
            var busControl = TransportFactory.Create(
                TransportType.RabbitMq,
                (_) => { }
            );

            System.Console.WriteLine(busControl.GetType());

            Assert.IsType<MassTransitBus>(busControl);
        }
    }
}
