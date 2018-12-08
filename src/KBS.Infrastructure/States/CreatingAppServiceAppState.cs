using System;
using KBS.Infrastructure.Models;

namespace KBS.Infrastructure.States
{
    class CreatingAppServiceAppState : ITestEnvironmentContextState
    {
        public void ProcessState(TestEnvironmentContext context, TestEnvironment testEnvironment)
        {
            throw new NotImplementedException();
        }
    }
}
