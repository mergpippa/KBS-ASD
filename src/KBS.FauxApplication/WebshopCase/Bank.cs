using System.Threading.Tasks;
using KBS.Messages.WebshopCase;
using MassTransit;

namespace KBS.FauxApplication.WebshopCase
{
    /// <summary>
    /// A bank receives transaction messages from a webshop and returns whether they are valid or not.
    /// </summary>
    internal class Bank : IConsumer<ITransaction>
    {
        /// <summary>
        /// Consumes transaction message from webshop and checks and publishes validity
        /// </summary>
        /// <param name="context">Context containing message</param>
        /// <returns>Task to run asynchronously</returns>
        public Task Consume(ConsumeContext<ITransaction> context)
        {
            throw new System.NotImplementedException();
        }
    }
}
