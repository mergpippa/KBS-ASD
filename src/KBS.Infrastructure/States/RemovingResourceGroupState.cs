using KBS.Infrastructure.Models;
using KBS.Infrastructure.Resources;

namespace KBS.Infrastructure.States
{
    internal class RemovingResourceGroupState : ITestEnvironmentContextState
    {
        public void ProcessState(TestEnvironmentContext context, TestEnvironment testEnvironment)
        {
            Resource_Group rg = new Resource_Group();
            rg.RemoveResourceGroup();

            // TODO end state
        }
    }
}
