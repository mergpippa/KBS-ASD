using System;
using System.Threading.Tasks;
using KBS.Messages.WebshopCase;
using MassTransit;

namespace KBS.FauxApplication.WebshopCase
{
    /// <summary>
    /// The buyer receives a list of shop items which they can buy.
    /// Such a buy order will be wrapped into a message which contains, or comes occompanied with, a transaction message.
    /// </summary>
    internal class Buyer : IConsumer<ICatalogueReply>, IConsumer<IWebshopError>
    {
        /// <summary>
        /// Consumer for receiving catalogue from webshop
        /// </summary>
        /// <param name="context">Context containing message</param>
        /// <returns>Task to run asynchronously</returns>
        public async Task Consume(ConsumeContext<ICatalogueReply> context)
        {
            string str = "";
            foreach (var item in context.Message.SalableItems)
                str += item + "\n";
            await Console.Out.WriteAsync(str).ConfigureAwait(false);
        }

        /// <summary>
        /// Consumes any error that might have occured
        /// </summary>
        /// <param name="context">Context containing message</param>
        /// <returns>Task to run asynchronously</returns>
        public async Task Consume(ConsumeContext<IWebshopError> context)
        {
            throw new Exception(context.Message.ErrorMessage);
        }
    }
}
