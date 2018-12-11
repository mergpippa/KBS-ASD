using System.Threading.Tasks;
using KBS.Messages.WebshopCase;
using MassTransit;
using MassTransit.Transports;

namespace KBS.FauxApplication.WebshopCase
{
    /// <summary>
    /// A bank receives transaction messages from a webshop and returns whether they are valid or not.
    /// </summary>
    internal class Bank : IConsumer<ITransaction>
    {
        public Task Consume(ConsumeContext<ITransaction> context)
        {
            throw new System.NotImplementedException();
        }
    }
}
