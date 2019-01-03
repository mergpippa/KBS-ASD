using KBS.Telemetry;

namespace KBS.Benchmark.States
{
    public class CreateTelemetryClient : IBenchmarkStep
    {
        public void Next(Benchmark benchmark)
        {
            benchmark.Context.TelemetryClient = new InMemoryTelemetryClient();

            benchmark.Next(new CreateTestCase());
        }
    }
}
