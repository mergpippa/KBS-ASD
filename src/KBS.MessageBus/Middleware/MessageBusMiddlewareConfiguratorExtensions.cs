using GreenPipes;
using KBS.MessageBus.Middleware.PerformanceDiagnostics;
using KBS.Telemetry;

namespace KBS.MessageBus.Middleware
{
    public static class MessageBusMiddlewareConfiguratorExtensions
    {
        public static void UseMessagePerformanceDiagnostics<T>(this IPipeConfigurator<T> configurator, ITelemetryClient telemetryClient)
            where T : class, PipeContext
        {
            configurator.AddPipeSpecification(new PerformanceDiagnosticsSpecification<T>(telemetryClient));
        }
    }
}
