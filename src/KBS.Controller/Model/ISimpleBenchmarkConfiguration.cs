using System;
using KBS.Data.Enum;

namespace KBS.Controller.Controllers
{
    /// <summary>
    /// Configuration class that is used to
    /// </summary>
    public interface ISimpleBenchmarkConfiguration
    {
        /// <summary>
        /// Amount of messages to send during the benchmark
        /// </summary>
        int MessagesCount { get; set; }

        /// <summary>
        /// Message size in bytes (a message will be filled with a byte array of the given size)
        /// </summary>
        int FillerSize { get; set; }

        /// <summary>
        /// Amounts of threads to use to send messages
        /// </summary>
        int ClientsCount { get; set; }

        /// <summary>
        /// Time before test should abort after last message was sent
        /// </summary>
        TimeSpan Timeout { get; set; }

        /// <summary>
        /// Value that is used to choose the test case that is used to run the benchmark
        /// </summary>
        TestCaseType TestCaseType { get; set; }

        /// <summary>
        /// Value that is used to choose between the different BusControl transports
        /// </summary>
        TransportType TransportType { get; set; }

        /// <summary>
        /// Value used to set the maximum duration of an operation when using the azure service bus transport
        /// </summary>
        TimeSpan AzureServiceBusOperationTimeout { get; set; }

        /// <summary>
        /// Value used to choose whether transport should run in "Express" or "Durable" mode
        /// </summary>
        bool UseExpress { get; set; }
    }
}
