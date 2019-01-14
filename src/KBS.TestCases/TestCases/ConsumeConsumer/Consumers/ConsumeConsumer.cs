#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

using System.Threading.Tasks;
using KBS.Topics.ConsumerCase;
using MassTransit;

namespace KBS.TestCases.TestCases.ConsumeConsumer.Consumers
{
    public class ConsumeConsumer : IConsumer<IConsumeMessage>
    {
        public async Task Consume(ConsumeContext<IConsumeMessage> context)
        {
            // Message receive is handled by PerformanceDiagnosticsFilter
        }
    }
}
