using System;

namespace KBS.TestCases.Configuration
{
    internal static class TestCaseConfigurationEnvironmentVariables
    {
        public const string Clients = "TEST_CASE_CLIENTS";

        public const string MessageCount = "TEST_CASE_MESSAGE_COUNT";

        public const string FillerSize = "TEST_CASE_FILLER_SIZE";

        public const string Timeout = "TEST_CASE_TIMEOUT";
    }

    public static class TestCaseConfigurationExtensionMethods
    {
        public static void FillUsingEnvironment(this TestCaseConfiguration testCaseConfiguration)
        {
            string GetVar(string variableName) => Environment.GetEnvironmentVariable(variableName);

            if (int.TryParse(
                GetVar(TestCaseConfigurationEnvironmentVariables.Clients),
                out var clients
            ))
            {
                testCaseConfiguration.Clients = clients;
            }

            if (int.TryParse(
                GetVar(TestCaseConfigurationEnvironmentVariables.MessageCount),
                out var messageCount
            ))
            {
                testCaseConfiguration.MessagesCount = messageCount;
            }

            if (int.TryParse(
                GetVar(TestCaseConfigurationEnvironmentVariables.FillerSize),
                out var fillerSize
            ))
            {
                testCaseConfiguration.FillerSize = fillerSize;
            }

            if (int.TryParse(
                GetVar(TestCaseConfigurationEnvironmentVariables.Timeout),
                out var timeout
            ))
            {
                testCaseConfiguration.Timeout = TimeSpan.FromSeconds(timeout);
            }
        }
    }
}
