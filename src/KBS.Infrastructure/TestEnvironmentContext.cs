using System;
using KBS.Infrastructure.Models;
using KBS.Infrastructure.States;

namespace KBS.Infrastructure
{
    public class TestEnvironmentContext
    {
        /// <summary>
        /// The TestEnvironment model
        /// </summary>
        public TestEnvironment TestEnvironment;

        /// <summary>
        /// Variable that represents the current state
        /// </summary>
        private ITestEnvironmentContextState _currentState;

        /// <summary>
        /// TestEnvironmentContext constructor
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="initialState"></param>
        public TestEnvironmentContext(TestEnvironment testEnvironment, ITestEnvironmentContextState initialState)
        {
            TestEnvironment = testEnvironment;

            SetState(initialState);
        }

        /// <summary>
        /// Method used to update the state of the TestEnvironmentContext
        /// </summary>
        /// <param name="newState"></param>
        public void SetState(ITestEnvironmentContextState newState)
        {
            _currentState = newState;

            // Process next step automatically
            _currentState.ProcessState(this, TestEnvironment);
        }
    }
}
