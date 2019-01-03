using System.Threading.Tasks;

namespace KBS.FauxApplication
{
    internal static class Program
    {
        private static void Main()
        {
            var benchmark = new Benchmark.Benchmark();

            System.Console.ReadLine();

            // WaitBenchmarkAsync(benchmark).Wait();
        }

        private static async Task WaitBenchmarkAsync(Benchmark.Benchmark benchmark)
        {
            var messageCaptureContext = benchmark.Context.MessageCaptureContext;

            while (!messageCaptureContext.DidReceiveAllMessages && !messageCaptureContext.DidTimeoutWhenWaitingOnMessages)
            {
                await Task.Delay(150);
            }

            return;
        }
    }
}
