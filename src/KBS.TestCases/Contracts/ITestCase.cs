using System.Threading.Tasks;
using KBS.MessageBus;
using KBS.MessageBus.Configurator;

namespace KBS.TestCases.Contracts
{
    /// <summary>
    /// Interface for all test cases
    /// </summary>
    public interface ITestCase : IMessageBusEndpointConfigurator
    {
        /// /// <summary>
        /// Methode to run the test case
        /// </summary>
        /// <param name="busControl">The bus for the test case to use</param>
        /// <param name="testCaseConfiguration">The configuration for this test case</param>
        /// <returns></returns>
        Task Run(BusControl busControl, TestCaseConfiguration testCaseConfiguration);
    }
}
