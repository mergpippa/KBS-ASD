using System;

namespace KBS.TestCases
{
    public struct TestCaseConfiguration
    {
        #region general configuration

        /// <summary>
        /// Time duration in milliseconds of a test case
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Time to wait for the last response
        /// </summary>
        public TimeSpan Timeout { get; set; }

        #endregion general configuration

        #region message configuration

        /// <summary>
        /// Amount of messages to send each second
        /// </summary>
        public int MessageFrequency { get; set; }

        /// <summary>
        /// Message size in bytes (a message will be filled with a byte array of the given size)
        /// </summary>
        public int FillerSize { get; set; }

        #endregion message configuration
    }
}
