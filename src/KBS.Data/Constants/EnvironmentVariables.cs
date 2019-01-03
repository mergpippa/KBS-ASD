namespace KBS.Data.Constants
{
    public static class EnvironmentVariables
    {
        /// <summary>
        /// Test case type (See KBS.Data.Enum/TestCaseType.cs)
        /// </summary>
        public const string TestCaseType = "TEST_CASE_TYPE";

        public const string Clients = "TEST_CASE_CLIENTS";

        public const string MessageCount = "TEST_CASE_MESSAGE_COUNT";

        public const string FillerSize = "TEST_CASE_FILLER_SIZE";

        public const string Timeout = "TEST_CASE_TIMEOUT";

        // Transport configuration
        public const string TransportType = "TRANSPORT_TYPE";

        public const string OperationTimeout = "OPERATION_TIMEOUT";

        //
        public const string AzureServiceBusToken = "AZURE_SERVICE_BUS_PRIMARY_KEY";

        public const string AzureServiceBusHost = "AZURE_SERVICE_BUS_HOST";

        //
        public const string RabbitMqHost = "RABBIT_MQ_HOST";

        public const string RabbitMqUsername = "RABBIT_MQ_USERNAME";

        public const string RabbitMqPassword = "RABBIT_MQ_PASSWORD";

        //
        public const string AppInsightsInstrumentationKey = "APPINSIGHTS_INSTRUMENTATIONKEY";
    }
}
