using KBS.FauxApplication;
using KBS.Infrastructure.Resources;
using System;

namespace KBS.Infrastructure
{
    public class TestEnvironment : ITestEnvironment
    {
        private readonly ITestConfiguration configuration;

        public TestEnvironment(ITestConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string Name { get; set; }

        public TestEnvironmentState Status { get; set; }

        public DateTime StartTime { get; set; }
    }
}
