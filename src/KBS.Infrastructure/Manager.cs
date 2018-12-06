using System.Collections.Generic;
using System.Threading.Tasks;
using KBS.Infrastructure.Models;
using KBS.Infrastructure.State;

namespace KBS.Infrastructure
{
    public class Manager : IManager
    {
        private readonly List<TestEnvironmentContext> _testEnvironments = new List<TestEnvironmentContext>();

        /// <summary>
        /// Creates a test environment with the given configuration
        /// </summary>
        /// <param name="configuration"></param>
        public Task<TestEnvironmentContext> CreateTestEnvironmentAsync(TestConfiguration configuration) =>
            Task.Run(() =>
            {
                var testEnvironment = new TestEnvironmentContext(configuration);
                _testEnvironments.Add(new TestEnvironmentContext(configuration));

                return testEnvironment;
            });
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public Task<TestEnvironmentContext> GetTestEnvironmentAsync(string name) => 
            Task.Run(() => _testEnvironments.Find(
                testEnvironment => testEnvironment.Configuration.Name == name
            ));


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<TestEnvironmentContext>> GetTestEnvironmentsAsync() =>
            Task.Run(() => _testEnvironments);
    }
}
