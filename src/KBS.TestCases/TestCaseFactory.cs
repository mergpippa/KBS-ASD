using System;
using KBS.Data.Enum;
using KBS.Telemetry;
using KBS.TestCases.Configuration;
using KBS.TestCases.TestCases;
using KBS.TestCases.TestCases.RequestResponse;
using KBS.TestCases.TestCases.Webshop;

namespace KBS.TestCases
{
    public static class TestCaseFactory
    {
        public static TestCase Create(TestCaseType testCaseType, TestCaseConfiguration testCaseConfiguration, ITelemetryClient telemetryClient)
        {
            switch (testCaseType)
            {
                case TestCaseType.RequestResponse:
                    return new RequestResponseTestCase(testCaseConfiguration, telemetryClient);

                case TestCaseType.WebShop:
                    return new WebshopTestCase(testCaseConfiguration, telemetryClient);

                default:
                    throw new ArgumentOutOfRangeException(nameof(testCaseType), testCaseType, null);
            }
        }
    }
}
