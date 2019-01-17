using System;
using System.Threading.Tasks;
using KBS.Data.Enum;
using KBS.Topics;
using MassTransit;

namespace KBS.MessageBus.Observers
{
    public class ConsumeObserver : IConsumeObserver
    {
        private readonly MessageCaptureContext _messageCaptureContext;

        public ConsumeObserver(MessageCaptureContext messageCaptureContext)
        {
            _messageCaptureContext = messageCaptureContext;
        }

        /// <summary>
        /// Called before the consumer's Consume method is called
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <param name="context">
        /// </param>
        public Task PreConsume<T>(ConsumeContext<T> context) where T : class
        {
            _messageCaptureContext.HandleEvent(
                TelemetryEventType.PreConsume,
                context.MessageId,
                (IMessageDiagnostics)context.Message
            );

            return Task.CompletedTask;
        }

        /// <summary>
        /// Event already handled by ReceiveObserver
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <param name="context">
        /// </param>
        public Task PostConsume<T>(ConsumeContext<T> context) where T : class
        {
            _messageCaptureContext.HandleEvent(
                TelemetryEventType.PostConsume,
                context.MessageId,
                (IMessageDiagnostics)context.Message
            );

            return Task.CompletedTask;
        }

        /// <summary>
        /// Event already handled by ReceiveObserver
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <param name="context">
        /// </param>
        /// <param name="exception">
        /// </param>
        public Task ConsumeFault<T>(ConsumeContext<T> context, Exception exception) where T : class
        {
            _messageCaptureContext.HandleEvent(
                TelemetryEventType.ConsumeFault,
                context.MessageId,
                (IMessageDiagnostics)context.Message
            );

            return Task.CompletedTask;
        }
    }
}
