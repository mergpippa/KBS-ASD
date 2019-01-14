using KBS.Data.Enum;

namespace KBS.Configuration
{
    public class ControllerConfiguration : BaseConfiguration
    {
        public static string KuduHost =>
            GetFromEnvironment<string>("KuduHost");

        public static string KuduUsername =>
            GetFromEnvironment<string>("KuduUsername");

        public static string KuduPassword =>
            GetFromEnvironment<string>("KuduPassword");

        public static string WebJobName =>
            GetFromEnvironment<string>("WebJobName");

        public static string StorageAccountConnectionString =>
            GetFromEnvironment<string>("StorageAccountConnectionString");

        public static string StorageAccountContainerName =>
            GetFromEnvironment<string>("StorageAccountContainerName");

        public static string StorageAccountName =>
            GetFromEnvironment<string>("StorageAccountName");

        public static StorageClientType StorageClientType =>
            (StorageClientType)GetFromEnvironment<int>("StorageClientType");
    }
}
