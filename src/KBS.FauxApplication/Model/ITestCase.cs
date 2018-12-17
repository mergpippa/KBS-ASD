using System.Threading.Tasks;
using KBS.MessageBus;
using KBS.MessageBus.Configurator;

namespace KBS.FauxApplication.Model
{
    public interface ITestCase : IMessageBusEndpointConfigurator
    {
        Task Run(BusControl busControl, TestConfiguration testConfiguration);
    }
}
