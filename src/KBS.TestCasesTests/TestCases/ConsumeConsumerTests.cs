using KBS.TestCases.TestCases.ConsumeConsumer.Consumers;
using MassTransit;
using Xunit;

namespace KBS.TestCasesTests.TestCases
{
    public class ConsumeConsumerTests
    {
        [Fact]
        public void Should_BeTypeOfIConsumer()
        {
            var consumer = new ConsumeConsumer();

            Assert.IsAssignableFrom<IConsumer>(consumer);
        }
    }
}
