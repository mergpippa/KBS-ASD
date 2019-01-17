using KBS.Configuration;
using KBS.Data.Enum;
using Xunit;

namespace KBS.ConfigurationTests
{
    public class TestCaseConfigurationTests
    {
        [Fact]
        public void Should_GetTestCaseType()
        {
            var value = TestCaseConfiguration.TestCaseType;

            Assert.Equal(TestCaseType.ConsumeConsumer, value);
            Assert.IsType<TestCaseType>(value);
        }

        [Fact]
        public void Should_GetTransportType()
        {
            var value = TestCaseConfiguration.TransportType;

            Assert.Equal(TransportType.InMemory, value);
            Assert.IsType<TransportType>(value);
        }

        [Fact]
        public void Should_GetTelemetryClientType()
        {
            var value = TestCaseConfiguration.TelemetryClientType;

            Assert.Equal(TelemetryClientType.InMemory, value);
            Assert.IsType<TelemetryClientType>(value);
        }
    }
}
