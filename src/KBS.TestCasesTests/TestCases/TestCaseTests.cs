using System;
using System.Threading.Tasks;
using KBS.MessageBus;
using KBS.TestCases.TestCases;
using KBS.Topics;
using MassTransit;

namespace KBS.TestCasesTests.TestCases
{
    internal class ConcreteTestCase : TestCase
    {
        protected ConcreteTestCase(MessageCaptureContext messageCaptureContext) : base(messageCaptureContext)
        { }

        public override void ConfigureEndpoints(IBusFactoryConfigurator busFactoryConfigurator)
        {
            throw new NotImplementedException();
        }

        public override Task Run(BusControl busControl)
        {
            throw new NotImplementedException();
        }

        protected override IMessageDiagnostics CreateMessage(int index, byte[] filler = null)
        {
            throw new NotImplementedException();
        }
    }

    internal class TestCaseTests
    {
    }
}
