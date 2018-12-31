using System.IO;
using KBS.TestCases.Configuration;

namespace KBS.Benchmark.States
{
    public class GetConfiguration : IBenchmarkStep
    {
        private const string _path = "./testCaseConfiguration.json";

        public void Next(Benchmark benchmark)
        {
            // Create test case configuration
            benchmark.Context.TestCaseConfiguration = new TestCaseConfiguration();

            // Fill configuration using configuration file if it exists
            if (File.Exists(_path))
            {
                benchmark.Context.TestCaseConfiguration.FillUsingConfigurationFile(_path);
            }

            // Fill test case configuration using environment
            benchmark.Context.TestCaseConfiguration.FillUsingEnvironment();

            benchmark.Next(new CreateTelemetryClient());
        }
    }
}
