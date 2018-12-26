using System;
using System.Threading;

namespace KBS.Benchmark.States
{
    public class Cleanup : IBenchmarkStep
    {
        public void Next(BenchmarkStateContext benchmarkStateContext)
        {
            // Stop bus control
            benchmarkStateContext.Context.BusControl.Dispose();

            // Flush in-memory data from telemetry client
            benchmarkStateContext.Context.TelemetryClient.Flush();

            // Allow some time for flushing before shutdown.
            Thread.Sleep(5000);

            // Go to finished state
            Console.WriteLine("Benchmark finished");
        }
    }
}
