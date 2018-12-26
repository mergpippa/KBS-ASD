using System;
using KBS.MessageBus.Data;
using KBS.TestCases;

namespace KBS.Benchmark.States
{
    public class Initialize : IBenchmarkStep
    {
        public void Next(BenchmarkStateContext benchmarkStateContext)
        {
            // Check if app insight instrumentation key is set
            Environment.GetEnvironmentVariable(EnvironmentVariable.AppInsightsInstrumentationKey);

            // Create test case using test case factory
            benchmarkStateContext.Context.TestCase = TestCaseFactory.Create(
                (TestCaseType) int.Parse(Environment.GetEnvironmentVariable("TEST_CASE_TYPE")), 
                benchmarkStateContext.Context.TestCaseConfiguration
            );
                
            // Set next state
            benchmarkStateContext.Next(new CreateTelemetryClient());
        }
    }
}
