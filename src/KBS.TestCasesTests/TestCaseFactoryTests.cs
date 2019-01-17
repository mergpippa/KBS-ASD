using System;
using KBS.Data.Enum;
using KBS.TestCases;
using KBS.TestCases.TestCases.ConsumeConsumer;
using KBS.TestCases.TestCases.RequestResponse;
using KBS.TestCases.TestCases.Webshop;
using Xunit;

namespace KBS.TestCasesTests
{
    public class TestCaseFactoryTests
    {
        [Fact]
        public void Should_CreateTestsCaseOfTypeRequestResponse()
        {
            var testCase = TestCaseFactory.Create(TestCaseType.RequestResponse, null);

            Assert.IsType<RequestResponseTestCase>(testCase);
        }

        [Fact]
        public void Should_CreateTestsCaseOfTypeConsumeConsumer()
        {
            var testCase = TestCaseFactory.Create(TestCaseType.ConsumeConsumer, null);

            Assert.IsType<ConsumeConsumerTestCase>(testCase);
        }

        [Fact]
        public void Should_CreateTestsCaseOfTypeWebShop()
        {
            var testCase = TestCaseFactory.Create(TestCaseType.WebShop, null);

            Assert.IsType<WebshopTestCase>(testCase);
        }

        [Fact]
        public void Should_ThrowErrorWhenTryingToCreateUndefinedTestCase()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => TestCaseFactory.Create(0, null));
        }
    }
}
