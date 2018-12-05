using System.Collections.Generic;
using System.Threading.Tasks;
using KBS.FauxApplication;

namespace KBS.Infrastructure
{
    public interface IManager
    {
        /// <summary>
        /// Get currently running tests
        /// </summary>
        Task<List<TestEnvironment>> GetTests();

        /// <summary>
        /// Gets test status of test with given identifier
        /// </summary>
        /// <param name="identifier"></param>
        Task<TestEnvironment> GetTest(string testName);

        /// <summary>
        /// Creates a test environment with the given configuration
        /// </summary>
        /// <param name="configuration"></param>
        Task<TestEnvironment> CreateTest(ITestConfiguration configuration);
    }
}
