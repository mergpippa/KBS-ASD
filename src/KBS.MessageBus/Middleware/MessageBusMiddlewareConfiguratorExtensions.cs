using GreenPipes;
using KBS.MessageBus.Middleware.PerformanceDiagnostics;

namespace KBS.MessageBus.Middleware
{
    public static class MessageBusMiddlewareConfiguratorExtensions
    {
        public static void UseMessagePerformanceDiagnostics<T>(this IPipeConfigurator<T> configurator, MessageCaptureContext messageCaptureContext)
            where T : class, PipeContext
        {
            configurator.UseFilter(new PerformanceDiagnosticsFilter<T>(messageCaptureContext));
        }
    }
}
