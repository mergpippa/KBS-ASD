using System;
using KBS.Data.Enum;

namespace KBS.TestCases.Configuration
{
    public class TestCaseConfiguration
    {
        #region general configuration

        public TestCaseType TestCaseType { get; set; }

        /// <summary>
        /// Amount of messages to send
        /// </summary>
        public int MessagesCount { get; set; }

        /// <summary>
        /// Amounts of threads to use to send messages
        /// </summary>
        public int Clients { get; set; }

        /// <summary>
        /// Time before test should abort after last message was sent
        /// </summary>
        public TimeSpan Timeout { get; set; }

        #endregion general configuration

        #region message configuration

        /// <summary>
        /// Message size in bytes (a message will be filled with a byte array of the given size)
        /// </summary>
        public int FillerSize { get; set; }

        #endregion message configuration
    }
}
