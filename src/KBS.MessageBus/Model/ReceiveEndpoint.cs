using System.Collections.Generic;
using MassTransit;

namespace KBS.MessageBus.Model
{
    public struct ReceiveEndpoint
    {
        public string QueueName;

        public List<IConsumer> Consumers;
    }
}
