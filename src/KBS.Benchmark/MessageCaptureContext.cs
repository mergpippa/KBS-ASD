using System.Threading;
using KBS.TestCases.Configuration;
using KBS.Topics;

namespace KBS.Benchmark
{
    public class MessageCaptureContext
    {
        private readonly TestCaseConfiguration _testCaseConfiguration;

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
        public MessageCaptureContext(TestCaseConfiguration testCaseConfiguration)
        {
            _testCaseConfiguration = testCaseConfiguration;
        }

        /// <summary>
        /// Checks if all messages have been received
        /// </summary>
        public bool DidReceiveAllMessages
        {
            get => _receivedMessagesCount >= _testCaseConfiguration.MessagesCount;
        }

        /// <summary>
        /// Checks if all messages have been received
        /// </summary>
        public bool DidSendAllMessages
        {
            get => _sentMessagesCount >= _testCaseConfiguration.MessagesCount;
        }

        /// <summary>
        /// Property that indicates whether the benchmark timed out when waiting for messages
        /// </summary>
        public bool DidTimeoutWhenWaitingOnMessages { get; set; }

        /// <summary>
        /// Message receive handler, this method will increment a counter that keeps track of the
        /// amount of messages that have been received
        /// </summary>
        private void HandleReceiveMessage(IMessageDiagnostics message)
        {
            Interlocked.Increment(ref _receivedMessagesCount);
        }

        private void HandleSentMessage(IMessageDiagnostics message)
        {
            Interlocked.Increment(ref _sentMessagesCount);
        }
    }
}
