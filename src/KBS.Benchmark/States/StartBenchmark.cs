using System.Threading.Tasks;

namespace KBS.Benchmark.States
{
    public class StartBenchmark : IBenchmarkStep
    {
        public async Task Next(Benchmark benchmark)
        {
            await benchmark.Context.TestCase.Run(benchmark.Context.BusControl);

            await benchmark.SetNext(new WaitForMessages());
        }
    }
}
