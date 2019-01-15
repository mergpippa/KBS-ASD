using System;
using System.Threading.Tasks;
using KBS.Data.Enum;
using KBS.Topics;
using MassTransit;
using MassTransit.Serialization;

namespace KBS.MessageBus.Observers
{
    public class ReceiveObserver : IReceiveObserver
    {
        private readonly MessageCaptureContext _messageCaptureContext;

        private readonly IMessageDeserializer _deserializer = new JsonMessageDeserializer(JsonMessageSerializer.Deserializer);

        public ReceiveObserver(MessageCaptureContext messageCaptureContext)
        {
            _messageCaptureContext = messageCaptureContext;
        }

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
            _messageCaptureContext.HandleEvent(
                TelemetryEventType.ConsumeFault,
                context.MessageId,
                (IMessageDiagnostics)context.Message
            );

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
            _messageCaptureContext.HandleEvent(
                TelemetryEventType.PostConsume,
                context.MessageId,
                (IMessageDiagnostics)context.Message
            );

            return Task.CompletedTask;
        }

        /// <summary>
        /// Called when the message was consumed, once for each consumer
        /// </summary>
        /// <param name="context">
        /// </param>
        public Task PostReceive(ReceiveContext context)
        {
            var consumeContext = _deserializer.Deserialize(context);

            consumeContext.TryGetMessage<IMessageDiagnostics>(out var messageContext);

            _messageCaptureContext.HandleEvent(
                TelemetryEventType.PostReceive,
                messageContext.MessageId,
                messageContext.Message
            );

            return Task.CompletedTask;
        }

        /// <summary>
        /// Called when the message is consumed but the consumer throws an exception
        /// </summary>
        /// <param name="context">
        /// </param>
        public Task PreReceive(ReceiveContext context)
        {
            var consumeContext = _deserializer.Deserialize(context);

            consumeContext.TryGetMessage<IMessageDiagnostics>(out var messageContext);

            _messageCaptureContext.HandleEvent(
                TelemetryEventType.PreReceive,
                messageContext.MessageId,
                messageContext.Message
            );

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
            var consumeContext = _deserializer.Deserialize(context);

            consumeContext.TryGetMessage<IMessageDiagnostics>(out var messageContext);

            _messageCaptureContext.HandleEvent(
                TelemetryEventType.ReceiveFault,
                messageContext.MessageId,
                messageContext.Message
            );

            return Task.CompletedTask;
        }
    }
}
