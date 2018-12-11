using System;
using System.Threading;
using System.Threading.Tasks;
using KBS.Messages;
using MassTransit;
using MassTransit.Azure.ServiceBus.Core;
using Microsoft.Azure.ServiceBus.Primitives;

namespace KBS.FauxApplication
{
    internal class LikeAppClient : IBusManager, IConsumer<ILikeCount>
    {
        private readonly Random random = new Random();

        /// <summary>
        /// Constructor first IBusManager then LikeAppClient, to create a new bus and set it's own task id
        /// </summary>
        public LikeAppClient()
        {
            Console.WriteLine($"LikeAppClient constructor done");
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
                var host = cfg.Host(new Uri("sb://kbs-asd-test-bus.servicebus.windows.net/"), h =>
                {
                    h.OperationTimeout = TimeSpan.FromSeconds(5);
                    h.TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAccessKey", Program.KEY);
                });

                cfg.ReceiveEndpoint(host, "like_count", ep => ep.Instance(this));
            });
        }

        public async Task Consume(ConsumeContext<ILikeCount> context)
        {
            await Console.Out.WriteLineAsync($"{$"+1 like: {context.Message.Likes}",-20} (client [{Thread.GetCurrentProcessorId()}])").ConfigureAwait(false);
        }
    }
}