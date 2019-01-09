using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using KBS.Configuration;
using KBS.Data.Enum;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        /// </summary>
        TimeSpan AzureServiceBusOperationTimeout { get; set; }
    }
}
