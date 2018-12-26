using System;
using System.Threading.Tasks;
using KBS.TestCases.Configuration;

namespace KBS.Benchmark.States
{
    public class WaitingForMessages : IBenchmarkStep
    {
        public async void Next(BenchmarkStateContext benchmarkStateContext)
        {
            var receiveMessagesTask = CheckIfAllMessagesAreReceived();
            var benchmarkTimeout = BenchmarkTimeout(benchmarkStateContext.Context.TestCaseConfiguration.Timeout);

            if (await Task.WhenAny(receiveMessagesTask, benchmarkTimeout) == benchmarkTimeout)
            {
                Console.WriteLine("Receiving timed out");
            }

            benchmarkStateContext.Next(new Cleanup());
        }

        private static async Task BenchmarkTimeout(TimeSpan timeSpan)
        {
            await Task.Delay(timeSpan);
        }

        private static async Task CheckIfAllMessagesAreReceived()
        {
//            var testCaseConfiguration = new TestCaseConfiguration();
//            var messageCaptureContext = new TestCaseConfiguration();
//
//            while (messageCaptureContext.ReceivedMessages < testCaseConfiguration.MessagesCount)
            while(true)
            {
                await Task.Delay(500);
            }
        }
    }
}
