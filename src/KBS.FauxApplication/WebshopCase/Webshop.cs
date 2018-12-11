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
        public Task Consume(ConsumeContext<IWebshopError> context)
        {
            throw new Exception(context.Message.ErrorMessage);
        }

        public async Task Consume(ConsumeContext<ICatalogueRequest> context)
        {
            await Console.Out.WriteLineAsync("Received request for item list").ConfigureAwait(false);
            // TODO:: Needs to publish or send item list to buyer
            throw new System.NotImplementedException();
        }

        public Task Consume(ConsumeContext<IOrder> context)
        {
            throw new System.NotImplementedException();
        }

        public Task Consume(ConsumeContext<ITransactionValidation> context)
        {
            throw new System.NotImplementedException();
        }
    }
}
