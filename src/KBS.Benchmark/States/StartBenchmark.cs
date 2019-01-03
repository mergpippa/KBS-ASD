namespace KBS.Benchmark.States
{
    public class StartBenchmark : IBenchmarkStep
    {
        public async void Next(Benchmark benchmark)
        {
            await benchmark.Context.TestCase.Run(benchmark.Context.BusControl);

            benchmark.Next(new WaitForMessages());
        }
    }
}
