namespace KBS.Configuration
{
    public class TelemetryClientConfiguration : BaseConfiguration
    {
        public static string AppInsightsInstrumentationKey =>
            GetFromEnvironment<string>("AppInsightsInstrumentationKey");
    }
}
