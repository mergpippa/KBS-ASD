using KBS.Infrastructure.Data;
using System;

namespace KBS.Infrastructure.Models
{
    public interface ITestEnvironment
    {
        ITestConfiguration Configuration { get; }
        TestEnvironmentState Status { get; }

        DateTime StartTime { get; }
    }
}
