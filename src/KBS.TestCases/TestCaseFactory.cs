using System;
using KBS.Data.Enum;
using KBS.MessageBus;
using KBS.TestCases.Configuration;
using KBS.TestCases.TestCases;
using KBS.TestCases.TestCases.RequestResponse;
using KBS.TestCases.TestCases.Webshop;

namespace KBS.TestCases
{
    public static class TestCaseFactory
    {
        /// <summary>
        /// </summary>
        /// <param name="testCaseType">
        /// </param>
        /// <param name="testCaseConfiguration">
        /// </param>
        /// <param name="messageCaptureContext">
        /// </param>
        /// <returns>
        /// </returns>
        public static TestCase Create(TestCaseType testCaseType, TestCaseConfiguration testCaseConfiguration, MessageCaptureContext messageCaptureContext)
        {
            switch (testCaseType)
            {
                case TestCaseType.RequestResponse:
                    return new RequestResponseTestCase(testCaseConfiguration, messageCaptureContext);

                case TestCaseType.WebShop:
                    return new WebshopTestCase(testCaseConfiguration, messageCaptureContext);

                default:
                    throw new ArgumentOutOfRangeException(nameof(testCaseType), testCaseType, null);
            }
        }
    }
}
