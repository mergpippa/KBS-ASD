using System.Threading.Tasks;
using KBS.MessageBus;
using KBS.MessageBus.Middleware;

namespace KBS.Benchmark.States
{
    public class CreateBusControl : IBenchmarkStep
    {
        public async Task Next(Benchmark benchmark)
        {
            benchmark.Context.BusControl = new BusControl(
                (busFactoryConfigurator) =>
                {
                    // Add PerformanceDiagnostics middleware
                    busFactoryConfigurator.UseMessagePerformanceDiagnostics(benchmark.Context.MessageCaptureContext);

                    benchmark.Context.TestCase.ConfigureEndpoints(busFactoryConfigurator);
                }
            );

            await benchmark.SetNext(new StartBenchmark());
        }
    }
}
