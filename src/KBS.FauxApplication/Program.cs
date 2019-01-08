using System;
using System.IO;

namespace KBS.FauxApplication
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(args[0]);

            new Benchmark.Benchmark().Run().Wait();
        }
    }
}
