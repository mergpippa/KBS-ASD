using Configuration.BusControlConfiguration;
using Xunit;

namespace ConfigurationTests
{
    public class AzureServiceBusTransportConfigurationTests
    {
        [Fact]
        public void Should_FillConfigurationUsingJsonFile()
        {
            var azureServiceBusTransportConfiguration = new AzureServiceBusTransportConfiguration();

            azureServiceBusTransportConfiguration.FillUsingJsonFile("./testConfiguration.json");

            Assert.NotNull(azureServiceBusTransportConfiguration.Uri);
        }
    }
}
