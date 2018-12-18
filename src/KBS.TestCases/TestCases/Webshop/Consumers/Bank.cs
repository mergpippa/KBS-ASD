using System;
using System.Threading.Tasks;
using KBS.Topics.WebshopCase;
using MassTransit;

namespace KBS.TestCases.TestCases.Webshop.Consumers
{
    /// <summary>
    /// A bank receives transaction messages from a webshop and returns whether they are valid or not.
    /// </summary>
    public class Bank : IConsumer<ITransaction>
    {
        /// <summary>
        /// Consumes transaction message from webshop and checks and publishes validity
        /// </summary>
        /// <param name="context">
        /// Context containing message
        /// </param>
        /// <returns>
        /// Task to run asynchronously
        /// </returns>
        public async Task Consume(ConsumeContext<ITransaction> context)
        {
            await Console.Out.WriteLineAsync("\tBank received transaction");

            await context.Publish<ITransactionValidation>(
                new { Transaction = context.Message, IsValid = true }
            );
        }
    }
}
