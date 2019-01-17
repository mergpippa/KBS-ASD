using System;
using KBS.Configuration;
using KBS.Data.Enum;
using KBS.MessageBus;
using MassTransit;
using Xunit;

namespace KBS.MessageBusTests
{
    public class TransportFactoryTests
    {
        public TransportFactoryTests()
        {
            BaseConfiguration.SetCommandLineArgsConfiguration("{}");

            Environment.SetEnvironmentVariable("AzureServiceBusUri", "amqp://azureservicebus.url");
            Environment.SetEnvironmentVariable("AzureServiceBusToken", "testToken");

            Environment.SetEnvironmentVariable("RabbitMqHost", "rabbitmq://rabbitmq.validurl");
            Environment.SetEnvironmentVariable("RabbitMqUsername", "rabbitMqUsername");
            Environment.SetEnvironmentVariable("RabbitMqPassword", "rabbitMqPassword");
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

            Console.WriteLine(busControl.GetType());

            Assert.IsType<MassTransitBus>(busControl);
        }
    }
}
