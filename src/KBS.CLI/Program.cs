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


            Console.Write("Fill in the message minimal size: ");
            var minimalSize = Convert.ToInt32(Console.ReadLine());

            // Create test case configuration using the console input
            var configuration = new TestCaseConfiguration()
            {
                FillerSize = minimalSize
            };

            var testCase = TestCaseFactory.Create(testCaseType, configuration);

            using (var busControl = new BusControl(testCase))
            {
                Console.WriteLine($"Running {testCase.GetType().Name}");

                testCase.Run(busControl, configuration).Wait();
            }

            Console.WriteLine("Closing application...");
            Thread.Sleep(500);
        }
    }
}
