namespace KBS.Configuration
{
    public static class ControllerConfiguration
    {
        public static string KuduHost => BaseConfiguration.GetFromEnvironment<string>("KuduHost");

        public static string KuduUsername => BaseConfiguration.GetFromEnvironment<string>("KuduUsername");

        public static string KuduPassword => BaseConfiguration.GetFromEnvironment<string>("KuduPassword");

        public static string WebJobName => BaseConfiguration.GetFromEnvironment<string>("WebJobName");
    }
}
