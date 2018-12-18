namespace KBS.MessageBus.Data
{
    internal static class EnvironmentVariable
    {
        public const string TransportType = "TRANSPORT_TYPE";

        public const string OperationTimeout = "OPERATION_TIMEOUT";

        //
        public const string AzureServiceBusToken = "AZURE_SERVICE_BUS_PRIMARY_KEY";

        public const string AzureServiceBusHost = "AZURE_SERVICE_BUS_HOST";

        //
        public const string RabbitMqHost = "RABBIT_MQ_HOST";

        public const string RabbitMqUsername = "RABBIT_MQ_USERNAME";

        public const string RabbitMqPassword = "RABBIT_MQ_PASSWORD";
    }
}
