using System;

namespace KBS.FauxApplication
{
    internal static class Program
    {
        private static void Main()
        {
            new Benchmark.Benchmark();

            Console.WriteLine("Press any key to close the application");
            Console.ReadLine();
        }
    }
}
