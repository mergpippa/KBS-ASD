using KBS.TestCases.Configuration;

namespace KBS.Benchmark.States
{
    public class GetConfiguration : IBenchmarkStep
    {
        public void Next(Benchmark benchmark)
        {
            // Create test case configuration
            benchmark.Context.TestCaseConfiguration = new TestCaseConfiguration();

            // Fill test case configuration using environment
            benchmark.Context.TestCaseConfiguration.FillUsingEnvironment();

            benchmark.Next(new CreateTelemetryClient());
        }
    }
}
