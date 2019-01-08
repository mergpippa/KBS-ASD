<<<<<<< HEAD
using KBS.Configuration;
=======
using System.Threading.Tasks;
>>>>>>> develop
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
                BenchmarkConfiguration.MessagesCount,
                benchmark.Context.TelemetryClient
            );

            await benchmark.SetNext(new CreateTestCase());
        }
    }
}
