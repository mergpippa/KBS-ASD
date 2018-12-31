using System;

namespace KBS.Benchmark.States
{
    public class Cleanup : IBenchmarkStep
    {
        public async void Next(Benchmark benchmark)
        {
            // Stop bus control
            benchmark.Context.BusControl.Dispose();

            // Flush in-memory data from telemetry client
            await benchmark.Context.TelemetryClient.Flush();

            // Go to finished state
            Console.WriteLine("Benchmark finished");
        }
    }
}
