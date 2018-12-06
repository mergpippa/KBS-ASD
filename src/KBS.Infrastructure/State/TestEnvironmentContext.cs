using KBS.Infrastructure.Data;
using KBS.Infrastructure.Models;
using System;

namespace KBS.Infrastructure.State
{
    public class TestEnvironmentContext : ITestEnvironmentContext

    {
        public ITestConfiguration Configuration { get; }
        public TestEnvironmentState Status { get; }
        public DateTime CreatedAtUTC { get; }

        public TestEnvironmentContext(ITestConfiguration configuration)
        {
            Configuration = configuration;
            Status = TestEnvironmentState.Initial;

            CreatedAtUTC = DateTime.UtcNow;
        }
    }
}
