using System;
using System.Threading.Tasks;

namespace KBS.Benchmark.States
{
    public class Cleanup : IBenchmarkStep
    {
        public async Task Next(Benchmark benchmark)
        {
            // Flush in-memory data from telemetry client
            await benchmark.Context.TelemetryClient.Flush();

            // Stop bus control
            benchmark.Context.BusControl.Dispose();

            Console.WriteLine(benchmark.Context.MessageCaptureContext);

            // Go to finished state
            Console.WriteLine("Benchmark finished");

            await Task.Delay(500);
        }
    }
}
