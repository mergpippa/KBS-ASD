using KBS.MessageBus;

namespace KBS.Benchmark.States
{
    public class StartBenchmark : IBenchmarkStep
    {
        public void Next(BenchmarkStateContext benchmarkStateContext)
        {
            benchmarkStateContext.Context.BusControl = new BusControl(benchmarkStateContext.Context.TestCase);
            
            benchmarkStateContext.Context.TestCase.Run(benchmarkStateContext.Context.BusControl);
            
            benchmarkStateContext.Next(new WaitingForMessages());
        }
    }
}
