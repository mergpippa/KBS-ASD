namespace KBS.Benchmark.States
{
    public interface IBenchmarkStep
    {
        void Next(BenchmarkStateContext benchmarkStateContext);
    }
}
