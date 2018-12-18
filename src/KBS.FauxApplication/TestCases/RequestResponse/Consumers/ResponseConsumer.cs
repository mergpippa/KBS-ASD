using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KBS.Messages.RequestResponseCase;
using MassTransit;

namespace KBS.FauxApplication.TestCases.RequestResponse.Consumers
{
    internal class ResponseConsumer : IConsumer<IResponseMessage>
    {
        public async Task Consume(ConsumeContext<IResponseMessage> context)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            await Console.Out.WriteLineAsync("Response received");

            if (context.Message.Count >= 0)
                await context.Publish<IRequestMessage>(new { Count = context.Message.Count - 1 });
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
