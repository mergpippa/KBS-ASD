using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KBS.Messages.WebshopCase;
using MassTransit;

namespace KBS.FauxApplication.TestCases.Webshop.Consumers
{
    /// <summary>
    /// The buyer receives a list of shop items which they can buy. Such a buy order will be wrapped
    /// into a message which contains, or comes occompanied with, a transaction message.
    /// </summary>
    public class Buyer : IConsumer<ICatalogueReply>
    {
        private Dictionary<string, int> _perceivedItems;

        /// <summary>
        /// Consumer for receiving catalogue from webshop
        /// </summary>
        /// <param name="context">
        /// Context containing message
        /// </param>
        /// <returns>
        /// Task to run asynchronously
        /// </returns>
        public async Task Consume(ConsumeContext<ICatalogueReply> context)
        {
            _perceivedItems = context.Message.Catalogue;

            string str = "";
            foreach (var item in context.Message.Catalogue)
                str += "\t" + item + "\n";
            await Console.Out.WriteAsync(str).ConfigureAwait(false);
        }
    }
}
