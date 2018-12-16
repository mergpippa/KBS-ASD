using System;
using KBS.FauxApplication.TestCases.RequestResponse;
using KBS.FauxApplication.TestCases.Webshop;
using KBS.MessageBus.Configurator;

namespace KBS.FauxApplication.TestCases
{
    internal enum TestCaseType
    {
        // Request response test case
        RequestResponse = 0,

        // Real world test case
        Webshop = 1,
    }

    internal static class TestCaseFactory
    {
        public static ITestCase Create(TestCaseType testCaseType)
        {
            switch (testCaseType)
            {
                case TestCaseType.RequestResponse:
                    return new RequestResponseTestCase();

                case TestCaseType.Webshop:
                    return new WebshopTestCase();
            }

            throw new UnknownTestCaseException(testCaseType.ToString());
        }
    }

    /// <summary>
    /// Exception used when test case does not exist
    /// </summary>
    internal class UnknownTestCaseException : Exception
    {
        public UnknownTestCaseException(string testCaseType)
            : base($"Unknown test case type {testCaseType}")
        { }
    }
}
