using System;
using System.Threading.Tasks;

namespace KBS.TestCases.TestCases
{
    /// <summary>
    /// Abstract test case with a method that is used to run the benchmark
    /// </summary>
    public abstract class AbstractTestCase
    {
        private readonly TestCaseConfiguration _testCaseConfiguration;

        /// <summary>
        /// Abstract class with a Benchmark method that is used to call a callback on given test parameters
        /// </summary>
        /// <param name="testCaseConfiguration">
        /// </param>
        protected AbstractTestCase(TestCaseConfiguration testCaseConfiguration)
        {
            _testCaseConfiguration = testCaseConfiguration;
        }

        /// <summary>
        /// Method used to benchmark a service bus. This method calls a function that should send a
        /// message to the message bus. The frequency and amount of messages that are sent should be
        /// configured in the TestCaseConfiguration
        /// </summary>
        /// <param name="callback">
        /// </param>
        /// <returns>
        /// </returns>
        protected async Task Benchmark(Func<int, Task> callback)
        {
            Console.WriteLine("Starting benchmark");

            // Force this method to run asynchronously
            await Task.Yield();

            var messageInterval = (int)(_testCaseConfiguration.Duration.TotalMilliseconds / _testCaseConfiguration.MessagesCount);

            for (var index = 0; index < _testCaseConfiguration.MessagesCount; index++)
            {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                callback(index);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

                await Task.Delay(messageInterval);
            }

            Console.WriteLine("Ending benchmark");
        }
    }
}
