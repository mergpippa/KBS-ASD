using System.Collections.Generic;
using System.Threading.Tasks;
using KBS.Infrastructure.Models;
using KBS.Infrastructure.States;

namespace KBS.Infrastructure
{
    public class Manager : IManager
    {
        private readonly List<TestEnvironment> _testEnvironments = new List<TestEnvironment>();

        /// <summary>
        /// Creates a test environment with the given configuration
        /// </summary>
        /// <param name="configuration"></param>
        public TestEnvironment CreateTestEnvironment(TestConfiguration configuration)
        {
            var testEnvironment = new TestEnvironment(configuration);
            _testEnvironments.Add(testEnvironment);

            // Run TestEnvironmentContext on a different thread since it'll take a while to finish
            Task.Run(() => new TestEnvironmentContext(testEnvironment, new InitialState()));

            return testEnvironment;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public TestEnvironment GetTestEnvironment(string name) =>
            _testEnvironments.Find(
                testEnvironment => testEnvironment.Configuration.Name == name
            );


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TestEnvironment> GetTestEnvironments() =>
            _testEnvironments;
    }
}
