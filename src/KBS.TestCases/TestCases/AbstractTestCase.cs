using System;
using System.Threading.Tasks;

namespace KBS.TestCases.TestCases
{
    public abstract class AbstractTestCase
    {
        private TestCaseConfiguration _testCaseConfiguration;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="testCaseConfiguration"></param>
        protected AbstractTestCase(TestCaseConfiguration testCaseConfiguration)
        {
            _testCaseConfiguration = testCaseConfiguration;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        protected async Task Benchmark(Func<int, Task> callback)
        {
            // Force this method to run asynchronously
            await Task.Yield();

            var messageInterval = (int) (_testCaseConfiguration.MessagesCount / _testCaseConfiguration.Duration.TotalMilliseconds);
            
            for (var index = 0; index < _testCaseConfiguration.MessagesCount; index++)
            {
                callback(index);

                await Task.Delay(messageInterval);
            }
        }
    }
}
