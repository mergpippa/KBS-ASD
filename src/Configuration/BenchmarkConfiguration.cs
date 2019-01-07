using System;

namespace KBS.Configuration
{
    public class BenchmarkConfiguration : BaseConfiguration
    {
        /// <summary>
        /// Amount of messages to send during the benchmark
        /// </summary>
        public static int MessagesCount { get => GetFromAny<int>("MessagesCount", 100); }

        /// <summary>
        /// Message size in bytes (a message will be filled with a byte array of the given size)
        /// </summary>
        public static int FillerSize { get => GetFromAny<int>("FillerSize"); }

        /// <summary>
        /// Amounts of threads to use to send messages
        /// </summary>
        public static int Clients { get => GetFromAny<int>("Clients", 2); }

        /// <summary>
        /// Time before test should abort after last message was sent
        /// </summary>
        public static TimeSpan BenchmarkTimeout { get => GetFromAny("BenchmarkTimeout", TimeSpan.FromMinutes(1)); }
    }
}
