using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KBS.Messages;
using MassTransit;

namespace KBS.FauxApplication
{
    /// <summary>
    /// Holds the bus control singleton
    /// </summary>
    public abstract class SingleBusControl
    {
        private static readonly object busLock = new object();
        private static volatile IBusControl busControl;

        /// <summary>
        /// Get the bus control singleton, it's already started
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
                            busControl = GetNewBus();
                            BusControl.Start();
                        }
                    }
                }
                return busControl;
            }
        }

        public void StopBusControl() => BusControl.Stop();

        /// <summary>
        /// Creates a new bus with respective queues
        /// </summary>
        /// <returns>Returns a new bus control</returns>
        private static IBusControl GetNewBus()
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
