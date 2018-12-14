using System.Collections.Generic;
using MassTransit;

namespace KBS.MessageBus.Model
{
    public struct ReceiveEndpoint
    {
        public string QueueName { get; private set; }

        public List<IConsumer> Consumers { get; private set; }

        public ReceiveEndpoint(string queueName, List<IConsumer> consumers)
        {
            QueueName = queueName;
            Consumers = consumers;
        }
    }
}
