using KBS.Infrastructure.Data;
using System;

namespace KBS.Infrastructure.Models
{
    public class TestEnvironment : ITestEnvironment
    {
        public ITestConfiguration Configuration { get; }
        public TestEnvironmentState Status { get; }
        public DateTime StartTime { get; }

        public TestEnvironment(ITestConfiguration configuration)
        {
            Configuration = configuration;
            Status = TestEnvironmentState.Initial;

            StartTime = new DateTime();
        }
    }
}
