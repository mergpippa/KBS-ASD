using System.Threading.Tasks;
using GreenPipes;
using KBS.Topics;
using MassTransit;

namespace KBS.MessageBus.Middleware.PerformanceDiagnostics
{
    public class PerformanceDiagnosticsFilter<T> :
        IFilter<T>
        where T : class, PipeContext
    {
        private readonly MessageCaptureContext _messageCaptureContext;

        public PerformanceDiagnosticsFilter(MessageCaptureContext messageCaptureContext)
        {
            _messageCaptureContext = messageCaptureContext;
        }

        public async Task Send(T context, IPipe<T> next)
        {
            // Send this message immediately to avoid any performance impact
            await next.Send(context);

            if (!context.TryGetPayload(out ConsumeContext consumeContext))
                return;

            if (!consumeContext.TryGetMessage<IMessageDiagnostics>(out var messageContext))
                return;

            // Handle message receive
            _messageCaptureContext.HandleReceiveMessage(messageContext.Message);
        }

        public void Probe(ProbeContext context)
        {
        }
    }
}
