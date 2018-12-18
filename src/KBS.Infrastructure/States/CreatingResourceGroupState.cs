using KBS.Infrastructure.Models;
using KBS.Infrastructure.Resources;

namespace KBS.Infrastructure.States
{
    public class CreatingResourceGroupState : ITestEnvironmentContextState
    {
        public async void ProcessState(TestEnvironmentContext context, TestEnvironment testEnvironment)
        {
            Resource_Group rg = new Resource_Group();
            rg.EnsureResourceGroupExists();

            testEnvironment.Status = Data.TestEnvironmentStatus.CreatedResourceGroup;
            context.SetState(new CreatingAppServiceAppState());
        }
    }
}
