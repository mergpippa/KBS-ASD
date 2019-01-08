namespace KBS.Configuration
{
    public class TransportConfiguration : BaseConfiguration
    {
        #region general

        public static string UseExpress { get => GetFromArguments<string>("UseExpress"); }

        #endregion general

        #region azure service bus

        /// <summary>
        /// </summary>
        public static string AzureServiceBusUri { get => GetFromEnvironment<string>("AzureServiceBusUri"); }

        /// <summary>
        /// </summary>
        public static string AzureServiceBusToken { get => GetFromEnvironment<string>("AzureServiceBusToken"); }

        /// <summary>
        /// </summary>
        public static int AzureServiceBusOperationTimeout { get => GetFromArguments<int>("OperationTimeout"); }

        #endregion azure service bus

        #region rabbit mq

        /// <summary>
        /// </summary>
        public static string RabbitMqHost { get => GetFromEnvironment<string>("RabbitMqHost"); }

        /// <summary>
        /// </summary>
        public static string RabbitMqUsername { get => GetFromEnvironment<string>("RabbitMqUsername"); }

        /// <summary>
        /// </summary>
        public static string RabbitMqPassword { get => GetFromEnvironment<string>("RabbitMqPassword"); }

        #endregion rabbit mq
    }
}
