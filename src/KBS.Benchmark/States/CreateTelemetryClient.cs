using KBS.Configuration;
using KBS.MessageBus;
using KBS.Telemetry;

namespace KBS.Benchmark.States
{
    public class CreateTelemetryClient : IBenchmarkStep
    {
        public void Next(Benchmark benchmark)
        {
            benchmark.Context.TelemetryClient = TelemetryClientFactory.Create(TestCaseConfiguration.TelemetryClientType);

            // Create message capture context
            benchmark.Context.MessageCaptureContext = new MessageCaptureContext(
                BenchmarkConfiguration.MessagesCount,
                benchmark.Context.TelemetryClient
            );

            benchmark.Next(new CreateTestCase());
        }
    }
}
