using MassTransit;
using KBS.Messages.WebshopCase;
using System.Threading.Tasks;
using System;

namespace KBS.FauxApplication.WebshopCase
{
    /// <summary>
    /// The buyer receives a list of shop items which they can buy.
    /// Such a buy order will be wrapped into a message which contains, or comes occompanied with, a transaction message.
    /// </summary>
    internal class Buyer : IConsumer<ICatalogueReply>, IConsumer<IWebshopError>
    {
        public async Task Consume(ConsumeContext<ICatalogueReply> context)
        {
            string str = "";
            foreach (var item in context.Message.SalableItems)
                str += item + "\n";
            await Console.Out.WriteAsync(str).ConfigureAwait(false);
        }

        public Task Consume(ConsumeContext<IWebshopError> context)
        {
            throw new Exception(context.Message.ErrorMessage);
        }
    }
}
