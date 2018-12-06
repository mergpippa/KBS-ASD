using KBS.Infrastructure.Data;
using KBS.Infrastructure.Models;
using System;

namespace KBS.Infrastructure.State
{
    public class TestEnvironmentContext : ITestEnvironmentContext

    {
        public ITestConfiguration Configuration { get; }
        public TestEnvironmentState Status { get; }
        public DateTime StartTime { get; }

        public TestEnvironmentContext(ITestConfiguration configuration)
        {
            Configuration = configuration;
            Status = TestEnvironmentState.Initial;

            StartTime = DateTime.UtcNow;
        }
    }
}
