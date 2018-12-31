using System;
using KBS.Data.Constants;
using KBS.Data.Enum;
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
                (TestCaseType)int.Parse(Environment.GetEnvironmentVariable(EnvironmentVariables.TestCaseType)),
                benchmark.Context.TestCaseConfiguration,
                benchmark.Context.TelemetryClient
            );

            // Set next state
            benchmark.Next(new CreateBusControl());
        }
    }
}
