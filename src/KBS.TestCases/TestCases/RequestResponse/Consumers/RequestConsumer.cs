using System;
using System.Threading.Tasks;
using KBS.Topics.RequestResponseCase;
using MassTransit;

namespace KBS.TestCases.TestCases.RequestResponse.Consumers
{
    /// <summary>
    /// Consumer of 'IRequestMessage' topics
    /// </summary>
    internal class RequestConsumer : IConsumer<IRequestMessage>
    {
        /// <summary>
        /// Always replies by publishing a 'IResponseMesage' topic
        /// </summary>
        /// <param name="context">Received context from message bus</param>
        /// <returns></returns>
        public async Task Consume(ConsumeContext<IRequestMessage> context)
        {
            await Console.Out.WriteLineAsync($"Request received, Count: {context.Message.Count}");

            context.Respond((IResponseMessage)context.Message);

            await Console.Out.WriteLineAsync("Response send...");
        }
    }
}
