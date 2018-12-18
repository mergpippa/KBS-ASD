using System;
using KBS.TestCases.Contracts;
using KBS.TestCases.TestCases.RequestResponse;
using KBS.TestCases.TestCases.Webshop;

namespace KBS.TestCases
{
    public enum TestCaseType
    {
        /// <summary>
        /// Request response test case
        /// </summary>
        RequestResponse = 0,

        /// <summary>
        /// Real world test case
        /// </summary>
        Webshop = 1,
    }

    public static class TestCaseFactory
    {
        public static ITestCase Create(TestCaseType testCaseType)
        {
            switch (testCaseType)
            {
                case TestCaseType.RequestResponse:
                    return new RequestResponseTestCase();

                case TestCaseType.Webshop:
                    return new WebshopTestCase();

                default:
                    throw new ArgumentOutOfRangeException(nameof(testCaseType), testCaseType, null);
            }
        }
    }
}