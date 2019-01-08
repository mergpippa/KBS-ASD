using System.Threading.Tasks;
using GreenPipes;
using KBS.Topics;
using MassTransit;

namespace KBS.MessageBus.Middleware.PerformanceDiagnostics
{
    public class PerformanceDiagnosticsFilter<T> : IFilter<T>
        where T : class, PipeContext
    {
        private readonly MessageCaptureContext _messageCaptureContext;

        public PerformanceDiagnosticsFilter(MessageCaptureContext messageCaptureContext)
        {
            _messageCaptureContext = messageCaptureContext;
        }

        public async Task Send(T context, IPipe<T> next)
        {
            context.TryGetPayload(out ConsumeContext consumeContext);
            consumeContext.TryGetMessage<IMessageDiagnostics>(out var messageContext);

            if (messageContext.Message == null)
            {
                _messageCaptureContext.HandleMessageException();
                throw new System.Exception("Invalid message");
            }

            await next.Send(context);

            _messageCaptureContext.HandleMessageReceived(messageContext.Message);
        }

        public void Probe(ProbeContext context)
        {
        }
    }
}
