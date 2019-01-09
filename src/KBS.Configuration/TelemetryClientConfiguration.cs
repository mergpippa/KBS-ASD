namespace KBS.Configuration
{
    public static class TelemetryClientConfiguration
    {
        public static readonly string AppInsightsInstrumentationKey = BaseConfiguration.GetFromArguments<string>("APPINSIGHTS_INSTRUMENTATIONKEY");
    }
}
