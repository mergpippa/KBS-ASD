using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KBS.Messages.WebshopCase;
using MassTransit;

namespace KBS.FauxApplication.WebshopCase
{
    /// <summary>
    /// The buyer receives a list of shop items which they can buy.
    /// Such a buy order will be wrapped into a message which contains, or comes occompanied with, a transaction message.
    /// </summary>
    public class Buyer : IConsumer<ICatalogueReply>, IConsumer<IWebshopError>
    {
        private Dictionary<string, int> _perceivedItems;

        public void RequestItemList()
        {
            Console.WriteLine("Buyer: Requested catalogue...");
            //BusControl.Publish<ICatalogueRequest>(new { });
        }

        public void OrderItem(string itemName, int quantity)
        {
            var bankInfo = new { AccountID = 6699u, Withdrawal = 8 };
            var order = new { ItemName = itemName, Quantity = quantity, Purchase = bankInfo };
            Console.WriteLine("Order send...");
            //BusControl.Publish<IOrder>(order);
        }

        /// <summary>
        /// Consumer for receiving catalogue from webshop
        /// </summary>
        /// <param name="context">Context containing message</param>
        /// <returns>Task to run asynchronously</returns>
        public async Task Consume(ConsumeContext<ICatalogueReply> context)
        {
            _perceivedItems = context.Message.SalableItems;

            string str = "----Buyer:\n";
            foreach (var item in context.Message.SalableItems)
                str += "\t" + item + "\n";
            await Console.Out.WriteAsync(str).ConfigureAwait(false);
        }

        /// <summary>
        /// Consumes any error that might have occured
        /// </summary>
        /// <param name="context">Context containing message</param>
        /// <returns>Task to run asynchronously</returns>
        public Task Consume(ConsumeContext<IWebshopError> context)
        {
            throw new Exception(context.Message.ErrorMessage);
        }
    }
}
