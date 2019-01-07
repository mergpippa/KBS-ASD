namespace Configuration.BusControlConfiguration
{
    public class AzureServiceBusTransportConfiguration
    {
        public string Uri { get; set; }
    }

    public static class AzureServiceBusTransportConfigurationExtensionMethods
    {
        public static void FillUsingEnvironment(this AzureServiceBusTransportConfiguration)
        {
        }

        public static void FillUsingJsonFile(this AzureServiceBusTransportConfiguration, string path)
        {
        }
    }
}
