using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GreenPipes;
using KBS.Topics;
using MassTransit;
using Microsoft.ApplicationInsights;

namespace KBS.MessageBus.Middleware.PerformanceDiagnostics
{
    public class PerformanceDiagnosticsFilter<T> :
        IFilter<T>
        where T : class, PipeContext
    {
        private TelemetryClient TelemetryClient;

        public PerformanceDiagnosticsFilter(TelemetryClient telemetryClient)
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
                "Message received",
                new Dictionary<string, string>() {
                    { "type", messageContext.Message.Type },
                    { "id", messageContext.Message.Id.ToString() }
                }
            );

            await Console.Out.WriteLineAsync($"Tracing message! {typeof(T)} {messageContext.Message.Id}");
        }

        public void Probe(ProbeContext context)
        {
        }
    }
}
