using System;

namespace KBS.TestCases.Exceptions
{
    /// <summary>
    /// Exception used when test case does not exist
    /// </summary>
    internal class UnknownTestCaseException : Exception
    {
        /// <summary>
        /// UnknownTestCaseException constructor without any arguments
        /// </summary>
        public UnknownTestCaseException() : base("null")
        {
        }

        /// <summary>
        /// UnknownTestCaseException constructor with test case type as first argument
        /// </summary>
        /// <param name="testCaseType">
        /// </param>
        public UnknownTestCaseException(string testCaseType)
            : base(testCaseType, null)
        { }

        /// <summary>
        /// UnknownTestCaseException constructor with test case type and innerExceptoin
        /// </summary>
        /// <param name="testCaseType">
        /// </param>
        /// <param name="innerException">
        /// </param>
        public UnknownTestCaseException(string testCaseType, Exception innerException)
            : base($"Unknown test case type {testCaseType}", innerException)
        { }
    }
}
