using System;
using System.Threading.Tasks;
using KBS.Topics;
using MassTransit;

namespace KBS.MessageBus.Observers
{
    public class ReceiveObserver : IReceiveObserver
    {
        /// <summary>
        /// Called immediately after the message was delivery by the transport
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <param name="context">
        /// </param>
        /// <param name="duration">
        /// </param>
        /// <param name="consumerType">
        /// </param>
        /// <param name="exception">
        /// </param>
        public Task ConsumeFault<T>(ConsumeContext<T> context, TimeSpan duration, string consumerType, Exception exception) where T : class
        {
            context.TryGetPayload<IMessageDiagnostics>(out var payload);

            Console.Write("ConsumeFault: ");
            Console.WriteLine(payload);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Called after the message has been received and processed
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <param name="context">
        /// </param>
        /// <param name="duration">
        /// </param>
        /// <param name="consumerType">
        /// </param>
        public Task PostConsume<T>(ConsumeContext<T> context, TimeSpan duration, string consumerType) where T : class
        {
            context.TryGetPayload<IMessageDiagnostics>(out var payload);

            Console.Write("PostConsume: ");
            Console.WriteLine(payload);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Called when the message was consumed, once for each consumer
        /// </summary>
        /// <param name="context">
        /// </param>
        public Task PostReceive(ReceiveContext context)
        {
            context.TryGetPayload<IMessageDiagnostics>(out var payload);

            Console.Write("PostReceive: ");
            Console.WriteLine(payload);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Called when the message is consumed but the consumer throws an exception
        /// </summary>
        /// <param name="context">
        /// </param>
        public Task PreReceive(ReceiveContext context)
        {
            context.TryGetPayload<IMessageDiagnostics>(out var payload);

            Console.Write("PreReceive: ");
            Console.WriteLine(payload);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Called when an exception occurs early in the message processing, such as deserialization, etc.
        /// </summary>
        /// <param name="context">
        /// </param>
        /// <param name="exception">
        /// </param>
        public Task ReceiveFault(ReceiveContext context, Exception exception)
        {
            context.TryGetPayload<IMessageDiagnostics>(out var payload);

            Console.Write("ReceiveFault: ");
            Console.WriteLine(payload);

            return Task.CompletedTask;
        }
    }
}
