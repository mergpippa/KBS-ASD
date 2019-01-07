using System;
using System.Collections.Generic;
using System.Threading;
using KBS.Data.Constants;
using KBS.Telemetry;
using KBS.Topics;

namespace KBS.MessageBus
{
    public class MessageCaptureContext
    {
        /// <summary>
        /// </summary>
        private readonly ITelemetryClient _telemetryClient;

        /// <summary>
        /// </summary>
        private readonly int _messagesCount;

        /// <summary>
        /// Amount of messages that are received
        /// </summary>
        private int _receivedMessagesCount;

        /// <summary>
        /// Amount of messages that are sent
        /// </summary>
        private int _sentMessagesCount;

        /// <summary>
        /// Count execeptions
        /// </summary>
        private int _exceptionCount;

        /// <summary>
        /// Time when this instance was created
        /// </summary>
        private readonly DateTime _createdAt = DateTime.UtcNow;

        /// <summary>
        /// MessageCaptureContext constructor
        /// </summary>
        /// <param name="testCaseConfiguration">
        /// </param>
        public MessageCaptureContext(int messagesCount, ITelemetryClient telemetryClient)
        {
            _messagesCount = messagesCount;
            _telemetryClient = telemetryClient;
        }

        /// <summary>
        /// Checks if all messages have been received
        /// </summary>
        public bool DidReceiveAllMessages
        {
            get => _receivedMessagesCount >= _messagesCount;
        }

        /// <summary>
        /// Checks if all messages have been received
        /// </summary>
        public bool DidSendAllMessages
        {
            get => _sentMessagesCount >= _messagesCount;
        }

        /// <summary>
        /// Property that indicates whether the benchmark timed out when waiting for messages
        /// </summary>
        public bool DidTimeoutWhenWaitingOnMessages { get; set; }

        /// <summary>
        /// Message receive handler, this method will increment a counter that keeps track of the
        /// amount of messages that have been received
        /// </summary>
        public void HandleMessageReceived(IMessageDiagnostics message)
        {
            // Increment counter
            Interlocked.Increment(ref _receivedMessagesCount);

            var elapsedSpan = new TimeSpan(DateTime.UtcNow.Ticks - _createdAt.Ticks);

            // Track message
            _telemetryClient.TrackEvent(
                TelemetryEventNames.MessageReceived,
                new Dictionary<string, string>
                {
                    { "MessageId", message.Id.ToString() },
                    { "TestCase", message.TestCase.ToString() },
                    { "ReceivedAt", elapsedSpan.Ticks.ToString() }
                }
            );
        }

        public void HandleMessageSend(IMessageDiagnostics message)
        {
            Interlocked.Increment(ref _sentMessagesCount);

            var elapsedSpan = new TimeSpan(DateTime.UtcNow.Ticks - _createdAt.Ticks);

            // Track message
            _telemetryClient.TrackEvent(
                TelemetryEventNames.MessageSent,
                new Dictionary<string, string>
                {
                    { "MessageId", message.Id.ToString() },
                    { "TestCase", message.TestCase.ToString() },
                    { "SentAt", elapsedSpan.Ticks.ToString() }
                }
            );
        }

        /// <summary>
        /// Message receive handler, this method will increment a counter that keeps track of the
        /// amount of messages that have been received
        /// </summary>
        public void HandleMessageException(IMessageDiagnostics message)
        {
            // Increment counter
            Interlocked.Increment(ref _exceptionCount);

            var elapsedSpan = new TimeSpan(DateTime.UtcNow.Ticks - _createdAt.Ticks);

            // Track message
            _telemetryClient.TrackEvent(
                TelemetryEventNames.MessageException,
                new Dictionary<string, string>
                {
                    { "MessageId", message.Id.ToString() },
                    { "TestCase", message.TestCase.ToString() },
                    { "ExceptionAt", elapsedSpan.Ticks.ToString() }
                }
            );
        }
    }
}
