using KBS.Infrastructure.Models;

namespace KBS.Infrastructure.States
{
    public interface ITestEnvironmentContextState
    {
        void ProcessState(TestEnvironmentContext context, TestEnvironment testEnvironment);
    }
}
