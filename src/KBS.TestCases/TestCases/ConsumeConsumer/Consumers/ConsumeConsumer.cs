using System.Threading.Tasks;
using KBS.Topics.ConsumerCase;
using MassTransit;

namespace KBS.TestCases.TestCases.ConsumeConsumer.Consumers
{
    public class ConsumeConsumer : IConsumer<IConsumeMessage>
    {
        public async Task Consume(ConsumeContext<IConsumeMessage> context)
        {
            await Task.Yield();

            // The consumer doesn't have to do anything :)
        }
    }
}
