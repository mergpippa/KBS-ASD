using System;
using KBS.Topics;
using Xunit;

namespace KBS.TopicsTests
{
    public class RequestResponseCaseTests
    {
        #region Test request message extention

        private class RequestMessageTest : Topics.RequestResponseCase.IRequestMessage
        {
            public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public Type TestCase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public byte[] Filler => throw new NotImplementedException();
        }

        [Fact]
        public void IRequestMessageShouldExtendIMessageDiagnostics()
        {
            Assert.IsAssignableFrom<IMessageDiagnostics>(new RequestMessageTest());
        }

        #endregion Test request message extention

        #region Test response message extention

        private class ResponseMessageTest : Topics.RequestResponseCase.IResponseMessage
        {
            public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public Type TestCase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public byte[] Filler => throw new NotImplementedException();
        }

        [Fact]
        public void IResponseMessageShouldExtendIMessageDiagnostics()
        {
            Assert.IsAssignableFrom<IMessageDiagnostics>(new ResponseMessageTest());
        }

        #endregion Test response message extention
    }
}
