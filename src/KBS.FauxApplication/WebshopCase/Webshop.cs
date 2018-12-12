using System;
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
    internal class Webshop : IConsumer<ICatalogueRequest>, IConsumer<IOrder>, IConsumer<ITransactionValidation>, IConsumer<IWebshopError>
    {
        /// <summary>
        /// Consumes any error that migh have occured
        /// </summary>
        /// <param name="context">Context containing message</param>
        /// <returns>Task to run asynchronously</returns>
        public async Task Consume(ConsumeContext<IWebshopError> context)
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
            await Console.Out.WriteLineAsync("Received request for item list").ConfigureAwait(false);
            // TODO:: Needs to publish or send item list to buyer
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Consumes a buy order and forwards a transaction message to a bank for validation
        /// </summary>
        /// <param name="context">Context containing message</param>
        /// <returns>Task to run asynchronously</returns>
        public async Task Consume(ConsumeContext<IOrder> context)
        {
            throw new System.NotImplementedException();
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
