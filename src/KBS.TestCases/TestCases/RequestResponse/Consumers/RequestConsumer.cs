using System;
using System.Threading.Tasks;
using KBS.Topics.RequestResponseCase;
using MassTransit;

namespace KBS.TestCases.TestCases.RequestResponse.Consumers
{
    internal class RequestConsumer : IConsumer<IRequestMessage>
    {
        public async Task Consume(ConsumeContext<IRequestMessage> context)
        {
            Console.WriteLine("Sending message");

            await Console.Out.WriteLineAsync($"Request received, Count: {context.Message.Count}");
            await context.Publish<IResponseMessage>(new { context.Message.Count });
            await Console.Out.WriteLineAsync("Responding...");
        }
    }
}
