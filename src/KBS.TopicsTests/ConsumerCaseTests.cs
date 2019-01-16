using System;
using KBS.Topics;
using Xunit;

namespace KBS.TopicsTests
{
    public class ConsumerCaseTests
    {
        private class ConsumeMessageTest : Topics.ConsumerCase.IConsumeMessage
        {
            public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public Type TestCase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public byte[] Filler => throw new NotImplementedException();
        }

        [Fact]
        public void IConsumeMessageShouldExtendIMessageDiagnostics()
        {
            Assert.IsAssignableFrom<IMessageDiagnostics>(new ConsumeMessageTest());
        }
    }
}
