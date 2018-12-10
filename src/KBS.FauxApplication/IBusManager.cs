using MassTransit;

namespace KBS.FauxApplication
{
    internal abstract class IBusManager
    {
        private volatile IBusControl _busControl;

        protected IBusManager() => BusControl.Start();

        protected IBusControl BusControl => _busControl ?? (_busControl = CreateBusControl());

        /// <summary>
        /// Creates a new bus with respective queues
        /// </summary>
        /// <returns>Returns a new bus control</returns>
        protected abstract IBusControl CreateBusControl();

        /// <summary>
        /// The Bus must be stopped at the end of the application
        /// </summary>
        public void StopBusControl() => BusControl.Stop();
    }
}
