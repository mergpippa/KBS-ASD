using System;
using System.Threading;
using System.Threading.Tasks;
using KBS.MessageBus;

namespace KBS.Benchmark.States
{
    public class WaitForMessages : IBenchmarkStep
    {
        public async void Next(Benchmark benchmark)
        {
            var cancellationTokenSource = new CancellationTokenSource();

            var receiveMessagesTask = DidReceiveAllMessages(benchmark.Context.MessageCaptureContext, cancellationTokenSource.Token);
            var benchmarkTimeoutTask = BenchmarkTimeout(benchmark.Context.TestCaseConfiguration.BenchmarkTimeout, cancellationTokenSource.Token);

            if (await Task.WhenAny(receiveMessagesTask, benchmarkTimeoutTask) == benchmarkTimeoutTask)
            {
                // Cancel benchmarkTimeoutTask
                cancellationTokenSource.Cancel();

                benchmark.Context.MessageCaptureContext.DidTimeoutWhenWaitingOnMessages = true;

                benchmark.Next(new BenchmarkTimeout());

                return;
            }

            // Cancel receiveMessagesTask
            benchmark.Next(new Cleanup());
        }

        /// <summary>
        /// Creates tasks that ends when the test case timeout has elapsed
        /// </summary>
        /// <param name="timeSpan">
        /// </param>
        /// <param name="cancellationToken">
        /// </param>
        /// <returns>
        /// </returns>
        private static async Task BenchmarkTimeout(TimeSpan timeSpan, CancellationToken cancellationToken)
        {
            await Task.Delay(timeSpan, cancellationToken);
        }

        /// <summary>
        /// Creates tasks that polls the DidReceiveAllMessages property in MessageCaptureContext
        /// </summary>
        /// <param name="messageCaptureContext">
        /// </param>
        /// <param name="cancellationToken">
        /// </param>
        /// <returns>
        /// </returns>
        private static async Task DidReceiveAllMessages(MessageCaptureContext messageCaptureContext, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return;

            while (!messageCaptureContext.DidReceiveAllMessages)
            {
                await Task.Delay(500, cancellationToken);
            }
        }
    }
}
