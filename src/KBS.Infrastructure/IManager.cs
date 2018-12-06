using System.Collections.Generic;
using System.Threading.Tasks;
using KBS.Infrastructure.Models;

namespace KBS.Infrastructure
{
    public interface IManager
    {
        /// <summary>
        /// Get currently running tests
        /// </summary>
        Task<IList<ITestEnvironment>> GetTests();

        /// <summary>
        /// Gets test status of test with given identifier
        /// </summary>
        /// <param name="identifier"></param>
        Task<ITestEnvironment> GetTest(string name);

        /// <summary>
        /// Creates a test environment with the given configuration
        /// </summary>
        /// <param name="configuration"></param>
        Task<ITestEnvironment> CreateTest(ITestConfiguration configuration);
    }
}
