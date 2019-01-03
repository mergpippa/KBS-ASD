using KBS.Telemetry;

namespace KBS.Benchmark.States
{
    public class CreateTelemetryClient : IBenchmarkStep
    {
        public void Next(Benchmark benchmark)
        {
            benchmark.Context.TelemetryClient =
                TelemetryClientFactory.Create(benchmark.Context.TestCaseConfiguration.TelemetryClientType);

            benchmark.Next(new CreateTestCase());
        }
    }
}
