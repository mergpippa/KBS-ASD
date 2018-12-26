using KBS.Benchmark.States;
using KBS.TestCases.Configuration;

namespace KBS.Benchmark
{
    public class BenchmarkStateContext
    {
        /// <summary>
        /// Variable that represents the current state
        /// </summary>
        private IBenchmarkStep _currentState;

        /// <summary>
        /// 
        /// </summary>
        public readonly BenchmarkContext Context;

        /// <summary>
        /// TestCaseContext constructor
        /// </summary>
        public BenchmarkStateContext(TestCaseConfiguration testCaseConfiguration)
        {
            Context = new BenchmarkContext { TestCaseConfiguration = testCaseConfiguration };

            Next(new Initialize());
        }

        /// <summary>
        /// TestCaseContext constructor
        /// </summary>
        public BenchmarkStateContext()
        {
            Context = new BenchmarkContext();

            Next(new GetConfiguration());
        }

        /// <summary>
        /// Method used to update the state of the TestCaseContext
        /// </summary>
        /// <param name="newState"></param>
        public void Next(IBenchmarkStep newState)
        {
            _currentState = newState;

            // Process next step automatically
            _currentState.Next(this);
        }
    }
}
