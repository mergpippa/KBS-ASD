using System;
using System.Threading.Tasks;
using KBS.Messages;
using MassTransit;
using MassTransit.Azure.ServiceBus.Core;
using Microsoft.Azure.ServiceBus.Primitives;

namespace KBS.FauxApplication
{
    internal class LikeAppCounter : IBusManager
    {
        private int likes;

        public LikeAppCounter()
        {
            likes = 0;
            Console.WriteLine("LikeAppCounter constructor done");
        }

        protected override IBusControl CreateBusControl()
        {
            return Bus.Factory.CreateUsingAzureServiceBus(cfg =>
            {
                cfg.Host(new Uri("sb://personal-test-service-bus.servicebus.windows.net/"), h =>
                {
                    h.OperationTimeout = TimeSpan.FromSeconds(5);
                    h.TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAccessKey", Program.KEY);
                });

                cfg.ReceiveEndpoint("like_queue", ep =>
                 {
                     ep.Handler<ILiked>(_ => Console.Out.WriteLineAsync($"Likes counted: {++likes}"));
                 });
            });
        }
    }
}
