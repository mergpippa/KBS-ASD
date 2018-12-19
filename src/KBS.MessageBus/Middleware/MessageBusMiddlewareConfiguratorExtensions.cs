using GreenPipes;
using KBS.MessageBus.Middleware.PerformanceDiagnostics;
using Microsoft.ApplicationInsights;

namespace KBS.MessageBus.Middleware
{
    public static class MessageBusMiddlewareConfiguratorExtensions
    {
        public static void UseMessagePerformanceDiagnostics<T>(this IPipeConfigurator<T> configurator, TelemetryClient telemetryClient)
            where T : class, PipeContext
        {
            configurator.AddPipeSpecification(new PerformanceDiagnosticsSpecification<T>(telemetryClient));
        }
    }
}
