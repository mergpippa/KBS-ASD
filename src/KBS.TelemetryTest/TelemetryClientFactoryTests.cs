using System;
using KBS.Data.Enum;
using KBS.Telemetry;
using KBS.Telemetry.Clients;
using Xunit;

namespace KBS.TelemetryTest
{
    public class TelemetryClientFactoryTests
    {
        public TelemetryClientFactoryTests()
        {
            Environment.SetEnvironmentVariable("AppInsightsInstrumentationKey", "myValue");
        }

        [Fact]
        public void Should_CreateTelemetryClientOfTypeInMemoryTelemetryClient()
        {
            var testCase = TelemetryClientFactory.Create(TelemetryClientType.InMemory);

            Assert.IsType<InMemoryTelemetryClient>(testCase);
        }

        [Fact]
        public void Should_ThrowErrorWhenTryingToCreateUndefinedTelemetryClient()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => TelemetryClientFactory.Create(0));
        }
    }
}
