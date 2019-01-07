using System;

namespace KBS.FauxApplication
{
    internal static class Program
    {
        private static void Main()
        {
            var environment = Environment.GetEnvironmentVariable("");

            Console.WriteLine(environment);

            new Benchmark.Benchmark().Run().Wait();
        }
    }
}
