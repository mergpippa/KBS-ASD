using System;
using KBS.Data.Enum;
using KBS.MessageBus;
using KBS.MessageBus.Configurator;
using MassTransit;
using Xunit;

namespace KBS.MessageBusTests
{
    public class TransportFactoryTests
    {
        private class ConcreteEndpointConfigurator : IMessageBusEndpointConfigurator
        {
            public void ConfigureEndpoints(IBusFactoryConfigurator busFactoryConfigurator)
            {
                throw new NotImplementedException();
            }
        }

        [Fact]
        public void Should_CreateMessageBusWithInMemoryTransport()
        {
            var busControl = TransportFactory.Create(
                TransportType.InMemory,
                (_) => { }
            );

            Assert.IsType<MassTransitBus>(busControl);
        }
    }
}
