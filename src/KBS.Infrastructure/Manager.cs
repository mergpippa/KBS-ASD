using System.Collections.Generic;
using System.Threading.Tasks;
using KBS.Infrastructure.Models;

namespace KBS.Infrastructure
{
    public class Manager : IManager
    {
        private readonly List<TestEnvironment> _testEnvironments;
        
        /// <summary>
        /// Creates a test environment with the given configuration
        /// </summary>
        /// <param name="configuration"></param>
        public Task<ITestEnvironment> CreateTest(ITestConfiguration configuration) => 
            new Task<ITestEnvironment>(() =>
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
        public Task<ITestEnvironment> GetTest(string name) =>
            new Task<ITestEnvironment>(() => 
                _testEnvironments.Find(testEnvironment => testEnvironment.Configuration.Name == name)
            );

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<IList<ITestEnvironment>> GetTests() =>
            new Task<IList<ITestEnvironment>>(() => (IList<ITestEnvironment>) _testEnvironments);
    }
}
