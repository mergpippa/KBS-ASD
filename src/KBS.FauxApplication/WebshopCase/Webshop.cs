using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KBS.Messages.WebshopCase;
using MassTransit;

namespace KBS.FauxApplication.WebshopCase
{
    /// <summary>
    /// The webshop contains a list of salable items, which will be send to any buyer.
    /// When a webshop receives a buy order message it will check if the items are available.
    /// Any transaction messages will be send to the bank for validation.
    /// </summary>
    public class Webshop : IConsumer<ICatalogueRequest>, IConsumer<IOrder>, IConsumer<ITransactionValidation>, IConsumer<IWebshopError>
    {
        /// <summary>
        /// All salable items in the webshop and their quantity
        /// </summary>
        private Dictionary<string, int> _items;

        public Webshop()
        {
            _items = new Dictionary<string, int> { { "Apple", 3 }, { "Pear", 4 }, { "Banana", 9 } };
        }

        /// <summary>
        /// Consumes any error that migh have occured
        /// </summary>
        /// <param name="context">Context containing message</param>
        /// <returns>Task to run asynchronously</returns>
        public Task Consume(ConsumeContext<IWebshopError> context)
        {
            throw new Exception(context.Message.ErrorMessage);
        }

        /// <summary>
        /// Consumes request to publish the new catalogue
        /// </summary>
        /// <param name="context">Context containing message</param>
        /// <returns>Task to run asynchronously</returns>
        public async Task Consume(ConsumeContext<ICatalogueRequest> context)
        {
            // TODO:: Needs to publish or send item list to buyer
            await Console.Out.WriteLineAsync("Received request for item list");
            await context.Publish<ICatalogueReply>(new { SalableItems = _items });
        }

        /// <summary>
        /// Consumes a buy order and forwards a transaction message to a bank for validation
        /// </summary>
        /// <param name="context">Context containing message</param>
        /// <returns>Task to run asynchronously</returns>
        public async Task Consume(ConsumeContext<IOrder> context)
        {
            string orderedItem = context.Message.ItemName;
            int orderedQuantity = context.Message.Quantity;
            if (!_items.ContainsKey(orderedItem) || _items[orderedItem] < orderedQuantity)
            {
                await Console.Out.WriteLineAsync($"Tried to order {orderedQuantity} {orderedItem}, " +
                    $"but there are {_items[orderedItem]} left").ConfigureAwait(false);
            }
            else
            {
                ITransaction transaction = context.Message.Purchase;
                await Console.Out.WriteLineAsync("Publishing transaction");
                await context.Publish<ITransaction>(transaction).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Consumes the transaction reply from bank
        /// </summary>
        /// <param name="context">Context containing message</param>
        /// <returns>Task to run asynchronously</returns>
        public async Task Consume(ConsumeContext<ITransactionValidation> context)
        {
            throw new System.NotImplementedException();
        }
    }
}
