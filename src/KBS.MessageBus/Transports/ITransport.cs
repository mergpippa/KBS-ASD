using KBS.MessageBus.Configuration;
using MassTransit;

namespace KBS.MessageBus.Transports
{
    internal interface ITransport
    {
        IBusControl GetInstance(MessageBusConfigurator messageBusConfigurator);
    }
}
