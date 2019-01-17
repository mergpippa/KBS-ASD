using System;
using System.Collections.Generic;
using KBS.Topics;
using KBS.Topics.WebshopCase;
using Xunit;

namespace KBS.TopicsTests
{
    public class WebshopCaseTests
    {
        #region Test messages

        private class CatalogueReplyTest : ICatalogueReply
        {
            public Dictionary<string, int> Catalogue => throw new NotImplementedException();

            public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public Type TestCase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public byte[] Filler => throw new NotImplementedException();
        }

        private class CatalogueRequestTest : ICatalogueRequest
        {
            public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public Type TestCase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public byte[] Filler => throw new NotImplementedException();
        }

        private class OrderTest : IOrder
        {
            public string ItemName => throw new NotImplementedException();

            public int Quantity => throw new NotImplementedException();

            public ITransaction Purchase => throw new NotImplementedException();

            public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public Type TestCase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public byte[] Filler => throw new NotImplementedException();
        }

        private class TransactionTest : ITransaction
        {
            public uint AccountId => throw new NotImplementedException();

            public int Withdrawal => throw new NotImplementedException();

            public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public Type TestCase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public byte[] Filler => throw new NotImplementedException();
        }

        private class TransactionValidationTest : ITransactionValidation
        {
            public ITransaction Transaction => throw new NotImplementedException();

            public bool IsValid => throw new NotImplementedException();

            public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public Type TestCase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public byte[] Filler => throw new NotImplementedException();
        }

        #endregion Test messages

        #region Unit tests

        [Fact]
        public void ICatalogueReplyShouldExtendIMessageDiagnostics()
        {
            Assert.IsAssignableFrom<IMessageDiagnostics>(new CatalogueReplyTest());
        }

        [Fact]
        public void ICatalogueRequestShouldExtendIMessageDiagnostics()
        {
            Assert.IsAssignableFrom<IMessageDiagnostics>(new CatalogueRequestTest());
        }

        [Fact]
        public void IOrderShouldExtendIMessageDiagnostics()
        {
            Assert.IsAssignableFrom<IMessageDiagnostics>(new OrderTest());
        }

        [Fact]
        public void ITransactionShouldExtendIMessageDiagnostics()
        {
            Assert.IsAssignableFrom<IMessageDiagnostics>(new TransactionTest());
        }

        [Fact]
        public void ITransactionValidationShouldExtendIMessageDiagnostics()
        {
            Assert.IsAssignableFrom<IMessageDiagnostics>(new TransactionValidationTest());
        }

        #endregion Unit tests
    }
}
