using System;
using System.Threading.Tasks;
using KBS.Messages;
using MassTransit;
using MassTransit.Azure.ServiceBus.Core;
using Microsoft.Azure.ServiceBus.Primitives;

namespace KBS.FauxApplication
{
    internal class LikeAppClient : IBusManager
    {
        private readonly Random random = new Random();

        /// <summary>
        /// Task id
        /// </summary>
        private int? _id;

        /// <summary>
        /// Constructor first IBusManager then LikeAppClient, to create a new bus and set it's own task id
        /// </summary>
        /// <param name="id">Task id</param>
        public LikeAppClient(int? id)
        {
            _id = id;
            Console.WriteLine("LikeAppClient constructor done");
        }

        /// <summary>
        /// Publish an array of random bytes
        /// </summary>
        /// <param name="arraySize">Size of the array to publish</param>
        public Task PublishRandomBytes(uint arraySize)
        {
            byte[] bytes = new byte[arraySize];
            random.NextBytes(bytes);
            return BusControl.Publish<IFauxMessage>(new { ByteArray = bytes });
        }

        /// <summary>
        /// Method to easily publish a like
        /// </summary>
        /// <returns></returns>
        public Task PublishLike() => BusControl.Publish<ILiked>(new { });

        protected override IBusControl CreateBusControl()
        {
            return Bus.Factory.CreateUsingAzureServiceBus(cfg =>
            {
                cfg.Host(new Uri("sb://kbs-asd-test-bus.servicebus.windows.net/"), h =>
                {
                    h.OperationTimeout = TimeSpan.FromSeconds(5);
                    h.TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAccessKey", Program.KEY);
                });

                // Receive any changes to the like count and write the new count to console, with it's own task id
                cfg.ReceiveEndpoint("like_count", ep => ep.Handler<ILikeCount>(c => Console.Out.WriteLineAsync($"{$"+1 like: {c.Message.Likes}",-20} (client [{_id}])")));
            });
        }
    }
}
