using System.Threading.Tasks;
using KBS.Topics.WebshopCase;
using MassTransit;

namespace KBS.TestCases.TestCases.Webshop.Consumers
{
    /// <summary>
    /// The buyer receives a list of shop items which they can buy. Such a buy order will be wrapped
    /// into a message which contains, or comes accompanied with, a transaction message.
    /// </summary>
    public class Buyer : IConsumer<ICatalogueReply>
    {
        /// <summary>
        /// Consumer for receiving catalogue from Webshop
        /// </summary>
        /// <param name="context">
        /// Context containing message
        /// </param>
        /// <returns>
        /// Task to run asynchronously
        /// </returns>
        public async Task Consume(ConsumeContext<ICatalogueReply> context)
        {
            await Task.Yield();

            // We don't have to do anything in here because the receive pipeline already handles tracing
        }
    }
}
