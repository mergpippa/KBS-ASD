using System;
using KBS.Data.Enum;
using KBS.MessageBus;
using KBS.TestCases.TestCases;
using KBS.TestCases.TestCases.ConsumeConsumer;
using KBS.TestCases.TestCases.RequestResponse;
using KBS.TestCases.TestCases.Webshop;

namespace KBS.TestCases
{
    public static class TestCaseFactory
    {
        /// <summary>
        /// Create TestCase of given test case type
        /// </summary>
        /// <param name="testCaseType">
        /// </param>
        /// <param name="messageCaptureContext">
        /// </param>
        /// <returns>
        /// </returns>
        public static TestCase Create(TestCaseType testCaseType, MessageCaptureContext messageCaptureContext)
        {
            switch (testCaseType)
            {
                case TestCaseType.RequestResponse:
                    return new RequestResponseTestCase(messageCaptureContext);

                case TestCaseType.ConsumeConsumer:
                    return new ConsumeConsumerTestCase(messageCaptureContext);

                case TestCaseType.WebShop:
                    return new WebshopTestCase(messageCaptureContext);

                default:
                    throw new ArgumentOutOfRangeException(nameof(testCaseType), testCaseType, null);
            }
        }
    }
}
