using Microsoft.ApplicationInsights;

namespace KBS.Benchmark.States
{
    public class CreateTelemetryClient : IBenchmarkStep
    {
        public void Next(BenchmarkStateContext benchmarkStateContext)
        {
            benchmarkStateContext.Context.TelemetryClient = new TelemetryClient();
            
            // Apply any configuration to telemetry client
            
            benchmarkStateContext.Next(new CreateBusControl());
        }
    }
}
