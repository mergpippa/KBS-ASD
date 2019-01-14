using System;
using System.Threading.Tasks;
using KBS.Topics;
using MassTransit;

namespace KBS.MessageBus.Observers
{
    public class PublishObserver : IPublishObserver
    {
        /// <summary>
        /// Called before the message is sent to the transport
        /// </summary>
        /// <typeparam name="T">
        /// The message type
        /// </typeparam>
        /// <param name="context">
        /// The message send context
        /// </param>
        public Task PrePublish<T>(PublishContext<T> context)
            where T : class
        {
            context.TryGetPayload<IMessageDiagnostics>(out var payload);

            Console.Write("PrePublish: ");
            Console.WriteLine(payload);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Called after the message is sent to the transport (and confirmed by the transport if supported)
        /// </summary>
        /// <typeparam name="T">
        /// The message type
        /// </typeparam>
        /// <param name="context">
        /// The message send context
        /// </param>
        public Task PostPublish<T>(PublishContext<T> context)
            where T : class
        {
            context.TryGetPayload<IMessageDiagnostics>(out var payload);

            Console.Write("PostPublish: ");
            Console.WriteLine(payload);

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
        public Task PublishFault<T>(PublishContext<T> context, Exception exception)
            where T : class
        {
            context.TryGetPayload<IMessageDiagnostics>(out var payload);

            Console.Write("PublishFault: ");
            Console.WriteLine(payload);

            return Task.CompletedTask;
        }
    }
}
