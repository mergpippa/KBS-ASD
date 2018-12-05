using KBS.Infrastructure.Resources;
using System;

namespace KBS.Infrastructure
{
    public interface ITestEnvironment
    {
        string Name { get; set; }

        TestEnvironmentState Status { get; set; }

        DateTime StartTime { get; set; }
    }
}
