using System.Threading.Tasks;
using KBS.MessageBus;
using KBS.MessageBus.Observers;

namespace KBS.Benchmark.States
{
    public class CreateBusControl : IBenchmarkStep
    {
        public async Task Next(Benchmark benchmark)
        {
            benchmark.Context.BusControl = new BusControl(
                (busControl) =>
                {
                    busControl.ConnectReceiveObserver(new ReceiveObserver());
                    busControl.ConnectSendObserver(new SendObserver());
                    busControl.ConnectPublishObserver(new PublishObserver());
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
