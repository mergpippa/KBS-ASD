using System.Collections.Generic;
using System.Threading.Tasks;
using KBS.Infrastructure.Models;

namespace KBS.Infrastructure
{
    public class Manager : IManager
    {
        private readonly List<TestEnvironment> _testEnvironments = new List<TestEnvironment>();

        /// <summary>
        /// Creates a test environment with the given configuration
        /// </summary>
        /// <param name="configuration"></param>
        public Task<TestEnvironment> CreateTestEnvironmentAsync(TestConfiguration configuration) =>
            Task.Run(() =>
            {
                var testEnvironment = new TestEnvironment(configuration);
                _testEnvironments.Add(new TestEnvironment(configuration));

                return testEnvironment;
            });
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public Task<TestEnvironment> GetTestEnvironmentAsync(string name) => 
            Task.Run(() => _testEnvironments.Find(
                testEnvironment => testEnvironment.Configuration.Name == name
            ));


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<TestEnvironment>> GetTestEnvironmentsAsync() =>
            Task.Run(() => _testEnvironments);
    }
}
