using KBS.TestCases.TestCases;
using KBS.TestCases.TestCases.ConsumeConsumer;
using KBS.TestCases.TestCases.RequestResponse;
using KBS.TestCases.TestCases.Webshop;
using Xunit;

namespace KBS.TestCasesTests
{
    public class TestCasesTests
    {
        [Fact]
        public void Should_BeOfTypeTestCase_When_CreatingRequestResponseTestCase()
        {
            var testCase = new RequestResponseTestCase(null);

            Assert.IsAssignableFrom<TestCase>(testCase);
        }

        [Fact]
        public void Should_BeOfTypeTestCase_When_CreatingConsumeConsumerTestCase()
        {
            var testCase = new ConsumeConsumerTestCase(null);

            Assert.IsAssignableFrom<TestCase>(testCase);
        }

        [Fact]
        public void Should_BeOfTypeTestCase_When_CreatingWebshopTestCase()
        {
            var testCase = new WebshopTestCase(null);

            Assert.IsAssignableFrom<TestCase>(testCase);
        }
    }
}
