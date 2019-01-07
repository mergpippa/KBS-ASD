namespace KBS.Configuration
{
    public class TransportConfiguration : BaseConfiguration
    {
        /// <summary>
        /// </summary>
        public static string AzureServiceBusUri { get => GetFromEnvironment<string>("AzureServiceBusUri"); }

        /// <summary>
        /// </summary>
        public static string AzureServiceBusToken { get => GetFromEnvironment<string>("AzureServiceBusToken"); }
    }
}
