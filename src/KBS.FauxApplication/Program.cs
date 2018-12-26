using System;
using KBS.Benchmark;
using KBS.Benchmark.States;

namespace KBS.FauxApplication
{
    internal static class Program
    {
        private static void Main()
        {
            new BenchmarkStateContext();

            Console.WriteLine("Press any key to close the application");
            Console.ReadLine();
        }
    }
}
