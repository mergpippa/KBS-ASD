using System;
using KBS.Data.Enum;

namespace KBS.Data.Model
{
    /// <summary>
    /// Configuration class that is used as a model for the JSON body for the webjob trigger request
    /// </summary>
    public class SimpleBenchmarkConfiguration
    {
        /// <summary>
        /// Amount of messages to send during the benchmark
        /// </summary>
        public int MessageCount { get; set; }

        /// <summary>
        /// Message size in bytes (a message will be filled with a byte array of the given size)
        /// </summary>
        public int FillerSize { get; set; }

        /// <summary>
        /// Amounts of threads to use to send messages
        /// </summary>
        public int ClientCount { get; set; }

        /// <summary>
        /// Time before test should abort after last message was sent. String should match TimeSpan
        /// pattern. https://docs.microsoft.com/en-us/dotnet/api/system.timespan.tostring#System_TimeSpan_ToString
        /// </summary>
        public TimeSpan Timeout { get; set; }

        /// <summary>
        /// Value that is used to choose the test case that is used to run the benchmark
        /// - RequestResponse = 1
        /// - ConsumeConsumer = 2
        /// - WebShop = 3,
        /// </summary>
        public TestCaseType TestCaseType { get; set; }

        /// <summary>
        /// Value that is used to choose between the different BusControl transports
        /// - InMemory = 1
        /// - RabbitMq = 2
        /// - AzureServiceBus = 3
        /// </summary>
        public TransportType TransportType { get; set; }

        /// <summary>
        /// Value used to set the maximum duration of an operation when using the azure service bus
        /// transport. String should match TimeSpan pattern. https://docs.microsoft.com/en-us/dotnet/api/system.timespan.tostring#System_TimeSpan_ToString
        /// </summary>
        public TimeSpan AzureServiceBusOperationTimeout { get; set; }

        /// <summary>
        /// Value used to choose whether transport should run in "Express" or "Durable" mode
        /// </summary>
        public bool UseExpress { get; set; }
    }
}
