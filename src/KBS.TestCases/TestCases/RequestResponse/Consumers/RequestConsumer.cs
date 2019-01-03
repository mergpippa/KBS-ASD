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
        /// Always replies by publishing a 'IResponseMessage' topic
        /// </summary>
        /// <param name="context">
        /// Received context from message bus
        /// </param>
        /// <returns>
        /// </returns>
        public Task Consume(ConsumeContext<IRequestMessage> context)
        {
            context.Respond((IResponseMessage)context.Message);

            return null;
        }
    }
}
