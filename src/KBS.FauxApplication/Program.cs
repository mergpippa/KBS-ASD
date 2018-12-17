using System;
using System.Threading;
using KBS.FauxApplication.Model;
using KBS.FauxApplication.TestCases;
using KBS.MessageBus;

namespace KBS.FauxApplication
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var testCase = TestCaseFactory.Create(TestCaseType.Webshop);
            var config = new TestConfiguration
            {
                Duration = new TimeSpan(0, 0, 2)
            };

            using (var busControl = new BusControl(testCase))
                testCase.Run(busControl, config).Wait();

            Console.WriteLine("Closing application...");
            Thread.Sleep(1500);
        }
    }
}
