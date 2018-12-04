using System;
using KBS.Messages;
using MassTransit;

namespace KBS.FauxApplication
{
    /// <summary>
    /// Holds the bus control singleton
    /// This class needs to be extended to access the singelton bus
    /// </summary>
    public abstract class SingleBusControl
    {
        private static readonly object busLock = new object();
        private static volatile IBusControl busControl;

        /// <summary>
        /// Get the bus control singleton, it's already started
        /// Only the classes that extend 'SingleBusControl' have access to the bus singleton
        /// </summary>
        protected IBusControl BusControl
        {
            get
            {
                if (busControl == null)
                {
                    lock (busLock)
                    {
                        if (busControl == null)
                        {
                            busControl = CreateBusControl();
                            BusControl.Start();
                        }
                    }
                }
                return busControl;
            }
        }

        /// <summary>
        /// The Bus must be stopped at the end of the application
        /// </summary>
        public void StopBusControl() => BusControl.Stop();

        /// <summary>
        /// Creates a new bus with respective queues
        /// </summary>
        /// <returns>Returns a new bus control</returns>
        private static IBusControl CreateBusControl()
        {
            return Bus.Factory.CreateUsingInMemory(cfg =>
            {
                cfg.ReceiveEndpoint("queue_name", ep =>
                {
                    ep.Handler<ILiked>(_ => Console.Out.WriteLineAsync(ILikeCounter.Likes.ToString()));
                    ep.Handler<IFauxMessage>(_ => Console.Out.WriteLineAsync("Bytes received"));
                });
            });
        }
    }
}
