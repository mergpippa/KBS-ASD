namespace KBS.Configuration
{
    public class TelemetryClientConfiguration : BaseConfiguration
    {
        public static readonly string AppInsightsInstrumentationKey =
            GetFromEnvironment<string>("AppInsightsInstrumentationKey");
    }
}
