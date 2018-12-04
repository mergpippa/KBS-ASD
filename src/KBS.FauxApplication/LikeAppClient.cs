using System;
using System.Threading.Tasks;
using KBS.Messages;
using MassTransit;

namespace KBS.FauxApplication
{
    internal class LikeAppClient : IBusManager
    {
        private readonly Random random = new Random();

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
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri("rabbitmq://flamingo.rmq.cloudamqp.com:1883"), host =>
                {
                    host.Username("jyqmasmw:jyqmasmw");
                    host.Password("n1390tQb0ctiN6It1vbNG5Gr6d2hFHh0");
                });

                //cfg.ReceiveEndpoint("queue_name", ep =>
                //{
                //    ep.Handler<ILiked>(_ => Console.Out.WriteLineAsync(ILikeCounter.Likes.ToString()));
                //    ep.Handler<IFauxMessage>(_ => Console.Out.WriteLineAsync("Bytes received"));
                //});

                cfg.ReceiveEndpoint("like_queue", ep =>
                {
                    ep.Handler<ILiked>(_ => Console.Out.WriteLineAsync("Liked"));
                });
            });
        }
    }
}
