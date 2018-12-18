using System;
using System.Threading;
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
                Duration = 5000,
                MessageFrequency = 10,
                MinimalSize = 1024
            };

            var testCase = TestCaseFactory.Create(TestCaseType.RequestResponse);

            using (var busControl = new BusControl(testCase))
            {
                Console.WriteLine($"Running {testCase.GetType().Name} till {DateTime.Now.AddMilliseconds(configuration.Duration)}");

                testCase.Run(busControl, configuration).Wait();
            }

            Console.WriteLine("Closing application...");
            Thread.Sleep(500);
        }
    }
}
