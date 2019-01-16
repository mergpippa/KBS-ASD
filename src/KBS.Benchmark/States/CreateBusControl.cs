using System;
using System.Threading.Tasks;
using KBS.Configuration;
using KBS.MessageBus;
using KBS.MessageBus.Observers;

namespace KBS.Benchmark.States
{
    public class CreateBusControl : IBenchmarkStep
    {
        public async Task Next(Benchmark benchmark)
        {
            Console.WriteLine(TestCaseConfiguration.TransportType);

            benchmark.Context.BusControl = new BusControl(
                (busControl) =>
                {
                    busControl.ConnectReceiveObserver(new ReceiveObserver(benchmark.Context.MessageCaptureContext));
                    busControl.ConnectConsumeObserver(new ConsumeObserver(benchmark.Context.MessageCaptureContext));
                    busControl.ConnectSendObserver(new SendObserver(benchmark.Context.MessageCaptureContext));
                    busControl.ConnectPublishObserver(new PublishObserver(benchmark.Context.MessageCaptureContext));
                },
                (busFactoryConfigurator) =>
                {
                    benchmark.Context.TestCase.ConfigureEndpoints(busFactoryConfigurator);
                }
            );

            await benchmark.SetNext(new StartBenchmark());
        }
    }
}
