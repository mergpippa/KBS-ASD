using KBS.Infrastructure.Data;
using KBS.Infrastructure.Models;
using System;

namespace KBS.Infrastructure.State
{
    public interface ITestEnvironmentContext
    {
        ITestConfiguration Configuration { get; }
        TestEnvironmentState Status { get; }

        DateTime CreatedAtUTC { get; }
    }
}
