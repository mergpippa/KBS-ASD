using System;
using KBS.TestCases;

namespace KBS.Benchmark.States
{
    public class CreateTestCase : IBenchmarkStep
    {
        public void Next(Benchmark benchmark)
        {
            Console.WriteLine(benchmark.Context.TelemetryClient);
            Console.WriteLine(benchmark.Context.TestCaseConfiguration);

            // Create test case using test case factory
            benchmark.Context.TestCase = TestCaseFactory.Create(
                benchmark.Context.TestCaseConfiguration.TestCaseType,
                benchmark.Context.TestCaseConfiguration,
                benchmark.Context.MessageCaptureContext
            );

            // Set next state
            benchmark.Next(new CreateBusControl());
        }
    }
}
