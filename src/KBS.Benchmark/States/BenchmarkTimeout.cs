using System;

namespace KBS.Benchmark.States
{
    internal class BenchmarkTimeout : IBenchmarkStep
    {
        public void Next(Benchmark benchmark)
        {
            Console.WriteLine("Benchmark timed out when receiving messages");

            benchmark.Next(new Cleanup());
        }
    }
}
