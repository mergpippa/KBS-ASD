using System;
using System.Threading.Tasks;
using KBS.Messages.RequestResponseCase;
using MassTransit;

namespace KBS.FauxApplication.TestCases.RequestResponse.Consumers
{
    internal class RequestConsumer : IConsumer<IRequestMessage>
    {
        public async Task Consume(ConsumeContext<IRequestMessage> context)
        {
            await Console.Out.WriteLineAsync($"Request received, Count: {context.Message.Count}");
            await context.Publish<IResponseMessage>(new { context.Message.Count });
            await Console.Out.WriteLineAsync("Responding...");
        }
    }
}
