using KBS.MessageBus;
using KBS.TestCases.Configuration;
using KBS.TestCases.TestCases;
using Microsoft.ApplicationInsights;

namespace KBS.Benchmark
{
    public class BenchmarkContext
    {
        /// <summary>
        /// 
        /// </summary>
        public BusControl BusControl;
        
        /// <summary>
        /// 
        /// </summary>
        public readonly MessageCaptureContext MessageCaptureContext;
        
        /// <summary>
        /// 
        /// </summary>
        public TelemetryClient TelemetryClient;

        /// <summary>
        /// 
        /// </summary>
        public TestCaseConfiguration TestCaseConfiguration;

        /// <summary>
        /// 
        /// </summary>
        public TestCase TestCase;
    }
}
