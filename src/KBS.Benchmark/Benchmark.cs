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

        /// <summary>
        /// Benchmark constructor
        /// </summary>
        public Benchmark()
        {
            Context = new BenchmarkContext();

            Next(new GetConfiguration());
        }

        /// <summary>
        /// Method used to go to the next step of the benchmark
        /// </summary>
        /// <param name="newState">
        /// </param>
        public void Next(IBenchmarkStep newState)
        {
            _currentState = newState;

            // Process next step automatically
            _currentState.Next(this);
        }
    }
}
