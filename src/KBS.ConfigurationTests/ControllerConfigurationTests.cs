using System;
using KBS.Configuration;
using Xunit;

namespace KBS.ConfigurationTests
{
    public class ControllerConfigurationTests
    {
        public ControllerConfigurationTests()
        {
            Environment.SetEnvironmentVariable("WebJobHost", "https://kbs-asd-test.azurewebsites.net/");
        }

        [Fact]
        public void Should_GetWebJobHost()
        {
            var value = ControllerConfiguration.KuduHost;

            Assert.IsType<string>(value);
            Assert.Equal("https://kbs-asd-test.azurewebsites.net/", value);
        }
    }
}
