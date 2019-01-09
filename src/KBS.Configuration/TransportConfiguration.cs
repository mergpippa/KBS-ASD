using System;

namespace KBS.Configuration
{
    public static class TransportConfiguration
    {
        #region general

        /// <summary>
        /// Variable used to indicate whether transport should run in "Express" or "Durable" mode
        /// </summary>
        public static string UseExpress => BaseConfiguration.GetFromArguments<string>("UseExpress");

        #endregion general

        #region azure service bus

        /// <summary>
        /// Azure service bus location
        /// </summary>
        public static string AzureServiceBusUri => BaseConfiguration.GetFromEnvironment<string>("AzureServiceBusUri");

        /// <summary>
        /// Value used to authenticate when using the azure service bus transport
        /// </summary>
        public static string AzureServiceBusToken => BaseConfiguration.GetFromEnvironment<string>("AzureServiceBusToken");

        /// <summary>
        /// Value used to set the maximum duration of an operation when using the azure service bus transport
        /// </summary>
        public static TimeSpan AzureServiceBusOperationTimeout => BaseConfiguration.GetFromArguments("AzureServiceBusOperationTimeout", TimeSpan.FromSeconds(30));

        #endregion azure service bus

        #region rabbit mq

        /// <summary>
        /// RabbitMQ location
        /// </summary>
        public static string RabbitMqHost => BaseConfiguration.GetFromEnvironment<string>("RabbitMqHost");

        /// <summary>
        /// RabbitMQ username that is used for authentication when using the RabbitMq transport
        /// </summary>
        public static string RabbitMqUsername => BaseConfiguration.GetFromEnvironment<string>("RabbitMqUsername");

        /// <summary>
        /// RabbitMQ password that is used for authentication when using the RabbitMq transport
        /// </summary>
        public static string RabbitMqPassword => BaseConfiguration.GetFromEnvironment<string>("RabbitMqPassword");

        #endregion rabbit mq
    }
}
