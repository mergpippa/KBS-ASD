using System;
using System.Threading.Tasks;
using MassTransit;

namespace KBS.MessageBus.Observers
{
    public class SendObserver : ISendObserver
    {
        /// <summary>
        /// Called after the message is sent to the transport (and confirmed by the transport if supported)
        /// </summary>
        /// <typeparam name="T">
        /// The message type
        /// </typeparam>
        /// <param name="context">
        /// The message send context
        /// </param>
        public Task PostSend<T>(SendContext<T> context) where T : class
        {
            Console.Write("PostSend: ");
            Console.WriteLine(context.MessageId);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Called before the message is sent to the transport
        /// </summary>
        /// <typeparam name="T">
        /// The message type
        /// </typeparam>
        /// <param name="context">
        /// The message send context
        /// </param>
        public Task PreSend<T>(SendContext<T> context) where T : class
        {
            Console.Write("PreSend: ");
            Console.WriteLine(context.MessageId);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Called when the message fails to send to the transport, including the exception that was thrown
        /// </summary>
        /// <typeparam name="T">
        /// The message type
        /// </typeparam>
        /// <param name="context">
        /// The message send context
        /// </param>
        /// <param name="exception">
        /// The exception from the transport
        /// </param>
        public Task SendFault<T>(SendContext<T> context, Exception exception) where T : class
        {
            Console.Write("SendFault: ");
            Console.WriteLine(context.MessageId);

            return Task.CompletedTask;
        }
    }
}
