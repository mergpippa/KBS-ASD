using System;
using System.Threading;
using KBS.FauxApplication.TestCases;
using KBS.MessageBus;
using KBS.Messages.WebshopCase;

namespace KBS.FauxApplication
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var testCase = TestCaseFactory.Create(TestCaseType.Webshop);

            using (var busControl = new BusControl(testCase))
            {
                busControl.Publish<ICatalogueRequest>(new { });

                Console.WriteLine("Waiting...");
                Console.ReadLine();
            }

            Console.WriteLine("Closing application...");
            Thread.Sleep(1500);
        }
    }
}
