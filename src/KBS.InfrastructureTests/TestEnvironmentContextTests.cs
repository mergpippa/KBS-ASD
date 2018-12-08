using KBS.Infrastructure;
using KBS.Infrastructure.Data;
using KBS.Infrastructure.Models;
using KBS.Infrastructure.States;
using Xunit;

namespace KBS.InfrastructureTests
{
    /// <summary>
    /// Test state class, only used for testing purposes
    /// </summary>
    class InitialTestState : ITestEnvironmentContextState
    {
        public void ProcessState(TestEnvironmentContext context, TestEnvironment testEnvironment) =>
            context.SetState(new FinalTestState()); // Go to final state
    }

    /// <summary>
    /// Test state class, only used for testing purposes
    /// </summary>
    class FinalTestState : ITestEnvironmentContextState
    {
        public void ProcessState(TestEnvironmentContext context, TestEnvironment testEnvironment) =>
            testEnvironment.Status = TestEnvironmentStatus.TriggeredWebJob;
    }

    public class TestEnvironmentContextTests
    {
        [Fact]
        public void Should_SetState()
        {
            var testEnvironmentContext = new TestEnvironmentContext(
                new TestEnvironment(new TestConfiguration()),
                new InitialTestState()
            );

            Assert.Equal(TestEnvironmentStatus.TriggeredWebJob, testEnvironmentContext.TestEnvironment.Status);
        }
    }
}
