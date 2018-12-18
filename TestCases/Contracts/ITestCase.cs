using System.Threading.Tasks;
using KBS.MessageBus;
using KBS.MessageBus.Configurator;

namespace KBS.TestCases.Contracts
{
    public interface ITestCase : IMessageBusEndpointConfigurator
    {
        Task Run(BusControl busControl, TestCaseConfiguration testCaseConfiguration);
    }
}
