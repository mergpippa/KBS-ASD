using System;
using KBS.Configuration;
using MassTransit;

namespace KBS.MessageBus
{
    public class BusControl : IDisposable
    {
        public readonly IBusControl Instance;

        /// <summary>
        /// Creates a new bus control with given test case
        /// </summary>
        /// <param name="busFactoryConfigurator">
        /// </param>
        public BusControl(Action<IBusFactoryConfigurator> busFactoryConfigurator)
        {
            Instance = TransportFactory.Create(
                TestCaseConfiguration.TransportType,
                busFactoryConfigurator
            );

            // Starts bus (The bus must be started before sending any messages!)
            Instance.Start();
        }

        /// <summary>
        /// Stops bus control when this class is being disposed
        /// </summary>
        public void Dispose()
        {
            Instance.Stop();
        }
    }
}
