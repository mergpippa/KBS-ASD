using System;
using KBS.Configuration;
using Xunit;

namespace KBS.ConfigurationTests
{
    public class TransportConfigurationTests
    {
        public TransportConfigurationTests()
        {
            Environment.SetEnvironmentVariable("AzureServiceBusUri", "amqp://myservicebus.url");
            Environment.SetEnvironmentVariable("AzureServiceBusToken", "testToken");
        }

        [Fact]
        public void Should_GetAzureServiceBusUri()
        {
            var value = TransportConfiguration.AzureServiceBusUri;

            Assert.Equal("amqp://myservicebus.url", value);
        }

        [Fact]
        public void Should_GetAzureServiceBusToken()
        {
            var value = TransportConfiguration.AzureServiceBusToken;

            Assert.Equal("testToken", value);
        }
    }
}
