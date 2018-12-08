using KBS.Infrastructure.Models;

namespace KBS.Infrastructure.States
{
    public class InitialState : ITestEnvironmentContextState
    {
        public void ProcessState(TestEnvironmentContext context, TestEnvironment testEnvironment)
        {
            testEnvironment.Status = Data.TestEnvironmentStatus.Initial;

            context.SetState(new CreatingResourceGroupState());
        }
    }
}
