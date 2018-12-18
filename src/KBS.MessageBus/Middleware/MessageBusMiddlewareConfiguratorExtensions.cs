using GreenPipes;
using KBS.MessageBus.Middleware.PerformanceDiagnostics;

namespace KBS.MessageBus.Middleware
{
    public static class MessageBusMiddlewareConfiguratorExtensions
    {
        public static void UseMessagePerformanceDiagnostics<T>(this IPipeConfigurator<T> configurator)
            where T : class, PipeContext
        {
            configurator.AddPipeSpecification(new PerformanceDiagnosticsSpecification<T>());
        }
    }
}
