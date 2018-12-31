using System.Threading;
using KBS.TestCases.Configuration;

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
        private MessageCaptureContext(TestCaseConfiguration testCaseConfiguration)
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
        /// Message receive handler, this method will increment a counter that keeps track of the
        /// amount of messages that have been received
        /// </summary>
        private void HandleReceiveMessage()
        {
            Interlocked.Increment(ref _receivedMessagesCount);
        }

        private void HandleSentMessage()
        {
            Interlocked.Increment(ref _sentMessagesCount);
        }
    }
}
