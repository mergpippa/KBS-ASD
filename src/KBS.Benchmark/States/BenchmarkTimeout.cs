using System;
using System.Threading.Tasks;

namespace KBS.Benchmark.States
{
    internal class BenchmarkTimeout : IBenchmarkStep
    {
        public Task Next(Benchmark benchmark)
        {
            Console.WriteLine("Benchmark timed out when receiving messages");

            return benchmark.SetNext(new Cleanup());
        }
    }
}
