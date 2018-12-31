namespace KBS.Benchmark.States
{
    public class StartBenchmark : IBenchmarkStep
    {
        public void Next(Benchmark benchmark)
        {
            benchmark.Context.TestCase.Run(benchmark.Context.BusControl);

            benchmark.Next(new WaitForMessages());
        }
    }
}
