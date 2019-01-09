namespace KBS.Configuration
{
    public class ControllerConfiguration : BaseConfiguration
    {
        public static string KuduHost { get => GetFromEnvironment<string>("KuduHost"); }

        public static string KuduUsername { get => GetFromEnvironment<string>("KuduUsername"); }

        public static string KuduPassword { get => GetFromEnvironment<string>("KuduPassword"); }

        public static string WebJobName { get => GetFromEnvironment<string>("WebJobName"); }
    }
}
