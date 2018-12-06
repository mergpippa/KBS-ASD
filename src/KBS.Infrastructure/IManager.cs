using System.Collections.Generic;
using System.Threading.Tasks;
using KBS.Infrastructure.Models;
using KBS.Infrastructure.State;

namespace KBS.Infrastructure
{
    public interface IManager
    {
        /// <summary>
        /// Get currently running tests
        /// </summary>
        Task<List<TestEnvironmentContext>> GetTestEnvironmentsAsync();

        /// <summary>
        /// Gets test status of test with given identifier
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="name"></param>
        Task<TestEnvironmentContext> GetTestEnvironmentAsync(string name);

        /// <summary>
        /// Creates a test environment with the given configuration
        /// </summary>
        /// <param name="configuration"></param>
        Task<TestEnvironmentContext> CreateTestEnvironmentAsync(TestConfiguration configuration);
    }
}
