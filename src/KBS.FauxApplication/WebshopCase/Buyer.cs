using MassTransit;
using KBS.Messages.WebshopCase;
using System.Threading.Tasks;

namespace KBS.FauxApplication.WebshopCase
{
    /// <summary>
    /// The buyer receives a list of shop items which they can buy.
    /// Such a buy order will be wrapped into a message which contains, or comes occompanied with, a transaction message.
    /// </summary>
    internal class Buyer : IConsumer<ICatalogueReply>, IConsumer<IWebshopError>
    {
        public Task Consume(ConsumeContext<ICatalogueReply> context)
        {
            throw new System.NotImplementedException();
        }

        public Task Consume(ConsumeContext<IWebshopError> context)
        {
            throw new System.NotImplementedException();
        }
    }
}
