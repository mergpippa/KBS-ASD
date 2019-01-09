using System;

namespace KBS.Configuration
{
    public class BenchmarkConfiguration : BaseConfiguration
    {
        /// <summary>
        /// Amount of messages to send during the benchmark
        /// </summary>
        public static int MessageCount => GetFromArguments<int>("MessageCount", 1000);

        /// <summary>
        /// Message size in bytes (a message will be filled with a byte array of the given size)
        /// </summary>
        public static int FillerSize => GetFromArguments<int>("FillerSize");

        /// <summary>
        /// Amounts of threads to use to send messages
        /// </summary>
        public static int ClientCount => GetFromArguments<int>("ClientCount", 2);

        /// <summary>
        /// Time before test should abort after last message was sent
        /// </summary>
        public static TimeSpan Timeout => GetFromArguments("Timeout", TimeSpan.FromMinutes(1));
    }
}
