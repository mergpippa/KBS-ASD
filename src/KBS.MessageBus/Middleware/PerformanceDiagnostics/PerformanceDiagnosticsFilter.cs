using System.Collections.Generic;
using System.Threading.Tasks;
using GreenPipes;
using KBS.Data.Constants;
using KBS.Telemetry;
using KBS.Topics;
using MassTransit;

namespace KBS.MessageBus.Middleware.PerformanceDiagnostics
{
    public class PerformanceDiagnosticsFilter<T> :
        IFilter<T>
        where T : class, PipeContext
    {
        private ITelemetryClient TelemetryClient;

        public PerformanceDiagnosticsFilter(ITelemetryClient telemetryClient)
        {
            TelemetryClient = telemetryClient;
        }

        public async Task Send(T context, IPipe<T> next)
        {
            // Send this message immediately to avoid any performance impact
            await next.Send(context);

            if (!context.TryGetPayload(out ConsumeContext consumeContext))
                return;

            if (!consumeContext.TryGetMessage<IMessageDiagnostics>(out var messageContext))
                return;

            // Track message send
            TelemetryClient.TrackEvent(
                TelemetryEventNames.MessageReceived,
                new Dictionary<string, string>() {
                    { TelemetryEventPropertyNames.MessageType, messageContext.Message.MessageType },
                    { TelemetryEventPropertyNames.MessageId, messageContext.Message.Id.ToString() }
                }
            );
        }

        public void Probe(ProbeContext context)
        {
        }
    }
}
