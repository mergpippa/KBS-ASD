using KBS.Data.Enum;

namespace KBS.Configuration
{
    public class TestCaseConfiguration : BaseConfiguration
    {
        /// <summary>
        /// Value that is used to choose the test case that is used to run the benchmark
        /// </summary>
        public static TestCaseType TestCaseType =>
            (TestCaseType)GetFromArguments("TestCaseType", (int)TestCaseType.ConsumeConsumer);

        /// <summary>
        /// Value that is used to choose between the different BusControl transports
        /// </summary>
        public static TransportType TransportType =>
            (TransportType)GetFromArguments("TransportType", (int)TransportType.InMemory);

        /// <summary>
        /// Value that is used to choose the telemetry client that is used to track events
        /// </summary>
        public static TelemetryClientType TelemetryClientType =>
            (TelemetryClientType)GetFromEnvironment("TelemetryClientType", (int)TelemetryClientType.InMemory);
    }
}
