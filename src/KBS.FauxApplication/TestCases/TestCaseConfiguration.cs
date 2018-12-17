namespace KBS.FauxApplication.TestCases
{
    public struct TestCaseConfiguration
    {
        #region general configuration

        /// <summary>
        /// Time duration in milliseconds of a test case
        /// </summary>
        public int Duration { get; set; }

        #endregion general configuration

        #region message configuration

        /// <summary>
        /// Amount of messages to send each second
        /// </summary>
        public int MessageFrequency { get; set; }

        /// <summary>
        /// Message size (a message will be filled with a byte array of the given size)
        /// </summary>
        public int MinimalSize { get; set; }

        #endregion message configuration
    }
}
