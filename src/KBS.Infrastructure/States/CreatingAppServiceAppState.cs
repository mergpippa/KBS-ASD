using System;
using System.IO;
using KBS.Infrastructure.Models;
using KBS.Infrastructure.Resources;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.Azure.Authentication;

using KBS.Infrastructure.Resources;

namespace KBS.Infrastructure.States
{
    internal class CreatingAppServiceAppState : ITestEnvironmentContextState
    {
        public void ProcessState(TestEnvironmentContext context, TestEnvironment testEnvironment)
        {
            AppServiceApp apa = new AppServiceApp();
            apa.DeployTemplate();

            // TODO go to next step
        }
    }
}
