using System.Threading.Tasks;
using KBS.Configuration;
using KBS.MessageBus;
using KBS.Telemetry;

namespace KBS.Benchmark.States
{
    public class CreateTelemetryClient : IBenchmarkStep
    {
        public async Task Next(Benchmark benchmark)
        {
            benchmark.Context.TelemetryClient = TelemetryClientFactory.Create(TestCaseConfiguration.TelemetryClientType);

            // Create message capture context
            benchmark.Context.MessageCaptureContext = new MessageCaptureContext(
                BenchmarkConfiguration.MessageCount,
                benchmark.Context.TelemetryClient
            );

            await benchmark.SetNext(new CreateTestCase());
        }
    }
}
