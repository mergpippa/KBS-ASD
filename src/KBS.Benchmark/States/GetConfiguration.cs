using KBS.TestCases.Configuration;

namespace KBS.Benchmark.States
{
    public class GetConfiguration : IBenchmarkStep
    {
        public void Next(BenchmarkStateContext benchmarkStateContext)
        {
            // Create test case configuration
            benchmarkStateContext.Context.TestCaseConfiguration = new TestCaseConfiguration();
            
            // Fill test case configuration using environment
            benchmarkStateContext.Context.TestCaseConfiguration.FillUsingEnvironment();
            
            benchmarkStateContext.Next(new Initialize());
        }
    }
}
