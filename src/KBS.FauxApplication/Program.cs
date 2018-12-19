using System;
using KBS.MessageBus;
using KBS.TestCases;

namespace KBS.FauxApplication
{
    internal static class Program
    {
        private static void Main()
        {
            // Get test case configuration from environment
            var configuration = new TestCaseConfiguration()
            {
                Duration = TimeSpan.FromMilliseconds(5000),
                MessagesCount = 25,

                // Azure limit 262144 bytes
                FillerSize = 12
            };

            var testCase = TestCaseFactory.Create(TestCaseType.RequestResponse, configuration);

            using (var busControl = new BusControl(testCase))
            {
                Console.WriteLine($"Running {testCase.GetType().Name} till {DateTime.Now.Add(configuration.Duration)}");

                testCase.Run(busControl, configuration).Wait();
            }

            Console.WriteLine("Press any key to close the application");
            Console.ReadLine();
        }
    }
}
