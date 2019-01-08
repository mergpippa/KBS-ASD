namespace KBS.Data.Constants
{
    public static class EnvironmentVariables
    {
        /// <summary>
        /// Test case type (See KBS.Data.Enum/TestCaseType.cs)
        /// </summary>
        public const string TestCaseType = "TEST_CASE_TYPE";

        /// <summary>
        /// The telemetry client that is used to track events (See KBS.Data.Enum/TelemetryClientType.cs)
        /// </summary>
        public const string TelemetryClientType = "TELEMETRY_CLIENT_TYPE";

        /// <summary>
        /// The amout of clients that will simultaniuously send messages
        /// </summary>
        public const string Clients = "TEST_CASE_CLIENTS";

        /// <summary>
        /// The total amount of messages that will be send during the benchmark
        /// </summary>
        public const string MessageCount = "TEST_CASE_MESSAGE_COUNT";

        /// <summary>
        /// The amount of additional message data that will be included with the message
        /// </summary>
        public const string FillerSize = "TEST_CASE_FILLER_SIZE";

        /// <summary>
        /// The total time before the benchmarks stops listening to messages
        /// </summary>
        public const string Timeout = "TEST_CASE_TIMEOUT";

        ///<summary>
        /// Transport configuration
        /// </summary>
        public const string TransportType = "TRANSPORT_TYPE";

        /// <summary>
        /// The operation timeout of the Azure service bus.
        /// </summary>
        public const string AzureServiceBusOperationTimeout = "AZURE_SERVICE_BUS_OPERATION_TIMEOUT";

        /// <summary>
        /// The secret Azure service primary key.
        /// </summary>
        public const string AzureServiceBusToken = "AZURE_SERVICE_BUS_PRIMARY_KEY";

        /// <summary>
        /// The azure service bus host.
        /// </summary>
        public const string AzureServiceBusHost = "AZURE_SERVICE_BUS_HOST";

        /// <summary>
        /// The rabbit mq host.
        /// </summary>
        public const string RabbitMqHost = "RABBIT_MQ_HOST";

        /// <summary>
        /// The rabbit mq username.
        /// </summary>
        public const string RabbitMqUsername = "RABBIT_MQ_USERNAME";

        /// <summary>
        /// The rabbit mq password.
        /// </summary>
        public const string RabbitMqPassword = "RABBIT_MQ_PASSWORD";

        /// <summary>
        /// The app insights instrumentation key (indentifier for appinsights instance).
        /// </summary>
        public const string AppInsightsInstrumentationKey = "APPINSIGHTS_INSTRUMENTATIONKEY";
    }
}
