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
        public void HandleReceiveMessage(dynamic anonymousMessage)
        {
            // Increment counter
            Interlocked.Increment(ref _receivedMessagesCount);

            var message = anonymousMessage as IMessageDiagnostics;

            if (message == null)
            {
                Console.WriteLine("[Receive] Unable to cast message");
                return;
            }

            // Track message
            _telemetryClient.TrackEvent(
                TelemetryEventNames.MessageReceived,
                new Dictionary<string, string>
                {
                    { "MessageId", message.Id.ToString() },
                    { "ReceivedAt", DateTime.UtcNow.ToString() }
                }
            );
        }

        public void HandleSentMessage(dynamic anonymousMessage)
        {
            Interlocked.Increment(ref _sentMessagesCount);

            var message = anonymousMessage as IMessageDiagnostics;

            if (message == null)
            {
                Console.WriteLine("[Sent] Unable to cast message");
                return;
            }

            // Track message
            _telemetryClient.TrackEvent(
                TelemetryEventNames.MessageSent,
                new Dictionary<string, string>
                {
                    { "MessageId", message.Id.ToString() },
                    { "SentAt", DateTime.UtcNow.ToString() }
                }
            );
        }
    }
}
