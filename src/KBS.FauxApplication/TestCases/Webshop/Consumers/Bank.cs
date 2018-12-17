using System;
using System.Threading.Tasks;
using KBS.Messages.WebshopCase;
using MassTransit;

namespace KBS.FauxApplication.TestCases.Webshop.Consumers
{
    /// <summary>
    /// A bank receives transaction messages from a webshop and returns whether they are valid or not.
    /// </summary>
    public class Bank : IConsumer<ITransaction>
    {
        private bool _colorSet = false;

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
            SwitchColor();
            await Console.Out.WriteLineAsync("\tBank received transaction");
            var validation = new { Transaction = context.Message, IsValid = true };
            await context.Publish<ITransactionValidation>(validation);
            SwitchColor();
        }

        private void SwitchColor()
        {
            if (!_colorSet)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
                Console.ForegroundColor = ConsoleColor.Gray;
            _colorSet = !_colorSet;
        }
    }
}
