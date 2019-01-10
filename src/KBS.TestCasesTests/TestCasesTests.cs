using System;
using KBS.TestCases.TestCases;
using Xunit;

namespace KBS.TestCasesTests
{
    public class TestCasesTests
    {
        [Fact]
        public void RequestResponseTestCaseShouldExtendTestCase()
        {
            Assert.IsAssignableFrom<TestCase>(new TestCases.TestCases.RequestResponse.RequestResponseTestCase(null));
        }

        [Fact]
        public void ConsumeConsumerTestCaseShouldExtendTestCase()
        {
            Assert.IsAssignableFrom<TestCase>(new TestCases.TestCases.ConsumeConsumer.ConsumeConsumerTestCase(null));
        }

        [Fact]
        public void WebshopTestCaseShouldExtendTestCase()
        {
            Assert.IsAssignableFrom<TestCase>(new TestCases.TestCases.Webshop.WebshopTestCase(null));
        }
    }
}
