using System;
using System.Threading.Tasks;
using KBS.Messages;
using MassTransit;
using MassTransit.Azure.ServiceBus.Core;
using Microsoft.Azure.ServiceBus.Primitives;

namespace KBS.FauxApplication
{
    /// <summary>
    /// A LikeAppCounter is notified of new likes, counts them and publishes the new count
    /// </summary>
    internal class LikeAppCounter : IBusManager
    {
        private int likes;

        /// <summary>
        /// Constructor first IBusManager then LikeAppCounter, to create a new bus and set likes to 0
        /// </summary>
        public LikeAppCounter()
        {
            likes = 0;
            Console.WriteLine("LikeAppCounter constructor done");
        }

        /// <summary>
        /// Updates every queue listening to 'ILikeCount' topic
        /// </summary>
        /// <returns></returns>
        private Task UpdateLikeCount() => BusControl.Publish<ILikeCount>(new { Likes = likes });

        protected override IBusControl CreateBusControl()
        {
            return Bus.Factory.CreateUsingAzureServiceBus(cfg =>
            {
                cfg.Host(new Uri("sb://kbs-asd-test-bus.servicebus.windows.net/"), h =>
                {
                    h.OperationTimeout = TimeSpan.FromSeconds(5);
                    h.TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAccessKey", Program.KEY);
                });

                cfg.ReceiveEndpoint("like_queue", ep => ep.Handler<ILiked>(_ =>
                {
                    #region Fake work

                    //System.Threading.Thread.Sleep(50);

                    #endregion Fake work

                    likes++;
                    // Publish/ update the new like count
                    UpdateLikeCount();
                    // Write number of counts to console, according to the counter
                    return Console.Out.WriteLineAsync($"{$"Likes counted: {likes}",-20} (counter)");
                }));
            });
        }
    }
}
