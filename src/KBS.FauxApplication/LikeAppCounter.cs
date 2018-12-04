using System;
using System.Threading.Tasks;
using KBS.Messages;
using MassTransit;

namespace KBS.FauxApplication
{
    internal class LikeAppCounter : IBusManager, IConsumer<ILiked>
    {
        private int likes;

        public LikeAppCounter()
        {
            likes = 0;
        }

        public Task Consume(ConsumeContext<ILiked> context)
        {
            return new Task(() =>
            {
                likes++;
                Console.Out.WriteLineAsync(likes.ToString());
            });
        }

        protected override IBusControl CreateBusControl()
        {
            return Bus.Factory.CreateUsingInMemory(cfg =>
            {
                cfg.ReceiveEndpoint("like_queue", ep =>
                 {
                     ep.Consumer<LikeAppCounter>();
                     ep.Handler<ILiked>(_ => Console.Out.WriteLineAsync("+1"));
                 });
            });
        }
    }
}
