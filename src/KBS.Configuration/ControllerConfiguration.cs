namespace KBS.Configuration
{
    internal class ControllerConfiguration : BaseConfiguration
    {
        public static string WebJobHost { get => GetFromEnvironment<string>("TransportType"); }
    }
}
