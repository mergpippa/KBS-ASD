using System.Threading.Tasks;
using KBS.FauxApplication.Model;
using KBS.MessageBus;
using MassTransit;

namespace KBS.FauxApplication.TestCases.RequestResponse
{
    internal class RequestResponseTestCase : ITestCase
    {
        public void ConfigureEndpoints(IBusFactoryConfigurator busFactoryConfigurator)
        {
            throw new System.NotImplementedException();
        }

        public Task Run(BusControl busControl, TestConfiguration testConfiguration)
        {
            throw new System.NotImplementedException();
        }
    }
}
