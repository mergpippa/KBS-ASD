using System;
using KBS.Infrastructure.Models;

namespace KBS.Infrastructure.States
{
    class DeployedApplicationToWebJobState : ITestEnvironmentContextState
    {
        public void ProcessState(TestEnvironmentContext context, TestEnvironment testEnvironment)
        {
            throw new NotImplementedException();
        }
    }
}
