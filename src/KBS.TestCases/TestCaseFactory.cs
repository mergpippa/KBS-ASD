using System;
using KBS.TestCases.Configuration;
using KBS.TestCases.TestCases;
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
        WebShop = 1,
    }

    public static class TestCaseFactory
    {
        public static TestCase Create(TestCaseType testCaseType, TestCaseConfiguration testCaseConfiguration)
        {
            switch (testCaseType)
            {
                case TestCaseType.RequestResponse:
                    return new RequestResponseTestCase(testCaseConfiguration);

                case TestCaseType.WebShop:
                    return new WebshopTestCase(testCaseConfiguration);

                default:
                    throw new ArgumentOutOfRangeException(nameof(testCaseType), testCaseType, null);
            }
        }
    }
}
