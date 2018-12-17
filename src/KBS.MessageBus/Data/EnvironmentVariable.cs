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
        public const string RabbitMQHost = "RABBIT_MQ_HOST";

        public const string RabbitMQUsername = "RABBIT_MQ_USERNAME";
        public const string RabbitMQPassword = "RABBIT_MQ_PASSWORD";
    }
}
