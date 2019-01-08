using System;
using KBS.Configuration;
using KBS.TestCases;

namespace KBS.Benchmark.States
{
    public class CreateTestCase : IBenchmarkStep
    {
        public void Next(Benchmark benchmark)
        {
            Console.WriteLine(benchmark.Context.TelemetryClient);

            // Create test case using test case factory
            benchmark.Context.TestCase = TestCaseFactory.Create(
                TestCaseConfiguration.TestCaseType,
                benchmark.Context.MessageCaptureContext
            );

            // Set next state
            benchmark.Next(new CreateBusControl());
        }
    }
}
