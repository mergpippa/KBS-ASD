using System.Threading.Tasks;
using KBS.Benchmark.States;

namespace KBS.Benchmark
{
    public class Benchmark
    {
        /// <summary>
        /// Variable that represents the current state
        /// </summary>
        private IBenchmarkStep _currentState;

        /// <summary>
        /// Current benchmark context
        /// </summary>
        public BenchmarkContext Context;

        public async Task Run()
        {
            Context = new BenchmarkContext();

            await SetNext(new CreateTelemetryClient());
        }

        /// <summary>
        /// Method used to go to the next step of the benchmark
        /// </summary>
        /// <param name="newState">
        /// </param>
        public async Task SetNext(IBenchmarkStep newState)
        {
            _currentState = newState;

            // Process next step automatically
            await _currentState.Next(this);
        }
    }
}
