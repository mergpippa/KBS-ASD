using KBS.MessageBus;
using KBS.Telemetry.Clients;
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
        public TestCase TestCase;
    }
}
