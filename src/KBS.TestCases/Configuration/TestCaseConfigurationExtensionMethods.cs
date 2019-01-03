using System;
using System.IO;
using KBS.Data.Constants;
using KBS.Data.Enum;
using Newtonsoft.Json;

namespace KBS.TestCases.Configuration
{
    internal static class TestCaseConfigurationEnvironmentVariables
    {
    }

    public static class TestCaseConfigurationExtensionMethods
    {
        /// <summary>
        /// Fill configuration using system environment
        /// </summary>
        /// <param name="testCaseConfiguration">
        /// </param>
        public static void FillUsingEnvironment(this TestCaseConfiguration testCaseConfiguration)
        {
            string GetVar(string variableName) => Environment.GetEnvironmentVariable(variableName);

            if (int.TryParse(
                GetVar(EnvironmentVariables.TestCaseType),
                out var testCaseType
            ))
            {
                testCaseConfiguration.TestCaseType = (TestCaseType)testCaseType;
            }

            if (int.TryParse(
                GetVar(EnvironmentVariables.TelemetryClientType),
                out var telemetryClientType
            ))
            {
                testCaseConfiguration.TelemetryClientType = (TelemetryClientType)telemetryClientType;
            }

            if (int.TryParse(
                GetVar(EnvironmentVariables.Clients),
                out var clients
            ))
            {
                testCaseConfiguration.Clients = clients;
            }

            if (int.TryParse(
                GetVar(EnvironmentVariables.MessageCount),
                out var messageCount
            ))
            {
                testCaseConfiguration.MessagesCount = messageCount;
            }

            if (int.TryParse(
                GetVar(EnvironmentVariables.FillerSize),
                out var fillerSize
            ))
            {
                testCaseConfiguration.FillerSize = fillerSize;
            }

            if (int.TryParse(
                GetVar(EnvironmentVariables.Timeout),
                out var timeout
            ))
            {
                testCaseConfiguration.BenchmarkTimeout = TimeSpan.FromSeconds(timeout);
            }
        }

        /// <summary>
        /// Fill configuration using testCaseConfiguration.json in the root directory
        /// </summary>
        /// <param name="testCaseConfiguration">
        /// </param>
        public static void FillUsingConfigurationFile(this TestCaseConfiguration testCaseConfiguration, string path)
        {
            TestCaseConfiguration configurationFile;

            using (var streamReader = new StreamReader(path))
            {
                configurationFile = JsonConvert.DeserializeObject<TestCaseConfiguration>(streamReader.ReadToEnd());
            }

            ValidateConfiguration(configurationFile);

            if (configurationFile.Clients != default(int))
                testCaseConfiguration.Clients = configurationFile.Clients;

            if (configurationFile.TestCaseType != default(int))
                testCaseConfiguration.TestCaseType = configurationFile.TestCaseType;

            if (configurationFile.TelemetryClientType != default(int))
                testCaseConfiguration.TelemetryClientType = configurationFile.TelemetryClientType;

            if (configurationFile.Clients != default(int))
                testCaseConfiguration.Clients = configurationFile.Clients;

            if (configurationFile.MessagesCount != default(int))
                testCaseConfiguration.MessagesCount = configurationFile.MessagesCount;

            if (configurationFile.FillerSize != default(int))
                testCaseConfiguration.FillerSize = configurationFile.FillerSize;

            if (configurationFile.BenchmarkTimeout != default(TimeSpan))
                testCaseConfiguration.BenchmarkTimeout = configurationFile.BenchmarkTimeout;
        }

        private static void ValidateConfiguration(TestCaseConfiguration configurationFile)
        {
            if (configurationFile.MessagesCount % configurationFile.Clients != 0) { throw new Exception(); }
        }
    }
}
