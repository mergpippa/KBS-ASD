using System.Threading;
using System.Threading.Tasks;
using KBS.Configuration;
using KBS.MessageBus;

namespace KBS.Benchmark.States
{
    public class WaitForMessages : IBenchmarkStep
    {
<<<<<<< HEAD
        /// <summary>
        /// </summary>
        /// <param name="benchmark">
        /// </param>
        public async void Next(Benchmark benchmark)
=======
        public async Task Next(Benchmark benchmark)
>>>>>>> develop
        {
            var cancellationTokenSource = new CancellationTokenSource();

            var receiveMessagesTask = DidReceiveAllMessages(benchmark.Context.MessageCaptureContext, cancellationTokenSource.Token);
            var benchmarkTimeoutTask = Task.Delay(BenchmarkConfiguration.Timeout, cancellationTokenSource.Token);

            if (await Task.WhenAny(receiveMessagesTask, benchmarkTimeoutTask) == benchmarkTimeoutTask)
            {
                // Cancel benchmarkTimeoutTask
                cancellationTokenSource.Cancel();

                benchmark.Context.MessageCaptureContext.DidTimeoutWhenWaitingOnMessages = true;

                await benchmark.SetNext(new BenchmarkTimeout());

                return;
            }

            // Cancel receiveMessagesTask
            await benchmark.SetNext(new Cleanup());
        }

        /// <summary>
        /// Creates tasks that polls the DidReceiveAllMessages property in MessageCaptureContext
        /// </summary>
        /// <param name="messageCaptureContext">
        /// </param>
        /// <param name="cancellationToken">
        /// </param>
        private static async Task DidReceiveAllMessages(MessageCaptureContext messageCaptureContext, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return;

            while (!messageCaptureContext.DidReceiveAllMessages)
            {
                await Task.Delay(250, cancellationToken);
            }
        }
    }
}
