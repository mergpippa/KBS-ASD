using System;
using KBS.Infrastructure.Models;
using KBS.Infrastructure.Resources;

namespace KBS.Infrastructure.States
{
    class RemovingResourceGroupState : ITestEnvironmentContextState
    {
        private readonly string subscriptionId = "60b91b72-e8f0-412f-99af-7349fd751812";
        private readonly string clientId = "15785e10-cd50-4151-89d7-480266cdac81";
        private readonly string clientSecret = "oBexNPcDpVERex0uSFs0YLNMwMn3n3PNvQJTb9sUaAs=";
        private readonly string resourceGroupName = "AJTestCS";
        private readonly string tenantId = "89b6e630-670d-4944-aecf-0056f43045e9";

        public void ProcessState(TestEnvironmentContext context, TestEnvironment testEnvironment)
        {
            Resource_Group.RemoveResourceGroup(tenantId, clientId, clientSecret, subscriptionId, resourceGroupName);
        }
    }
}
