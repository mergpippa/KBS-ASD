using KBS.Data.Enum;

namespace KBS.Configuration
{
    public class TestCaseConfiguration : BaseConfiguration
    {
        /// <summary>
        /// Value that is used to choose the test case that is used to run the benchmark
        /// </summary>
        public static TestCaseType TestCaseType { get => GetFromAny("TestCaseType", TestCaseType.ConsumeConsumer); }

        /// <summary>
        /// Value that is used to choose between the different BusControl transports
        /// </summary>
        public static TransportType TransportType { get => GetFromAny("TransportType", TransportType.InMemory); }

        /// <summary>
        /// Value that is used to choose the telemetry client that is used to track events
        /// </summary>
        public static TelemetryClientType TelemetryClientType { get => GetFromEnvironment("TelemetryClientType", TelemetryClientType.InMemory); }
    }
}