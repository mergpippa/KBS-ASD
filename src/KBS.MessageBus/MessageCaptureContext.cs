using System;
using System.Threading;
using KBS.Data.Enum;
using KBS.Telemetry.Clients;

namespace KBS.MessageBus
{
    public class MessageCaptureContext
    {
        /// <summary>
        /// Client that is used to track events
        /// </summary>
        private readonly ITelemetryClient _telemetryClient;

        /// <summary>
        /// Number of messages that are sent during the benchmark
        /// </summary>
        private readonly int _messagesCount;

        /// <summary>
        /// Amount of messages that are received
        /// </summary>
        private int _preReceivedMessagesCount;

        /// <summary>
        /// Time when this instance was created
        /// </summary>
        private readonly DateTime _createdAt = DateTime.UtcNow;

        /// <summary>
        /// MessageCaptureContext constructor
        /// </summary>
        /// <param name="messagesCount">
        /// </param>
        /// <param name="telemetryClient">
        /// </param>
        public MessageCaptureContext(int messagesCount, ITelemetryClient telemetryClient)
        {
            _messagesCount = messagesCount;
            _telemetryClient = telemetryClient;
        }

        /// <summary>
        /// Checks if all messages have been received
        /// </summary>
        public bool DidReceiveAllMessages => _preReceivedMessagesCount >= _messagesCount;

        /// <summary>
        /// Message receive handler, this method will increment a counter that keeps track of the
        /// amount of messages that have been received
        /// </summary>
        public void HandleEvent(TelemetryEventType telemetryEventType, Guid? messageId, object message = null)
        {
            var elapsedSpan = new TimeSpan(DateTime.UtcNow.Ticks - _createdAt.Ticks);

            if (telemetryEventType == TelemetryEventType.PreReceive)
            {
                Interlocked.Increment(ref _preReceivedMessagesCount);
            }

            _telemetryClient.TrackEvent(
                telemetryEventType,
                new
                {
                    MessageId = messageId,
                    CreatedAt = elapsedSpan.Ticks,
                    Message = message
                }
            );
        }
    }
}
