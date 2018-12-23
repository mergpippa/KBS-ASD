using System;
using KBS.MessageBus;
using KBS.MessageBus.Data;
using KBS.TestCases;

namespace KBS.FauxApplication
{
    internal static class Program
    {
        private static void Main()
        {
            var appInsightsInstrumentationKey = Environment.GetEnvironmentVariable(EnvironmentVariable.AppInsightsInstrumentationKey);

            if (appInsightsInstrumentationKey == null)
                throw new Exception("Missing the `APPINSIGHTS_INSTRUMENTATIONKEY` environment variable");

            // Get test case configuration from environment
            var configuration = new TestCaseConfiguration()
            {
                MessagesCount = 100,

                // Azure limit 262144 bytes
                FillerSize = 12
            };

            var testCase = TestCaseFactory.Create(TestCaseType.RequestResponse, configuration);

            using (var busControl = new BusControl(testCase))
            {
                Console.WriteLine($"Running {testCase.GetType().Name}");

                testCase.Run(busControl, configuration).Wait();
            }

            Console.WriteLine("Press any key to close the application");
            Console.ReadLine();
        }
    }
}
