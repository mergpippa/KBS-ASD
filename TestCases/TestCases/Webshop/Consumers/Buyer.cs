using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KBS.Topics.WebshopCase;
using MassTransit;

namespace KBS.TestCases.TestCases.Webshop.Consumers
{
    /// <inheritdoc />
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
            var str = "";
            
            foreach (var item in context.Message.Catalogue)
                str += "\t" + item + "\n";
            
            await Console.Out.WriteAsync(str).ConfigureAwait(false);
        }
    }
}
