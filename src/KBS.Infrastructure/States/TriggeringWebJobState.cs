using System;
using KBS.Infrastructure.Models;

namespace KBS.Infrastructure.States
{
    class TriggeringWebJob : ITestEnvironmentContextState
    {
        public void ProcessState(TestEnvironmentContext context, TestEnvironment testEnvironment)
        {
            throw new NotImplementedException();
        }
    }
}
