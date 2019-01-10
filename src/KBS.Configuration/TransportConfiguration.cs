using System;

namespace KBS.Configuration
{
    public class TransportConfiguration : BaseConfiguration
    {
        #region general

        /// <summary>
        /// Variable used to indicate whether transport should run in "Express" or "Durable" mode
        /// </summary>
        public static string UseExpress => GetFromArguments<string>("UseExpress");

        #endregion general

        #region azure service bus

        /// <summary>
        /// Azure service bus location
        /// </summary>
        public static string AzureServiceBusUri => GetFromEnvironment<string>("AzureServiceBusUri");

        /// <summary>
        /// Value used to authenticate when using the azure service bus transport
        /// </summary>
        public static string AzureServiceBusToken => GetFromEnvironment<string>("AzureServiceBusToken");

        /// <summary>
        /// Value used to set the maximum duration of an operation when using the azure service bus transport
        /// </summary>
        public static TimeSpan AzureServiceBusOperationTimeout => GetFromArguments("AzureServiceBusOperationTimeout", TimeSpan.FromSeconds(30));

        #endregion azure service bus

        #region rabbit mq

        /// <summary>
        /// RabbitMQ location
        /// </summary>
        public static string RabbitMqHost => GetFromEnvironment<string>("RabbitMqHost");

        /// <summary>
        /// RabbitMQ username that is used for authentication when using the RabbitMq transport
        /// </summary>
        public static string RabbitMqUsername => GetFromEnvironment<string>("RabbitMqUsername");

        /// <summary>
        /// RabbitMQ password that is used for authentication when using the RabbitMq transport
        /// </summary>
        public static string RabbitMqPassword => GetFromEnvironment<string>("RabbitMqPassword");

        #endregion rabbit mq
    }
}
