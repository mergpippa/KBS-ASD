using System;
using System.Threading.Tasks;

namespace KBS.Benchmark.States
{
    public class WaitForMessages : IBenchmarkStep
    {
        public async void Next(Benchmark benchmark)
        {
            var receiveMessagesTask = CheckIfAllMessagesAreReceived();
            var benchmarkTimeout = BenchmarkTimeout(benchmark.Context.TestCaseConfiguration.Timeout);

            if (await Task.WhenAny(receiveMessagesTask, benchmarkTimeout) == benchmarkTimeout)
            {
                benchmark.Next(new BenchmarkTimeout());

                return;
            }

            benchmark.Next(new Cleanup());
        }

        private static async Task BenchmarkTimeout(TimeSpan timeSpan)
        {
            await Task.Delay(timeSpan);
        }

        private static async Task CheckIfAllMessagesAreReceived()
        {
            // var testCaseConfiguration = new TestCaseConfiguration(); var messageCaptureContext =
            // new TestCaseConfiguration();
            //
            // while (messageCaptureContext.ReceivedMessages < testCaseConfiguration.MessagesCount)
            while (true)
            {
                await Task.Delay(500);
            }
        }
    }
}
