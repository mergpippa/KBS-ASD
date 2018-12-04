using System;
using KBS.FauxApplication;

namespace KBS.Infrastructure
{
    public class Manager: IManager
    {
        /// <summary>
        /// Gets the current state of the test
        /// </summary>
        /// <returns>The state.</returns>
        public string GetState()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Starts the test based on the configuration.
        /// </summary>
        /// <param name="configuration">Configuration of the test.</param>
        public void StartTest(ITestConfiguration configuration)
        {
            throw new NotImplementedException();
        }
    }
}
