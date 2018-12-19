using System;
using System.Threading.Tasks;
using KBS.Topics.RequestResponseCase;
using MassTransit;

namespace KBS.TestCases.TestCases.RequestResponse.Consumers
{
    /// <summary>
    /// Consumer of 'IResponseMessage' topics
    /// </summary>
    internal class ResponseConsumer : IConsumer<IResponseMessage>
    {
        /// <summary>
        /// If called for will send another IRequestMessage
        /// </summary>
        /// <param name="context">Received context from message bus</param>
        /// <returns></returns>
        public async Task Consume(ConsumeContext<IResponseMessage> context)
        {
            await Console.Out.WriteLineAsync($"Response received; {context.Message.Filler.Length} bytes");

            if (context.Message.Count - 1 > 0)
            {
                await context.Publish<IRequestMessage>(new
                {
                    Count = context.Message.Count - 1,
                    context.Message.Filler
                });
                await Console.Out.WriteLineAsync("New request send...");
            }
        }
    }
}
