using KBS.MessageBus;
using KBS.Telemetry;
using KBS.TestCases.Configuration;
using KBS.TestCases.TestCases;

namespace KBS.Benchmark
{
    public struct BenchmarkContext
    {
        /// <summary>
        /// </summary>
        public BusControl BusControl;

        /// <summary>
        /// </summary>
        public MessageCaptureContext MessageCaptureContext;

        /// <summary>
        /// </summary>
        public ITelemetryClient TelemetryClient;

        /// <summary>
        /// </summary>
        public TestCaseConfiguration TestCaseConfiguration;

        /// <summary>
        /// </summary>
        public TestCase TestCase;
    }
}
