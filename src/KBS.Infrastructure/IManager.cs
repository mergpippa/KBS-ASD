using System;
using System.Collections.Generic;
using KBS.FauxApplication;

namespace KBS.Infrastructure
{
    public interface IManager
    {
        /// <summary>
        /// Get currently running tests
        /// </summary>
        Task<List<TestEnviroment>> GetTests();

        /// <summary>
        /// Gets test status of test with given identifier
        /// </summary>
        /// <param name="identifier"></param>
        Task<TestEnviroment> GetTest(int identifier);

        /// <summary>
        /// Creates a test environment with the given configuration
        /// </summary>
        /// <param name="configuration"></param>
        Task CreateTest(ITestConfiguration configuration);
    }
}
