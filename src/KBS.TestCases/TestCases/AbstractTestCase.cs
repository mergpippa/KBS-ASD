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
                callback(index);

                await Task.Delay(messageInterval);
            }

            Console.WriteLine("Ending benchmark");
        }
    }
}
