using KBS.MessageBus;

namespace KBS.Benchmark.States
{
    public class CreateBusControl : IBenchmarkStep
    {
        public void Next(BenchmarkStateContext benchmarkStateContext)
        {
            benchmarkStateContext.Context.BusControl = new BusControl(benchmarkStateContext.Context.TestCase);
            
            benchmarkStateContext.Next(new StartBenchmark());
        }
    }
}
