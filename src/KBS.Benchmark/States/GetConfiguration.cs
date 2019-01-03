using System;
using System.IO;
using KBS.TestCases.Configuration;
using Newtonsoft.Json;

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

            Console.WriteLine("Running test using following configuration:");
            Console.WriteLine(JsonConvert.SerializeObject(benchmark.Context.TestCaseConfiguration));

            // Create message capture context
            benchmark.Context.MessageCaptureContext = new MessageCaptureContext(benchmark.Context.TestCaseConfiguration);

            benchmark.Next(new CreateTelemetryClient());
        }
    }
}
