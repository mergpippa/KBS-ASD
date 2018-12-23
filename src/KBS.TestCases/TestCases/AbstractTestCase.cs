using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;

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
            // Make sure that this method runs asynchronous
            await Task.Yield();

            var startTime = DateTime.Now;
            
            // Track event on benchmark start
//            TelemetryClient.TrackEvent(
//                "benchmark_start",
//                new Dictionary<string, string>
//                {
//                    { "startTime", startTime.ToString() }
//                }
//            );


            // Force this method to run asynchronously

            var tasks = new Task[_testCaseConfiguration.MessagesCount];

            for (var i = 0; i < _testCaseConfiguration.MessagesCount; i++)
            {
                tasks[i] = callback(i);
            }

            Task.WaitAll(tasks);

            // Track event on benchmark end
//            TelemetryClient.TrackEvent(
//                "benchmark_end",
//                new Dictionary<string, string>
//                {
//                    { "endTime", (DateTime.Now - startTime).ToString() }
//                }
//            );

            Console.WriteLine($"Benchmark completed in: {DateTime.Now - startTime}");
        }
    }
}
