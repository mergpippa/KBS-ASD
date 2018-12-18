using System;
using System.Threading.Tasks;
using GreenPipes;
using KBS.Topics.RequestResponseCase;
using MassTransit;

namespace KBS.MessageBus.Middleware.PerformanceDiagnostics
{
    public class PerformanceDiagnosticsFilter<T> :
        IFilter<T>
        where T : class, PipeContext
    {
        public async Task Send(T context, IPipe<T> next)
        {
            // Send this message immediately to avoid any performance impact
            await next.Send(context);

            if(!context.TryGetPayload(out ConsumeContext consumeContext))
                return;

            if (!consumeContext.TryGetMessage<IRequestMessage>(out var messageContext))
                return;
            
            // Track message send
            await Console.Out.WriteLineAsync($"Sending message {context} {messageContext.Message.Count}");
        }

        public void Probe(ProbeContext context)
        {
            
        }
    }
}
