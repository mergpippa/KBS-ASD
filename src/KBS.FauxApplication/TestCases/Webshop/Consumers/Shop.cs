using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KBS.Messages.WebshopCase;
using MassTransit;

namespace KBS.FauxApplication.TestCases.Webshop.Consumers
{
    /// <summary>
    /// The webshop contains a list of salable items, which will be send to any buyer. When a webshop
    /// receives a buy order message it will check if the items are available. Any transaction
    /// messages will be send to the bank for validation.
    /// </summary>
    public class Shop : IConsumer<ICatalogueRequest>, IConsumer<IOrder>, IConsumer<ITransactionValidation>
    {
        /// <summary>
        /// All salable items in the webshop and their quantity
        /// </summary>
        public static Dictionary<string, int> Items;

        private static List<IOrder> _orders = new List<IOrder>();
        private bool _colorSet = false;

        public Shop()
        {
            Items = new Dictionary<string, int> { { "Apple", 3 }, { "Pear", 4 }, { "Banana", 9 }, };
        }

        /// <summary>
        /// Consumes request to publish the new catalogue
        /// </summary>
        /// <param name="context">
        /// Context containing message
        /// </param>
        /// <returns>
        /// Task to run asynchronously
        /// </returns>
        public async Task Consume(ConsumeContext<ICatalogueRequest> context)
        {
            SwitchColor();
            await Console.Out.WriteLineAsync("\tReceived request for item list");
            await context.Publish<ICatalogueReply>(new { SalableItems = Items });
            SwitchColor();
        }

        /// <summary>
        /// Consumes a buy order and forwards a transaction message to a bank for validation
        /// </summary>
        /// <param name="context">
        /// Context containing message
        /// </param>
        /// <returns>
        /// Task to run asynchronously
        /// </returns>
        public async Task Consume(ConsumeContext<IOrder> context)
        {
            SwitchColor();
            await Console.Out.WriteLineAsync($"\tOrder received from {context.Message.Purchase.AccountID}");
            string orderedItem = context.Message.ItemName;
            int orderedQuantity = context.Message.Quantity;
            if (!Items.ContainsKey(orderedItem) || Items[orderedItem] < orderedQuantity)
            {
                await Console.Out.WriteLineAsync($"\tTried to order {orderedQuantity} {orderedItem}, " +
                    $"but there are {Items[orderedItem]} left").ConfigureAwait(false);
            }
            else
            {
                ITransaction transaction = context.Message.Purchase;
                _orders.Add(context.Message);
                await Console.Out.WriteLineAsync("\tPublishing transaction");
                await context.Publish<ITransaction>(transaction).ConfigureAwait(false);
            }
            SwitchColor();
        }

        /// <summary>
        /// Consumes the transaction reply from bank
        /// </summary>
        /// <param name="context">
        /// Context containing message
        /// </param>
        /// <returns>
        /// Task to run asynchronously
        /// </returns>
        public async Task Consume(ConsumeContext<ITransactionValidation> context)
        {
            SwitchColor();
            await Console.Out.WriteAsync($"\tTransaction from {context.Message.Transaction.AccountID} is ");
            if (context.Message.IsValid)
            {
                await Console.Out.WriteLineAsync("VALID");
                var order = _orders.Find(o => o.Purchase.AccountID == context.Message.Transaction.AccountID);
                _orders.Remove(order);
                await Console.Out.WriteLineAsync($"\t{order.Quantity} {order.ItemName} purchased by {order.Purchase.AccountID} for ${order.Purchase.Withdrawal}");
            }
            else
                await Console.Out.WriteLineAsync("INVALID");
            SwitchColor();
        }

        private void SwitchColor()
        {
            Console.ForegroundColor = !_colorSet ? ConsoleColor.Blue : ConsoleColor.Gray;
            _colorSet = !_colorSet;
        }
    }
}
