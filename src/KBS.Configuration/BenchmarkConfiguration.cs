using System;

namespace KBS.Configuration
{
    public class BenchmarkConfiguration : BaseConfiguration
    {
        /// <summary>
        /// ISO 8601 format without colon seperators
        /// </summary>
        private static readonly string InitializedAt = DateTime.UtcNow.ToString("yyyy-MM-ddTHHmmss");

        /// <summary>
        /// Unique benchmark name
        /// </summary>
        public static string Name =>
            GetFromArguments("Name", InitializedAt);

        /// <summary>
        /// Amount of messages to send during the benchmark
        /// </summary>
        public static int MessageCount =>
            GetFromArguments("MessageCount", 5);

        /// <summary>
        /// Message size in bytes (a message will be filled with a byte array of the given size)
        /// </summary>
        public static int FillerSize =>
            GetFromArguments<int>("FillerSize", 50);

        /// <summary>
        /// Amounts of threads to use to send messages
        /// </summary>
        public static int ClientCount =>
            GetFromArguments("ClientCount", 1);

        /// <summary>
        /// Time before test should abort after last message was sent
        /// </summary>
        public static TimeSpan Timeout =>
            GetFromArguments("Timeout", TimeSpan.FromMinutes(1));
    }
}
