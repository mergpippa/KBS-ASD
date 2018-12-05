using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KBS.FauxApplication;

namespace KBS.Infrastructure
{
    public class Manager : IManager
    {
        private readonly List<TestEnvironment> _testEnvironments;
        
        /// <summary>
        /// Creates a test environment with the given configuration
        /// </summary>
        /// <param name="configuration"></param>
        public Task<TestEnvironment> CreateTest(ITestConfiguration configuration) => 
            new Task<TestEnvironment>(() =>
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
        public Task<TestEnvironment> GetTest(string testName) =>
            new Task<TestEnvironment>(() => 
                _testEnvironments.Find(testEnvironment => testEnvironment.Name == testName)
            );

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<TestEnvironment>> GetTests() =>
            new Task<List<TestEnvironment>>(() => _testEnvironments);
    }
}
