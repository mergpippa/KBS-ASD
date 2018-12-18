using System;
using System.Threading.Tasks;
using KBS.Messages.RequestResponseCase;
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
            await Console.Out.WriteLineAsync("Response received");

            if (context.Message.Count >= 0)
                await context.Publish<IRequestMessage>(new { Count = context.Message.Count - 1 });
        }
    }
}
