using System;
using System.Threading;
using KBS.MessageBus;
using KBS.TestCases;

namespace KBS.CLI
{
    internal static class Program
    {
        private static void Main()
        {
            Console.Write("Fill in the test case type (0 or 1): ");
            var testCaseType = (TestCaseType)Convert.ToInt32(Console.ReadLine());

            Console.Write("Fill in the duration: ");
            var duration = TimeSpan.FromMilliseconds(long.Parse(Console.ReadLine()));

            Console.Write("Fill in the message minimal size: ");
            var minimalSize = Convert.ToInt32(Console.ReadLine());

            // Create test case configuration using the console input
            var configuration = new TestCaseConfiguration()
            {
                Duration = duration,
                FillerSize = minimalSize
            };

            var testCase = TestCaseFactory.Create(testCaseType, configuration);

            using (var busControl = new BusControl(testCase))
            {
                Console.WriteLine($"Running {testCase.GetType().Name} till {DateTime.Now.Add(configuration.Duration)}");

                testCase.Run(busControl, configuration).Wait();
            }

            Console.WriteLine("Closing application...");
            Thread.Sleep(500);
        }
    }
}
