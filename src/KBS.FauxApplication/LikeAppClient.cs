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

        public LikeAppClient()
        {
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

        public Task PublishLike() => BusControl.Publish<ILiked>(new { });

        protected override IBusControl CreateBusControl()
        {
            return Bus.Factory.CreateUsingAzureServiceBus(cfg =>
            {
                cfg.Host(new Uri("sb://personal-test-service-bus.servicebus.windows.net/"), h =>
                {
                    h.OperationTimeout = TimeSpan.FromSeconds(5);
                    h.TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAccessKey", Program.KEY);
                });
            });
        }
    }
}
